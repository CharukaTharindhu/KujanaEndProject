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
    public class NewIncidentRepo
    {
        private readonly DynamicMenuDBContext _context = null;

        public NewIncidentRepo(DynamicMenuDBContext context)
        {
            _context = context;
        }

        public void AddNewIncident(NewIncidentLog incident)
        {
            var NewIncedent = new NewIncidentLog
            {
                Client = incident.Client,
                EntryDtae = incident.EntryDtae,
                IncidentType = incident.IncidentType,
                IncidentDate = incident.IncidentDate,
                IncidentTime = incident.IncidentTime,
                IncidentLocation = incident.IncidentLocation,
                EmergencyAssistance = incident.EmergencyAssistance,
                PoliceInvolvement = incident.PoliceInvolvement,
                PersonSearch = incident.PersonSearch,
                PersonRoomSearch = incident.PersonRoomSearch,
               // PRNProvided = incident.PRNProvided,
                What_was_happening_in_the_time_Before_the_Incident = incident.What_was_happening_in_the_time_Before_the_Incident,
                Behaviour = incident.Behaviour,
                How_did_you_de_escalate_the_incident = incident.How_did_you_de_escalate_the_incident,
                PossibleFunction = incident.PossibleFunction,
                Consequence = incident.Consequence,
                Abuse_or_neglect_of_the_Client_ = incident.Abuse_or_neglect_of_the_Client_,
                Criminal_Behaviour_Resulting_in_client_being_held_in_Custody = incident.Criminal_Behaviour_Resulting_in_client_being_held_in_Custody,
                Death_or_fatal_injury_of_a_client_serious_injury_of_the_client = incident.Death_or_fatal_injury_of_a_client_serious_injury_of_the_client,
                Unlawful_sexual_or_physical_contact_with_or_assault_of_the_client = incident.Unlawful_sexual_or_physical_contact_with_or_assault_of_the_client,
                Sexual_misconduct_committed_against_or_in_the_presence_of_the_client_including_grooming_of_the_client_for_sexual_activity = incident.Sexual_misconduct_committed_against_or_in_the_presence_of_the_client_including_grooming_of_the_client_for_sexual_activity,
                Unautherized_use_of_restriced_practice_in_relation_to_the_client = incident.Unautherized_use_of_restriced_practice_in_relation_to_the_client,
                Reportable_conduct_by_a_carer_staff_member = incident.Reportable_conduct_by_a_carer_staff_member,
                Category_of_incident = incident.Category_of_incident,
                Rating_of_Incident = incident.Rating_of_Incident,
                Risk_of_significant_ham_reported = incident.Risk_of_significant_ham_reported,
                PhysicalIntervention = incident.PhysicalIntervention,
                Type_of_physical_intervention = incident.Type_of_physical_intervention,
                How_long_did_the_physical_intervention_last = incident.How_long_did_the_physical_intervention_last,
                ClientInjury = incident.ClientInjury,
                StaffInjury = incident.StaffInjury,
                Has_the_client_disclosed_or_made_accusation_of_assult_or_abuse = incident.Has_the_client_disclosed_or_made_accusation_of_assult_or_abuse,
                Has_the_client_or_guardian_been_made_aware_of_their_right_to_involve_the_police_and_potentially_press_changes = incident.Has_the_client_or_guardian_been_made_aware_of_their_right_to_involve_the_police_and_potentially_press_changes,
                FollowUpRequired = incident.FollowUpRequired,
                //WasOnCallContacted = incident.WasOnCallContacted,
                NatureOfAll = incident.NatureOfAll,
                Result = incident.Result,
                FollowUp = incident.FollowUp,
                StaffMember = incident.StaffMember,
                Signature = incident.Signature,
                Name = incident.Name,
                Absconding_Requiring_Missing_Persons_Report = incident.Absconding_Requiring_Missing_Persons_Report,
                Actions = incident.Actions,
                Agitation_Hyperarousal = incident.Agitation_Hyperarousal,
                Assault_Requiring_Medical_Support = incident.Assault_Requiring_Medical_Support,
                Attempted_Minor = incident.Attempted_Minor,
                Attempted_Minor_Property_Damage = incident.Attempted_Minor_Property_Damage,
                Behaviour_or_Challenges_Attracting_Community_Concern = incident.Behaviour_or_Challenges_Attracting_Community_Concern,
                Behaviour_or_Challenges_Attracting_Media_Attention = incident.Behaviour_or_Challenges_Attracting_Media_Attention,
                ClientID = incident.ClientID,
                Client_Complaint_or_issue = incident.Client_Complaint_or_issue,
                Criminal_Behaviour_Resulting_in_Police_Engagment_or_Charges = incident.Criminal_Behaviour_Resulting_in_Police_Engagment_or_Charges,
                Disclosure_Requireing_Mandatory_Reporting= incident.Disclosure_Requireing_Mandatory_Reporting,
                Disruption_to_Routine = incident.Disruption_to_Routine,
                Heirarchy = incident.Heirarchy,
                Inappropriate_or_Anti_Social_Client_Interaction = incident.Inappropriate_or_Anti_Social_Client_Interaction,
                IncidentInvolvingFamily = incident.IncidentInvolvingFamily,
                Injury_Minor_Client_Injury_First_Aid_Only = incident.Injury_Minor_Client_Injury_First_Aid_Only,
                //L_Attempted_Minor_Property_Damage = incident.L_Attempted_Minor_Property_Damage,
                //L_Client_Complaint = incident.L_Client_Complaint,
                L_Client_Complaint_or_issue = incident.L_Client_Complaint_or_issue,
                L_Disruption_to_Routine = incident.L_Disruption_to_Routine,
                L_Has_the_client_or_guardian_been_made_aware_of_their_right_to_involve_the_police_and_potentially_press_changes = incident.L_Has_the_client_or_guardian_been_made_aware_of_their_right_to_involve_the_police_and_potentially_press_changes,
                L_Inappropriate_or_Anti_Social_Client_Interaction = incident.L_Inappropriate_or_Anti_Social_Client_Interaction,
                L_IncidentInvolvingFamily = incident.L_IncidentInvolvingFamily,
               // L_Incident_Involving_Family = incident.L_Incident_Involving_Family,
                L_Injury_Minor_Client_Injury_First_Aid_Only = incident.L_Injury_Minor_Client_Injury_First_Aid_Only,
                L_Non_Compliance_Refusal = incident.L_Non_Compliance_Refusal,
                //L_Non_Compliance_Task_Refusal = incident.L_Non_Compliance_Task_Refusal,
                //Non_Compliance_Refusal = incident.Non_Compliance_Refusal,
               // Non_Compliance_Task_Refusal = incident.Non_Compliance_Task_Refusal,
                //PRNApproved = incident.PRNApproved,
                PRN_Approved = incident.PRN_Approved,
                P_PhysicalIntervention = incident.P_PhysicalIntervention,
                Who_On_Call_Contacted = incident.Who_On_Call_Contacted
                
              
            };

            _context.NewIncidentLog.Add(NewIncedent);
            _context.SaveChanges();
        }
        public List<NewIncidentLog> getAllActiveLog()
        {
            var obj = _context.NewIncidentLog
            .FromSqlRaw("SELECT * FROM dbo.NewIncidentLog")
            .ToList();

            return obj;
        }

        public NewIncidentLog getUserById(int id)
        {
            var obj = _context.NewIncidentLog
            .FromSqlRaw("SELECT * FROM dbo.NewIncidentLog WHERE ClientID=" + id)
            .ToList();

            return obj[0];
        }
        public void UpdateIncident(NewIncidentLog model)
        {
            _context.NewIncidentLog.Update(model);
            _context.SaveChanges();
        }

        public void DeleteInceident(int id)
        {
            var incidentLog = _context.NewIncidentLog.FirstOrDefault(x => x.ClientID == id);
            if (incidentLog != null)
            {
                _context.NewIncidentLog.Remove(incidentLog);
                _context.SaveChanges();
            }
        }

        public string GetPatients()
        {
            var obj = _context.Patient.FromSqlRaw("SELECT * FROM dbo.Patient").ToList();
            var patients = JsonConvert.SerializeObject(obj);
            return patients;
        }

    }
}
