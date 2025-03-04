using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Etudes.Delete;

public class DeleteEtudesService
{
    public void DeleteEtudes(int etudeId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteEtudesQuery.DeleteEtudes;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@etudeid", etudeId);
                commande.ExecuteNonQuery();
            }
        }
    }
}