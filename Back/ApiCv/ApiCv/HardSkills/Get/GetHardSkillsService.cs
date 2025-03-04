using ApiCv.Sql;
using Npgsql;

namespace ApiCv.HardSkills.Get;

public class GetHardSkillsService
{
    public List<GetHardSkillsModele> GetHardSkills()
    {
        var hardSkills = new List<GetHardSkillsModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetHardSkillsQuery.QueryGetHardSkills;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    hardSkills.Add(new GetHardSkillsModele
                    {
                        HardSkillId = reader.GetInt32(reader.GetOrdinal("HardSkillId")),
                        Nom = reader.GetString(reader.GetOrdinal("Nom"))
                    });
                }
            }
        }

        return hardSkills;
    }
}