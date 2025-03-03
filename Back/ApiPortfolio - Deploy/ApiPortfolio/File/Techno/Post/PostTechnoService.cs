using System.Xml.Schema;
using ApiPortfolio.Sql;
using Npgsql;
using System.IO;

namespace ApiPortfolio.File.Techno.Post;

public class PostTechnoService
{
    public void PostTechno(PostTechnoModel techno)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            string pathVps = PostTechnoQuery.pathVps;
            string pathHttp = PostTechnoQuery.pathHttp;

            var uniqueId = Guid.NewGuid().ToString();

            var technoModel = new TechnoModel
            {
                Name = techno.Name,
                Extension = Path.GetExtension(techno.File.FileName),
                FinalName = uniqueId + Path.GetExtension(techno.File.FileName),
                FinalPath = uniqueId + Path.GetExtension(techno.File.FileName),
                FullPath = pathVps + uniqueId + Path.GetExtension(techno.File.FileName),
                HttpPath = pathHttp + uniqueId + Path.GetExtension(techno.File.FileName)
            };

            Console.WriteLine($"{pathVps}");
            Console.WriteLine($"Path: {technoModel.FullPath}");
            
            
            if (!Directory.Exists(pathVps))
            {
                Directory.CreateDirectory(pathVps);
            }

            using (var fileStream = new FileStream(technoModel.FullPath, FileMode.Create))
            {
                techno.File.CopyTo(fileStream);
            }

            string query = PostTechnoQuery.QueryPostTechno;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@name", technoModel.Name);
                commande.Parameters.AddWithValue("@extension", technoModel.Extension);
                commande.Parameters.AddWithValue("@finalName", technoModel.FinalName);
                commande.Parameters.AddWithValue("@finalPath", technoModel.FinalPath);
                commande.Parameters.AddWithValue("@fullPath", technoModel.FullPath);
                commande.Parameters.AddWithValue("@httpPath", technoModel.HttpPath);

                commande.ExecuteNonQuery();
            }
        }
    }
}
