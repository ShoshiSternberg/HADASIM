using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class ManutfacturerBLL
    {
        //החזרת כל היצרנים
        public static List<ManufacturerDTO> GetAllManufacturer()
        {
            try
            {
                return ManufacturerDTO.toDTO_List(ManufacturerDAL.getAll());
            }
            catch (Exception e)
            {
                throw;
            }

        }

        //הוספת יצרן לטבלת יצרנים 
        public static bool AddNewManufacturer(string manufacturer_name, string phone_order)
        {
            try
            {
                ManufacturerDTO addNewManufacturer = new ManufacturerDTO(manufacturer_name,phone_order);
                return ManufacturerDAL.AddNew(ManufacturerDTO.toManufacturerTBL(addNewManufacturer));
            }
            catch (Exception e)
            {

                throw;
            }
        }

        //המרת קוד יצרן לשם יצרן
        public static string getnamemanufacturer(int manufacture_id)
        {
            return ManufacturerDAL.getnamemanufacturer(manufacture_id);
        }
    }
}
