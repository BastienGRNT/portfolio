using ApiCv.Sql;
using Npgsql;

namespace ApiCv.CentresInteret.Post;

public class PostCentreInteretService
{
    public void PostCentreInteret(PostCentreInteretModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostCentreInteretQuery.QueryPostCentreInteret;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@nom", data.Nom);

                commande.ExecuteNonQuery();
            }
        }
    }
}