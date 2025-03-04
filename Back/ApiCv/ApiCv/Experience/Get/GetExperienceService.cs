using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Experience.Get;

public class GetExperienceService
{
    public List<GetExperienceModele> GetExperience()
    {
        var experiences = new List<GetExperienceModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetExperienceQuery.QueryGetExperience;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    experiences.Add(new GetExperienceModele
                    {
                        ExperienceId = reader.GetInt32(reader.GetOrdinal("ExperienceId")),
                        Titre = reader.GetString(reader.GetOrdinal("Titre")),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                        Entreprise = reader.GetString(reader.GetOrdinal("Entreprise")),
                        DateDebut = reader.GetDateTime(reader.GetOrdinal("DateDebut")),
                        DateFin = reader.IsDBNull(reader.GetOrdinal("DateFin")) ? null : reader.GetDateTime(reader.GetOrdinal("DateFin"))
                    });
                }
            }
        }

        return experiences;
    }
}
