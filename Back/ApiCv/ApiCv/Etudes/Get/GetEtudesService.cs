using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Etudes.Get;

public class GetEtudesService
{
    public List<GetEtudesModele> GetEtudes()
    {
        var etudes = new List<GetEtudesModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetEtudesQuery.QueryGetEtudes;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    etudes.Add(new GetEtudesModele
                    {
                        EtudeId = reader.GetInt32(reader.GetOrdinal("EtudeID")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        Titre = reader.GetString(reader.GetOrdinal("Titre")),
                        DateDebut = reader.GetDateTime(reader.GetOrdinal("DateDebut")),
                        DateFin = reader.IsDBNull(reader.GetOrdinal("DateFin")) ? null : reader.GetDateTime(reader.GetOrdinal("DateFin")),
                        Lieu = reader.GetString(reader.GetOrdinal("Lieu"))
                    });
                }
            }
        }

        return etudes;
    }
}