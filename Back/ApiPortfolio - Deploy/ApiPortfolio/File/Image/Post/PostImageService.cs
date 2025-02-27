using System.Xml.Schema;
using ApiPortfolio.Sql;
using Npgsql;
using System.IO;

namespace ApiPortfolio.File.Image.Post;

public class PostImageService
{
    public void PostImage(PostImageModel image)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            string pathVps = PostImageQuery.pathVps;
            string pathHttp = PostImageQuery.pathHttp;

            var uniqueId = Guid.NewGuid().ToString();

            var imageModel = new ImageModel
            {
                Name = image.Name,
                Extension = Path.GetExtension(image.File.FileName),
                FinalName = uniqueId + Path.GetExtension(image.File.FileName),
                FinalPath = uniqueId + Path.GetExtension(image.File.FileName),
                FullPath = pathVps + uniqueId + Path.GetExtension(image.File.FileName),
                HttpPath = pathHttp + uniqueId + Path.GetExtension(image.File.FileName)
            };
            
            Console.WriteLine($"{pathVps}");
            Console.WriteLine($"Path: {imageModel.FullPath}");

            if (!Directory.Exists(pathVps))
            {
                Directory.CreateDirectory(pathVps);
            }
            
            using (var fileStream = new FileStream(imageModel.FullPath, FileMode.Create))
            {
                image.File.CopyTo(fileStream);
            }

            string query = PostImageQuery.QueryPostImage;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@name", imageModel.Name);
                commande.Parameters.AddWithValue("@extension", imageModel.Extension);
                commande.Parameters.AddWithValue("@finalName", imageModel.FinalName);
                commande.Parameters.AddWithValue("@finalPath", imageModel.FinalPath);
                commande.Parameters.AddWithValue("@fullPath", imageModel.FullPath);
                commande.Parameters.AddWithValue("@httpPath", imageModel.HttpPath);

                commande.ExecuteNonQuery();
            }
        }
    }
}
