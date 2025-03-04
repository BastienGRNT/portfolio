using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Experience.Post;

public class PostExperienceService
{
    public void PostExperience(PostExperienceModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostExperienceQuery.QueryPostExperience;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@titre", data.Titre);
                commande.Parameters.AddWithValue("@description", (object)data.Description ?? DBNull.Value);
                commande.Parameters.AddWithValue("@entreprise", data.Entreprise);
                commande.Parameters.AddWithValue("@datedebut", data.DateDebut);
                commande.Parameters.AddWithValue("@datefin", (object)data.DateFin ?? DBNull.Value);
                commande.ExecuteNonQuery();
            }
        }
    }
}