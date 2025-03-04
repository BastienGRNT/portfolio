using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Competence.Post;

public class PostCompetenceService
{
    public void PostCompetence(PostCompetenceModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostCompetenceQuery.QueryPostCompetence;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@nom", data.Nom);
                commande.Parameters.AddWithValue("@description", (object)data.Description ?? DBNull.Value);
                commande.ExecuteNonQuery();
            }
        }
    }
}