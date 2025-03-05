using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Etude.Post;

public class PostEtudesService
{
    public void PostEtudes(PostEtudesModele data)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = PostEtudesQuery.QueryPostEtudes;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@description", data.Description);
                commande.Parameters.AddWithValue("@titre", data.Titre);
                commande.Parameters.AddWithValue("@datedebut", data.DateDebut);
                commande.Parameters.AddWithValue("@datefin", (object)data.DateFin ?? DBNull.Value);
                commande.Parameters.AddWithValue("@lieu", data.Lieu);
                commande.ExecuteNonQuery();
            }
        }
    }
}