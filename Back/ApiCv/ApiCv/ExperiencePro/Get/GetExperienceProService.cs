using ApiCv.Sql;
using Npgsql;

namespace ApiCv.ExperiencePro.Get;

public class GetExperienceProService
{
    public List<GetExperienceProModele> GetExperiencePro()
    {
        var experiences = new List<GetExperienceProModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetExperienceProQuery.QueryGetExperiencePro;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    experiences.Add(new GetExperienceProModele
                    {
                        ExperienceId = reader.GetInt32(reader.GetOrdinal("ExperienceId")),
                        Titre = reader.GetString(reader.GetOrdinal("Titre")),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                        Entreprise = reader.GetString(reader.GetOrdinal("Entreprise")),
                        DateDebut = reader.GetDateTime(reader.GetOrdinal("DateDebut")),
                        DateFin = reader.IsDBNull(reader.GetOrdinal("DateFin")) ? null : reader.GetDateTime(reader.GetOrdinal("DateFin")),
                        Competences = reader.IsDBNull(reader.GetOrdinal("Competences")) ? new List<string>() : reader.GetString(reader.GetOrdinal("Competences")).Split(',').Select(c => c.Trim()).ToList()
                    });
                }
            }
        }

        return experiences;
    }
}