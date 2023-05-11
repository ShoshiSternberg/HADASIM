using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class VaccinatedDTO
    {
        public int datails_id { get; set; }
        public int entity_id { get; set; }
        public int vaccine_id { get; set; }
        public DateTime receiving_date { get; set; }

        public VaccinatedDTO()
        {

        }

        public VaccinatedDTO(int entity_id, int vaccine_id, DateTime receiving_date)
        {
            this.entity_id = entity_id;
            this.vaccine_id = vaccine_id;
            this.receiving_date = receiving_date;
        }

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static vaccinated toVaccinatedTBL(VaccinatedDTO vc)
        {
            vaccinated newv = new vaccinated();
            newv.datails_id = vc.datails_id;
            newv.entity_id = vc.entity_id;
            newv.vaccine_id = vc.vaccine_id;
            newv.receiving_date = vc.receiving_date;

            return newv;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static VaccinatedDTO toVaccinatedDTO(vaccinated vc)
        {
            VaccinatedDTO newv = new VaccinatedDTO();
            newv.datails_id = vc.datails_id;
            newv.entity_id = vc.entity_id;
            newv.vaccine_id = vc.vaccine_id;
            newv.receiving_date = vc.receiving_date;

            return newv;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<VaccinatedDTO> toDTO_List(List<vaccinated> pr)
        {
            List<VaccinatedDTO> pList = new List<VaccinatedDTO>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toVaccinatedDTO(item));
                }
                return pList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<vaccinated> toTBL_List(List<VaccinatedDTO> pr)
        {
            List<vaccinated> pList = new List<vaccinated>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toVaccinatedTBL(item));
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
