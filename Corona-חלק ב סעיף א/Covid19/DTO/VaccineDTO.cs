using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
   public class VaccineDTO
    {
        public int vaccine_id { get; set; }
        public string name_vaccine { get; set; }
        public int manufacturer_id { get; set; }
        public int count_vaccine { get; set; }
        public DateTime manufacturing_date { get; set; }
        public DateTime expiry_date { get; set; }

        public VaccineDTO()
        {

        }

        public VaccineDTO( string name_vaccine, int manufacturer_id, int count_vaccine, DateTime manufacturing_date, DateTime expiry_date)
        {
            //this.vaccine_id= vaccine_id;
            this.name_vaccine = name_vaccine;
            this.manufacturer_id = manufacturer_id;
            this.count_vaccine = count_vaccine;
            this.manufacturing_date = manufacturing_date;
            this.expiry_date = expiry_date;

        }


        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static vaccine toVaccineTBL(VaccineDTO vm)
        {
            vaccine newv = new vaccine();
            newv.vaccine_id = vm.vaccine_id;
            newv.name_vaccine = vm.name_vaccine;
            newv.manufacturer_id = vm.manufacturer_id;
            newv.count_vaccine = vm.count_vaccine;
            newv.manufacturing_date = vm.manufacturing_date;
            newv.expiry_date = vm.expiry_date;
            return newv;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static VaccineDTO toVaccineDTO(vaccine vm)
        {
            VaccineDTO newv = new VaccineDTO();
            newv.vaccine_id = vm.vaccine_id;
            newv.name_vaccine = vm.name_vaccine;
            newv.manufacturer_id = vm.manufacturer_id;
            newv.count_vaccine = vm.count_vaccine;
            newv.manufacturing_date = (DateTime)vm.manufacturing_date;
            newv.expiry_date = (DateTime)vm.expiry_date;


            return newv;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<VaccineDTO> toDTO_List(List<vaccine> va)
        {
            List<VaccineDTO> pList = new List<VaccineDTO>();
            try
            {
                foreach (var item in va)
                {
                    pList.Add(toVaccineDTO(item));
                }
                return pList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<vaccine> toTBL_List(List<VaccineDTO> va)
        {
            List<vaccine> pList = new List<vaccine>();
            try
            {
                foreach (var item in va)
                {
                    pList.Add(toVaccineTBL(item));
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
