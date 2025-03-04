using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Experience.Delete;

public class DeleteExperienceService
{
    public void DeleteExperience(int experienceId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteExperienceQuery.DeleteExperience;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@experienceid", experienceId);
                commande.ExecuteNonQuery();
            }
        }
    }
}