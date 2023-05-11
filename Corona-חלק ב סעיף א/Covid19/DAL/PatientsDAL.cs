using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PatientsDAL
    {

        //קבלת רשימת כל החולים
        public static List<patients> getAll()
        {
            using (Covid19Entities db = new Covid19Entities())
            {
                try
                {
                    return db.patients.ToList();

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }




        //הוספת חולה חדש
        public static bool AddNew(patients p)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {
                    if (p != null)
                    {
                        db.patients.Add(p);
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
