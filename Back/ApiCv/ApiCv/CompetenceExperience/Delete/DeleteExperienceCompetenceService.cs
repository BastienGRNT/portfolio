using ApiCv.Sql;
using Npgsql;

namespace ApiCv.CompetenceExperience.Delete;

public class DeleteExperienceCompetenceService
{
    public void DeleteExperienceCompetence(int competenceExperienceId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteExperienceCompetenceQuery.DeleteExperienceCompetence;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@competenceexperienceid", competenceExperienceId);
                commande.ExecuteNonQuery();
            }
        }
    }
}