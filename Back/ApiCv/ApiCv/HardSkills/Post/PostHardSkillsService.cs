using ApiCv.Sql;
using Npgsql;

namespace ApiCv.HardSkill.Post;

public class PostHardSkillsService
{
    public void PostHardSkills(PostHardSkillsModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostHardSkillsQuery.QueryPostHardSkills;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@nom", data.Nom);
                commande.ExecuteNonQuery();
            }
        }
    }
}