using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class PatientsBLL
    {
        //החזרת כל החולים
        public static List<PatientsDTO> GetAllPatients()
        {
            try
            {
                return PatientsDTO.toDTO_List(PatientsDAL.getAll());
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //הוספת רשומה לטבלת חברים 
        public static bool AddNewPatients(int entity_id, DateTime positve_date, DateTime recovery_date)
        {
            try
            {
                PatientsDTO NewaddNewPatients = new PatientsDTO(entity_id, positve_date,recovery_date);
                return PatientsDAL.AddNew(PatientsDTO.toPatientsTBL(NewaddNewPatients));
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
