using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class EntitiesBLL
    {
        //החזרת כל החברים
        public static List<EntitiesDTO> GetAllPackages()
        {
            try
            {
                return EntitiesDTO.toDTO_List(EntitiesDAL.getAll());
            }
            catch (Exception e)
            {
                throw;
            }

        }



        //הוספת רשומה לטבלת חברים 
        public static bool AddNewentity(int entity_id,string first_name, string last_name, DateTime birth_date, string phone, string cell_phone, bool employee, string city, string street, int street_num)
        {
            try
            {
                EntitiesDTO NewaddNewEntity = new EntitiesDTO(entity_id,first_name, last_name, birth_date, phone, cell_phone, employee,  city, street, street_num);
                return EntitiesDAL.AddNew(EntitiesDTO.toEntitiesTBL(NewaddNewEntity));
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
