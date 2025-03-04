using ApiCv.Sql;
using Npgsql;

namespace ApiCv.CompetenceExperience.Get;

public class GetExperienceCompetenceService
{
    public List<GetExperienceCompetenceModele> GetExperienceCompetence()
    {
        var competenceExperiences = new List<GetExperienceCompetenceModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetExperienceCompetenceQuery.QueryGetExperienceCompetence;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    competenceExperiences.Add(new GetExperienceCompetenceModele
                    {
                        CompetenceExperienceId = reader.GetInt32(reader.GetOrdinal("CompetenceExperienceId")),
                        Competence = reader.GetString(reader.GetOrdinal("Competence")),
                        ExperienceId = reader.GetInt32(reader.GetOrdinal("ExperienceId"))
                    });
                }
            }
        }

        return competenceExperiences;
    }
}