
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace DTO
{
   public class ManufacturerDTO
    {
        public int manufacturer_id { get; set; }
        public string manufacturer_name { get; set; }
        public string phone_order { get; set; }
        public ManufacturerDTO()
        {

        }

        public ManufacturerDTO(string manufacturer_name, string phone_order)
        {
            //this.manufacturer_id = manufacturer_id;
            this.manufacturer_name = manufacturer_name;
            this.phone_order = phone_order;
        }

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static manufacturer toManufacturerTBL(ManufacturerDTO mc)
        {
            manufacturer newm = new manufacturer();
            newm.manufacturer_id = mc.manufacturer_id;
            newm.manufacturer_name = mc.manufacturer_name;
            newm.phone_order = mc.phone_order;

            return newm;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static ManufacturerDTO toManufacturerDTO(manufacturer mc)
        {
            ManufacturerDTO newm = new ManufacturerDTO();
            newm.manufacturer_id = mc.manufacturer_id;
            newm.manufacturer_name = mc.manufacturer_name;
            newm.phone_order = mc.phone_order;

            return newm;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ManufacturerDTO> toDTO_List(List<manufacturer> pr)
        {
            List<ManufacturerDTO> pList = new List<ManufacturerDTO>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toManufacturerDTO(item));
                }
                return pList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<manufacturer> toTBL_List(List<ManufacturerDTO> pr)
        {
            List<manufacturer> pList = new List<manufacturer>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toManufacturerTBL(item));
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
