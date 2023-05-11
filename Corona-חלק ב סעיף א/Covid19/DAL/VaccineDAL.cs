using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VaccineDAL
    {

        //קבלת רשימת כל היישיות
        public static List<vaccine> getAll()
        {
            using (Covid19Entities db = new Covid19Entities())
            {
                try
                {
                    return db.vaccine.ToList();

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }




        //הוספת חיסון חדש
        public static bool AddNew(vaccine v)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {
                    if (v != null)
                    {
                        db.vaccine.Add(v);
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

        //המרת קוד חיסון לשם חיסון
        public static string getnameVaccine(int idvaccine)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {
                    return db.vaccine.FirstOrDefault(p => p.vaccine_id == idvaccine).name_vaccine;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
