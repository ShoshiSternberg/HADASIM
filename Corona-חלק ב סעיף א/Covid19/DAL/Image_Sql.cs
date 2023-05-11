//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.SqlClient;
//using System.IO;
//using System.Security.Cryptography;
//namespace DAL
//{
//    class Image_Sql
//    {
//public void AddImagesToTable(string folderPath)
//    {
//        string connectionString = "DESKTOP-VM033JO/MSSQLSERVER01/Covid19";
//        int idEvent = 21;

//        // Connect to the database
//        using (SqlConnection conn = new SqlConnection(connectionString))
//        {
//            conn.Open();

//            using (SqlCommand command = conn.CreateCommand())
//            {
//                // Iterate through files in the folder
//                foreach (string fileName in Directory.GetFiles(folderPath))
//                {
//                    string filePath = Path.Combine(folderPath, fileName);

//                    // Check if the file is an image
//                    if (File.Exists(filePath) && IsImageFile(filePath))
//                    {
//                        // Generate MD5 hash for the image file
//                        byte[] imageData = File.ReadAllBytes(filePath);
//                        string imageHash = GetMD5Hash(imageData);

//                        // Insert the image path and hash into the table
//                        string insertQuery = "INSERT INTO [EventImage] (idEvents, Image_path) VALUES (@idEvent, @imageHash)";
//                        command.CommandText = insertQuery;
//                        command.Parameters.Clear();
//                        command.Parameters.AddWithValue("@idEvent", idEvent);
//                        command.Parameters.AddWithValue("@imageHash", imageHash);
//                        command.ExecuteNonQuery();
//                    }
//                }
//            }

//            // Close the database connection
//            conn.Close();
//        }
//    }

//    private bool IsImageFile(string filePath)
//    {
//        string extension = Path.GetExtension(filePath).ToLower();
//        string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".jpg" };
//        return validExtensions.Contains(extension);
//    }

//    private string GetMD5Hash(byte[] data)
//    {
//        using (MD5 md5 = MD5.Create())
//        {
//            byte[] hashBytes = md5.ComputeHash(data);
//            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
//        }
//    }

//}
//}
