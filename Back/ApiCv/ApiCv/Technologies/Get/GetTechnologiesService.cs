using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Technologies.Get;

public class GetTechnologiesService
{
    public List<GetTechnologiesModele> GetTechnologies()
    {
        var technologies = new List<GetTechnologiesModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetTechnologiesQuery.QueryGetTechnologies;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    technologies.Add(new GetTechnologiesModele
                    {
                        TechnologieId = reader.GetInt32(reader.GetOrdinal("TechnologieID")),
                        Nom = reader.GetString(reader.GetOrdinal("Nom")),
                        IconePath = reader.GetString(reader.GetOrdinal("IconePath"))
                    });
                }
            }
        }

        return technologies;
    }
}