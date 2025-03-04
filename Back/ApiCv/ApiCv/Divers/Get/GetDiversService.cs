using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Divers.Get;

public class GetDiversService
{
    public List<GetDiversModele> GetDivers()
    {
        var divers = new List<GetDiversModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetDiversQuery.QueryGetDivers;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    divers.Add(new GetDiversModele
                    {
                        DiversId = reader.GetInt32(reader.GetOrdinal("DiversId")),
                        Description = reader.GetString(reader.GetOrdinal("Description"))
                    });
                }
            }
        }

        return divers;
    }
}