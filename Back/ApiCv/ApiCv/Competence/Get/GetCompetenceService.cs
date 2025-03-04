using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Competence.Get;

public class GetCompetenceService
{
    public List<GetCompetenceModele> GetCompetence()
    {
        var competences = new List<GetCompetenceModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetCompetenceQuery.QueryGetCompetence;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    competences.Add(new GetCompetenceModele
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("id")),
                        Nom = reader.GetString(reader.GetOrdinal("Nom")),
                        Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"))
                    });
                }
            }
        }

        return competences;
    }
}