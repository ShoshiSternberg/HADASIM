using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class ManufacturerDAL
    {

        //קבלת רשימת כל היצרנים
        public static List<manufacturer> getAll()
        {
            using (Covid19Entities db = new Covid19Entities())
            {
                try
                {
                    return db.manufacturer.ToList();

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }




        //הוספת יצרן חדש
        public static bool AddNew(manufacturer m)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {
                    if (m != null)
                    {
                        db.manufacturer.Add(m);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }


        //המרת קוד יצרן לשם יצרן
        public static string getnamemanufacturer(int idmanufacturer)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {
                    return db.manufacturer.FirstOrDefault(p => p.manufacturer_id == idmanufacturer).manufacturer_name;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
