using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VaccinatedDAL
    {

        //קבלת רשימת כל המתחסנים
        public static List<vaccinated> getAll()
        {
            using (Covid19Entities db = new Covid19Entities())
            {
                try
                {
                    return db.vaccinated.ToList();

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }



        //הוספת מתחסן חדש
        public static bool AddNew(vaccinated v)
        {
            try
            {
                using (Covid19Entities db = new Covid19Entities())
                {  if(v!=null)
                    { 
                    db.vaccinated.Add(v);
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
