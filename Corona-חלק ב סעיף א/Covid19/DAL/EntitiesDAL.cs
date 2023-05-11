using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EntitiesDAL
    {
        //קבלת רשימת כל היישיות
        public static List<entities> getAll()
        {
            using (Covid19Entities db = new Covid19Entities())
            {
                try
                {
                    return db.entities.ToList();

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }



        //הוספת יישות חדשה
        public static bool AddNew(entities e)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {
                    if (e != null)
                    {
                        db.entities.Add(e);
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



    }
}
