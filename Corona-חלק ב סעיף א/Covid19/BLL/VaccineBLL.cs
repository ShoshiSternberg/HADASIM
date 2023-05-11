using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class VaccineBLL
    {
        //החזרת כל החיסונים
        public static List<VaccineDTO> GetAllVaccine()
        {
            try
            {
                return VaccineDTO.toDTO_List(VaccineDAL.getAll());
            }
            catch (Exception e)
            {
                throw;
            }

        }


        //יצרית רשימה
        public static List<VaccineDTO> ListModel = new List<VaccineDTO>();

        //החזרת כל רשימת המוצרים
        public static List<VaccineDTO> GetAllModelList()
        {
            try
            {
                return ListModel;
            }
            catch (Exception e)
            {

                return null;
            }
        }

        //קבלת רשימת כל ההמנה
        //קבלת רשימת כל המוצרים
        public static List<List<dynamic>> GetVaccinewithManufacturername()
        {
            var vaccines = VaccineDTO.toDTO_List(VaccineDAL.getAll());
            List<List<dynamic>> vaccinesynamic = new List<List<dynamic>>();
            foreach (var item in vaccines)
            {
                List<dynamic> indynamic = new List<dynamic>();
                indynamic.Add(item.vaccine_id);
                indynamic.Add(item.name_vaccine);
                string kategoryname = ManutfacturerBLL.getnamemanufacturer(item.manufacturer_id);
                indynamic.Add(kategoryname);
                indynamic.Add(item.count_vaccine);
                indynamic.Add(item.manufacturing_date);
                indynamic.Add(item.expiry_date);


                vaccinesynamic.Add(indynamic);
            }
            return vaccinesynamic;
        }

        //הוספת רשומה לטבלת חיסונים 
        public static bool AddNewVaccine(string name_vaccine, int manufacturer_id, int count_vaccine, DateTime manufacturing_date, DateTime expiry_date)
        {
            try
            {
                VaccineDTO NewaddNewEntity = new VaccineDTO(name_vaccine,manufacturer_id, count_vaccine, manufacturing_date, expiry_date);
                return VaccineDAL.AddNew(VaccineDTO.toVaccineTBL(NewaddNewEntity));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        //המרת קוד חיסון לשם חיסון
        public static string getnameVaccine(int vaccine_id)
        {
            return VaccineDAL.getnameVaccine(vaccine_id);
        }
    }
}
