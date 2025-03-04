using ApiCv.Sql;
using Npgsql;

namespace ApiCv.HardSkills.Delete;

public class DeleteHardSkillsService
{
    public void DeleteHardSkills(int hardSkillId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteHardSkillsQuery.DeleteHardSkills;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@hardskillid", hardSkillId);
                commande.ExecuteNonQuery();
            }
        }
    }
}