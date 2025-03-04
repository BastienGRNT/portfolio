using ApiCv.Sql;
using Npgsql;

namespace ApiCv.CentresInteret.Get;

public class GetCentreInteretService
{
    public List<GetCentreInteretModele> GetCentreInteret()
    {
        var centreInteret = new List<GetCentreInteretModele>();
        
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetCentreInteretQuery.CentreInteretQuery;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    centreInteret.Add(new GetCentreInteretModele
                    {
                        IdCentreInteret = reader.GetInt32(reader.GetOrdinal("centreinteretid")),
                        Nom = reader.GetString(reader.GetOrdinal("Nom")),
                    });
                }
            }
        }
        
        return centreInteret;
    }
}