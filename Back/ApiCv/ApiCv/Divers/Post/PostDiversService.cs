using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Divers.Post;

public class PostDiversService
{
    public void PostDivers(PostDiversModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostDiversQuery.QueryPostDivers;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@description", data.Description);
                commande.ExecuteNonQuery();
            }
        }
    }
}