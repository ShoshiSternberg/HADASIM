using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class EntitiesDTO
    {
        public int entity_id { get; set; }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string phone { get; set; }
        public string cell_phone { get; set; }
        public bool employee { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public int street_num { get; set; }


        public EntitiesDTO()
        {

        }

        public EntitiesDTO(int entity_id,string first_name, string last_name, DateTime birth_date, string phone, string cell_phone, bool employee, string city, string street, int street_num)
        {
            this.entity_id= entity_id;
            this.first_name = first_name;
            this.last_name = last_name;
            this.birth_date = birth_date;
            this.phone = phone;
            this.cell_phone = cell_phone;
            this.employee = employee;
            this.city = city;
            this.street = street;
            this.street_num = street_num;
        }

        //פונקצית המרת אוביקט שלנו לשל מיקרוסופט - משמש בהוספת אוביקט חדש למסד
        public static entities toEntitiesTBL(EntitiesDTO em)
        {
            entities newe = new entities();
            newe.entity_id = em.entity_id;
            newe.first_name = em.first_name;
            newe.last_name = em.last_name;
            newe.birth_date = em.birth_date;
            newe.phone = em.phone;
            newe.cell_phone = em.cell_phone;
            newe.employee = em.employee;
            newe.city = em.city;
            newe.street = em.street;
            newe.street_num = em.street_num;

            return newe;
        }


        //פונקצית המרת אוביקט מיקרוסופט  לשלנו- משמש בשליפת אוביקט 
        public static EntitiesDTO toEntitiesDTO(entities em)
        {
            EntitiesDTO newe = new EntitiesDTO();
            newe.entity_id = em.entity_id;
            newe.first_name = em.first_name;
            newe.last_name = em.last_name;
            newe.birth_date = (DateTime)em.birth_date;
            newe.phone = em.phone;
            newe.cell_phone = em.cell_phone;
            newe.employee = (bool)em.employee;
            newe.city = em.city;
            newe.street = em.street;
            newe.street_num = (int)em.street_num;

            return newe;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<EntitiesDTO> toDTO_List(List<entities> pr)
        {
            List<EntitiesDTO> pList = new List<EntitiesDTO>();
            try
            {
                foreach (var item in pr)
                {   if(pr!=null)
                    pList.Add(toEntitiesDTO(item));
                }
                return pList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<entities> toTBL_List(List<EntitiesDTO> pr)
        {
            List<entities> pList = new List<entities>();
            try
            {
                foreach (var item in pr)
                {
                    pList.Add(toEntitiesTBL(item));
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

