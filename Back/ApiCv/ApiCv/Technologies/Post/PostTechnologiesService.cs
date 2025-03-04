using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Technologies.Post;

public class PostTechnologiesService
{
    public void PostTechnologies(PostTechnologiesModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostTechnologiesQuery.QueryPostTechnologies;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@nom", data.Nom);
                commande.Parameters.AddWithValue("@iconepath", data.IconePath);
                commande.ExecuteNonQuery();
            }
        }
    }
}