//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.IO;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.IO;
//using System.Windows.Forms;
//namespace DAL
//{
//    public class Load_Image
//    {

//        //הכנסת התמונה לdatabase
//        public static void UploadImageToDatabase(string imagePath, string connectionString)
//        {
//            connectionString = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient";
//            imagePath = "C://Users//user1//Desktop//Hadasim2//Twitter towersחלק א'-//images.jpg";
//            // Read the image file into a byte array
//            byte[] imageData;
//            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
//            {
//                imageData = new byte[fs.Length];
//                fs.Read(imageData, 0, (int)fs.Length);
//            }

//            // Establish a database connection
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Create a SQL command to insert the image data into the table
//                string insertQuery = "INSERT INTO entities (image_person) VALUES (@imageData)";
//                using (SqlCommand command = new SqlCommand(insertQuery, connection))
//                {
//                    // Set the image data parameter
//                    command.Parameters.AddWithValue("@imageData", imageData);

//                    // Execute the SQL command
//                    command.ExecuteNonQuery();
//                }

//                // Close the database connection
//                connection.Close();
//            }
//        }


//        //טעינת התמונה מהdatabse
//        public static Image LoadImageFromDatabase(int imageId, string connectionString)
//        {
//            byte[] imageData;

//            // Establish a database connection
//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                connection.Open();

//                // Create a SQL command to retrieve the image data from the table
//                string selectQuery = "SELECT image_person FROM entities WHERE ImageId = @imageId";
//                using (SqlCommand command = new SqlCommand(selectQuery, connection))
//                {
//                    // Set the image ID parameter
//                    command.Parameters.AddWithValue("@imageId", imageId);

//                    // Execute the SQL command and retrieve the image data
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        if (reader.Read())
//                        {
//                            // Get the image data from the database
//                            imageData = (byte[])reader["ImageData"];
//                        }
//                        else
//                        {
//                            // Handle the case when the image is not found
//                            // For example, display a placeholder image
//                            return null;
//                        }
//                    }
//                }

//                // Close the database connection
//                connection.Close();
//            }

//            // Create a MemoryStream and write the image data to it
//            using (MemoryStream stream = new MemoryStream(imageData))
//            {
//                // Create a Bitmap or Image object from the MemoryStream
//                Image image = Image.FromStream(stream);

//                // Return the loaded image
//                return image;
//            }
//        }


//    }
//}
