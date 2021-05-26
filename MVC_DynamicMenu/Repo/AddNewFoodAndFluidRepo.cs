using Microsoft.EntityFrameworkCore;
using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Repo
{
    public class AddNewFoodAndFluidRepo
    {
        private readonly DynamicMenuDBContext _context = null;

        public AddNewFoodAndFluidRepo(DynamicMenuDBContext context)
        {
            _context = context;
        }

        public void AddNewFoodAndFluid(AddNewFoodAndFluid FF)
        {
            var newFF = new AddNewFoodAndFluid
            {
                ClientID = FF.ClientID,
                Client_Name = FF.Client_Name,
                Start_date = FF.Start_date,
                End_date = FF.End_date,
                Breakfast = FF.Breakfast,
                Lunch = FF.Lunch,
                Diner = FF.Diner,
                Additional_Food = FF.Additional_Food,
                Breakfast_Fluid = FF.Breakfast_Fluid,
                Diner_Fluid = FF.Diner_Fluid,
                Lunch_Fluid = FF.Lunch_Fluid,
                Toal_Calories = FF.Toal_Calories,
                Staf_Name = FF.Staf_Name,
                Status = "Pending"
            };
            _context.AddNewFoodAndFluid.Add(newFF);
            _context.SaveChanges();
            UpdateMainFFTable(newFF.ClientID);
        }

        public List<FoodAndFluid> getAllFoodAndFluid()
        {
            var obj = _context.FoodAndFluid
                .FromSqlRaw("SELECT * FROM dbo.FoodAndFluid")
                .ToList();

            return obj;
        }

        public Client getUserById(int id)
        {
            var obj = _context.Client
            .FromSqlRaw("SELECT * FROM dbo.Client WHERE ClientID=" + id)
            .ToList();

            return obj[0];
        }
        public AddNewFoodAndFluid getFFId(int id)
        {
            var obj = _context.AddNewFoodAndFluid
            .FromSqlRaw("SELECT * FROM dbo.AddNewFoodAndFluid WHERE ClientID=" + id)
            .ToList();

            return obj[0];
        }

        public List<AddNewFoodAndFluid> getFFById(int id)
        {
            var obj = _context.AddNewFoodAndFluid
            .FromSqlRaw("SELECT * FROM dbo.AddNewFoodAndFluid WHERE clientId=" + id)
            .ToList();

            return obj;
        }
        public void UpdateFoodAndFluid(AddNewFoodAndFluid model)
        {
            _context.AddNewFoodAndFluid.Update(model);
            _context.SaveChanges();
        }

        public void DeleteFoodAndFluid(int id)
        {
            var FF = _context.AddNewFoodAndFluid.FirstOrDefault(x => x.ClientID == id);
            if (FF != null)
            {
                _context.AddNewFoodAndFluid.Remove(FF);
                _context.SaveChanges();
            }
        }

        public String GetPatients()
        {
            var obj = _context.Patient.FromSqlRaw("Select * From dbo.Patient").ToList();
            var patients = JsonConvert.SerializeObject(obj);

            return patients;
        }

        public void UpdateMainFFTable(int id)
        {
            int approved = 0;
            int pending = 0;
            var med = _context.AddNewFoodAndFluid
                .FromSqlRaw("SELECT * FROM dbo.AddNewFoodAndFluid WHERE cId=" + id)
            .ToList();
            _context.Database.ExecuteSqlRaw("DELETE FROM dbo.FoodAndFluid WHERE ClientID=" + id);
            //search by client id and get details of the client
            var client = _context.Patient.FromSqlRaw("SELECT * FROM dbo.Patient WHERE PatientID=" + id).ToList();
            //////////////////////////
            foreach (var item in med)
            {
                if (item.Status.Equals("Approved"))
                {
                    approved = approved + 1;
                }
                if (item.Status.Equals("Pending"))
                {
                    pending = pending + 1;
                }
            }
            FoodAndFluid FF = new FoodAndFluid
            {
                ClientID = id,
                //set the client name below
                Client_Name = client[0].Full_Name,
                Approved_Plane = approved,
                Pending_Plans = pending
            };
            _context.FoodAndFluid.Add(FF);
            _context.SaveChanges();
        }

        public int getPatientbyname(string id)
        {

            var obj = _context.Patient.FromSqlRaw("SELECT * FROM dbo.Patient WHERE Full_Name='" + id + "'").ToList();
            return obj[0].PatientID;
        }

        public void approvemed(int id)
        {
            var obj = _context.AddNewFoodAndFluid.FromSqlRaw("SELECT * FROM dbo.AddNewFoodAndFluid WHERE cID=" + id).ToList();
            obj[0].Status = "Approved";
            _context.AddNewFoodAndFluid.Update(obj[0]);
            UpdateMainFFTable(obj[0].ClientID);
            _context.SaveChanges();
        }
        public void updateFF(AddNewFoodAndFluid model)
        {
            var obj = _context.AddNewFoodAndFluid.FromSqlRaw("SELECT * FROM dbo.AddNewFoodAndFluid WHERE ClientID=" + model.ClientID).ToList();
            obj[0].Status = "Pending";
            obj[0].Client_Name = model.Client_Name;
            obj[0].Breakfast = model.Breakfast;
            obj[0].End_date = model.End_date;
            obj[0].Lunch = model.Lunch;
            obj[0].Diner = model.Diner;
            obj[0].Start_date = model.Start_date;
            obj[0].Additional_Food = model.Additional_Food;
            obj[0].Breakfast_Fluid = model.Breakfast_Fluid;
            obj[0].Diner_Fluid = model.Diner_Fluid;
            obj[0].Lunch_Fluid = model.Lunch_Fluid;
            obj[0].Toal_Calories = model.Toal_Calories;
            obj[0].Staf_Name = model.Staf_Name;

            _context.AddNewFoodAndFluid.Update(obj[0]);
            UpdateMainFFTable(obj[0].cId);
            _context.SaveChanges();
        }

        
               
       
         
               
               
               
               
               
    }
}
