using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace DTO
{
    public class PatientsDTO
    {
        public int patient_id { get; set; }
        public int entity_id { get; set; }
        public DateTime positve_date { get; set; }
        public DateTime recovery_date { get; set; }

        public PatientsDTO()
        {

        }

        public PatientsDTO(int entity_id, DateTime positve_date, DateTime recovery_date)
        {
            this.entity_id = entity_id;
            this.positve_date = positve_date;
            this.recovery_date = recovery_date;
        }


        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static patients toPatientsTBL(PatientsDTO pc)
        {
            patients newp = new patients();
            newp.patient_id = pc.patient_id;
            newp.entity_id = pc.entity_id;
            newp.positve_date = pc.positve_date;
            newp.recovery_date = pc.recovery_date;


            return newp;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static PatientsDTO toPatientsDTO(patients pc)
        {
            PatientsDTO newp = new PatientsDTO();
            newp.patient_id = pc.patient_id;
            newp.entity_id = pc.entity_id;
            newp.positve_date = (DateTime)pc.positve_date;
            newp.recovery_date = (DateTime)pc.recovery_date;

            return newp;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<PatientsDTO> toDTO_List(List<patients> pr)
        {
            List<PatientsDTO> pList = new List<PatientsDTO>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toPatientsDTO(item));
                }
                return pList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<patients> toTBL_List(List<PatientsDTO> pr)
        {
            List<patients> pList = new List<patients>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toPatientsTBL(item));
                }
                return pList;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
