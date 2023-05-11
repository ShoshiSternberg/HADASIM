using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class VaccinatedBLL
    {
        //החזרת כל המתחסנים
        public static List<VaccinatedDTO> GetAllVaccinated()
        {
            try
            {
                return VaccinatedDTO.toDTO_List(VaccinatedDAL.getAll());
            }
            catch (Exception e)
            {
                throw;
            }

        }
        //קבלת רשימת כל המחוסנים
        public static List<List<dynamic>> GetVaccinatedwithManufacturername()
        {
            var vaccinateds = VaccinatedDTO.toDTO_List(VaccinatedDAL.getAll());
            List<List<dynamic>> vaccinatednamic = new List<List<dynamic>>();
            foreach (var item in vaccinateds)
            {
                List<dynamic> indynamic = new List<dynamic>();
                indynamic.Add(item.datails_id);
                indynamic.Add(item.entity_id);
                string vaccinename = VaccineBLL.getnameVaccine(item.vaccine_id);
                indynamic.Add(vaccinename);
                indynamic.Add(item.receiving_date);

                vaccinatednamic.Add(indynamic);
            }
            return vaccinatednamic;
        }

        //הוספת רשומה לטבלת מתחסנים 
        public static bool AddNewVaccinated(int entity_id, int vaccine_id, DateTime receiving_date)
        {
            try
            {
                VaccinatedDTO NewaddNewEntity = new VaccinatedDTO(entity_id,vaccine_id,receiving_date);
                return VaccinatedDAL.AddNew(VaccinatedDTO.toVaccinatedTBL(NewaddNewEntity));
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
