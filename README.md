# HADASIM
פרויקט של אילה דמארי
בס"ד 
הפרויקט:
צד שרת: c# (מודל 3 השכבות).

צד לקוח: . JavaScript ,Css ,Html

מסד נתונים: Sql.

מסד הנתונים מצורף בתיקיית הפרויקט ונקרא Covid19

יש לפתוח Sql  לקרוא למסד באותו השם ואז להריץ(בקוד שזה פתוח עליו).

אז איך מתקינים את הפרויקט?

בפרויקט הDAL -  יש קובץ config  שנקרא App.config
![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/df58892b-6cab-4158-8031-bb344194306c)
	פתח אותו.

	חפש את תגית ה-connectionString.

	מחק אותה/את המוכל בתוכה.

	עמוד על פרויקט הDAL  

	לחיצה ימנית.

	לחץ על ADD

	לחץ על new item

![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/e9df21d8-e8b1-441e-a487-97c17ac83019)

	 לחץ על data.

	לחץ על ADD.

	לחץ עלNEXT.

	לחץ על NEWCONNECTION.

	בSERVERNAME-את שם ה-Sql (נמצא בלחיצה ימנית על ה-Sql ולחיצה על connect

	לבחור את שם המסד בconnect to database.

	לחץ על Advence.

	לחץ על next

	בחר table

	לחץ על finish.

	לחץ על yestoall

	פתח את הקובץ App.config הנ"ל

	העתק את המחרוזת קישור-connection string

	הדבק בפרויקט webProgram   בקובץ שנקרא webconfig(במידה ויש שם מחרוזת קישור החלף אותה בזו.)

	הרץ שרת ב ![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/d7cfdc33-3696-478c-b4e3-5a86c14ddcea)

	פתח את הפרויקט דרך התיקיה ולא דרך הפרויקט הפתוח.

	פתח בwebprogram.

	פתח את תיקיית Html.

	פתח בmicrosoft את הadmin_login

	הכנס את תהודת זהות המנהל:325562221

	הכנס מייל direct.
בכל דף יש סרגל המאפשר ניתוב בין בדפים:
מראה הסרגל:
 ![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/9286a9b8-387c-4e5f-b622-3f861c8868bc)

תקציר לפרויקט
יצרתי 3 תיקיות בתיקיית הפרויקט WEBPOGRAM HTML,CSS,JAVASCRIPT:  המכילים את עמודי הפרויקט.
בהם שמרתי את הפרויקט
כדי לראות את הפרויקט יש לפתוח את התיקיה Html  .
 מסכים:
מסך כניסת מנהל המערכת:
 ![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/e60226c6-88ad-4c61-99fd-1041fdbea938)

בכל דף במערכת יש אפשרויות:
1.שליפת הנתונים מהמסד והצגתם למנהל.
1.חיפוש(על פני כל העמודות).
2.הוספה
באם המשתמש מכניס נתונים שגויים עשיתי גם קודי בדיקות תקינות. לדוגמא: בדיקת תעודת זהות, בדיקת מספר פלאפון, בדיקת כמות, וכו'.
בדף חיסונים מתבצעת בדיקת כמות חיסונים אם החבר בקופת החולים ביצע 4 חיסונים תוצג הודעה על המסך ולא יהיה אפשרות להוסיף ולבצע חיסון נוסף.
דוגמא לדף:
דף patients:
דף מחוסני קופת החולים :
 ![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/2a11ccc8-5b6e-4b96-9fbe-7b6cac3d6d07)

כתבתי פונקציה שמקורה ב bll בכדי לספק נוחות למנהל הקופה שלא יראה את הקוד חיסון אלא את שם החיסון אולם כאשר ירצה להוסיף מתחסן יהיה עליו להקיש קוד חיסון:
כפי שמוצג בטבלת המחוסנים הבאה:
 
![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/6dc122ce-648b-4a12-8325-cb463f03bee7)

בכפתור ערוך והוסף ניתן אפשרות לשכפל שורה קודמת עם שינויים שבוחרים לעשות על השורה.
שאלת בונוס
שאלה מספר 1:
הקוד :
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace DAL
{
  public  class Load_Image
    {

//הכנסת התמונה לdatabase
public static void UploadImageToDatabase(string imagePath, string connectionString)
        {
            connectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient";
            imagePath = "C://Users//user1//Desktop//Hadasim2//Twitter towersחלק א'-//images.jpg";
            // Read the image file into a byte array
            byte[] imageData;
        using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            imageData = new byte[fs.Length];
            fs.Read(imageData, 0, (int)fs.Length);
        }

        // Establish a database connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SQL command to insert the image data into the table
            string insertQuery = "INSERT INTO entities (image_person) VALUES (@imageData)";
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Set the image data parameter
                command.Parameters.AddWithValue("@imageData", imageData);

                // Execute the SQL command
                command.ExecuteNonQuery();
            }

            // Close the database connection
            connection.Close();
        }
    }
        

//טעינת התמונה מהdatabse
        public static Image LoadImageFromDatabase(int imageId, string connectionString)
    {
        byte[] imageData;

        // Establish a database connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SQL command to retrieve the image data from the table
            string selectQuery = "SELECT image_person FROM entities WHERE ImageId = @imageId";
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                // Set the image ID parameter
                command.Parameters.AddWithValue("@imageId", imageId);

                // Execute the SQL command and retrieve the image data
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Get the image data from the database
                        imageData = (byte[])reader["ImageData"];
                    }
                    else
                    {
                        // Handle the case when the image is not found
                        // For example, display a placeholder image
                        return null;
                    }
                }
            }

            // Close the database connection
            connection.Close();
        }

        // Create a MemoryStream and write the image data to it
        using (MemoryStream stream = new MemoryStream(imageData))
        {
            // Create a Bitmap or Image object from the MemoryStream
            Image image = Image.FromStream(stream);

            // Return the loaded image
            return image;
        }
    }


    }
}
בצד הלקוח יש אפשרות העלאת התמונה.
שאלה מספר 2: 
בקובץ word  נפרד שנקרא תיאור אכיטקטורה וסכמה של המסד.
 שאלה מספר 3 :
כדי להגיע לדף זה יש ללחוץ בסרגל הניווט על דוח סיכום.

 ![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/18d7e96e-38a0-48fc-bd2a-8263ac8520ef)

גרף שמתאר את כמות החולים הפעילים בחודש הקודם:
 

![image](https://github.com/ShoshiSternberg/HADASIM/assets/116339204/390b2467-d266-40e2-9ac4-cc004355e8f6)





