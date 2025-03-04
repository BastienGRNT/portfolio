using ApiCv.Sql;
using Npgsql;

namespace ApiCv.CompetenceExperience.Post;

public class PostCompetenceExperienceService
{
    public void PostCompetenceExperience(PostCompetenceExperienceModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostCompetenceExperienceQuery.QueryPostCompetenceExperience;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@competence", data.Competence);
                commande.Parameters.AddWithValue("@experienceid", data.ExperienceId);
                commande.ExecuteNonQuery();
            }
        }
    }
}