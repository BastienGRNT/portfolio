using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Divers.Delete;

public class DeleteDiversService
{
    public void DeleteDivers(int diversId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteDiversQuery.DeleteDivers;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@diversid", diversId);
                commande.ExecuteNonQuery();
            }
        }
    }
}