using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Technologies.Delete;

public class DeleteTechnologiesService
{
    public void DeleteTechnologies(int technologieId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteTechnologiesQuery.DeleteTechnologies;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@technologieid", technologieId);
                commande.ExecuteNonQuery();
            }
        }
    }
}