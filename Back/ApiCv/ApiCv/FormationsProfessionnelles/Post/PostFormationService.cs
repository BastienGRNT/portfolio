using ApiCv.Sql;
using Npgsql;

namespace ApiCv.FormationsProfessionnelles.Post;

public class PostFormationService
{
    public void PostFormation(PostFormationModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostFormationQuery.QueryPostFormation;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@nom", data.Nom);
                commande.ExecuteNonQuery();
            }
        }
    }
}