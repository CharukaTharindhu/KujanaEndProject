using Microsoft.EntityFrameworkCore;
using MVC_DynamicMenu.Data;
using MVC_DynamicMenu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DynamicMenu.Repo
{
    public class PyamentReqRepo
    {
        private readonly DynamicMenuDBContext _c = null;

        public PyamentReqRepo(DynamicMenuDBContext c)
        {
            _c = c;
        }

        public List<MainBudgetAgreement> GetAllBudgetInfo()
        {
            List<MainBudgetAgreement> obj = _c.MainBudgetAgreement.FromSqlRaw("Select * from dbo.MainBudgetAgreement").ToList();

            for (int i = 0; i < obj.Count; i++)
            {
                obj[i].AdditionalActivityClass = _c.AdditionalActivityClass.FromSqlRaw("Select * from dbo.AdditionalActivityClass where MainBudgetAgreementMainBudgetID=" + obj[i].MainBudgetID).ToList();
                obj[i].AllocateBudgetAgreement = _c.AllocateBudgetAgreement.FromSqlRaw("Select * from dbo.AllocateBudgetAgreement where MainBudgetAgreementMainBudgetID=" + obj[i].MainBudgetID).ToList();
                obj[i].MySupport = _c.MySupport.FromSqlRaw("Select * from dbo.MySupport where MainBudgetAgreementMainBudgetID=" + obj[i].MainBudgetID).ToList();
                obj[i].ServiceSchedules = _c.ServiceSchedules.FromSqlRaw("Select * from dbo.ServiceSchedules where MainBudgetAgreementMainBudgetID=" + obj[i].MainBudgetID).ToList();
            }
            return obj;
        }

        public MainBudgetAgreement GetAllBudgetInfoByID(int id)
        {
            List<MainBudgetAgreement> obj = _c.MainBudgetAgreement.FromSqlRaw("Select * from dbo.MainBudgetAgreement where MainBudgetID=" + id).ToList();

                obj[0].AdditionalActivityClass = _c.AdditionalActivityClass.FromSqlRaw("Select * from dbo.AdditionalActivityClass where MainBudgetAgreementMainBudgetID=" + id).ToList();
                obj[0].AllocateBudgetAgreement = _c.AllocateBudgetAgreement.FromSqlRaw("Select * from dbo.AllocateBudgetAgreement where MainBudgetAgreementMainBudgetID=" + id).ToList();
                obj[0].MySupport = _c.MySupport.FromSqlRaw("Select * from dbo.MySupport where MainBudgetAgreementMainBudgetID=" + id).ToList();
                obj[0].ServiceSchedules = _c.ServiceSchedules.FromSqlRaw("Select * from dbo.ServiceSchedules where MainBudgetAgreementMainBudgetID=" + id).ToList();
      
            return obj[0];
        }


    }

}
