using System.Runtime.InteropServices.JavaScript;
using ApiCv.Sql;
using Npgsql;

namespace ApiCv.CentresInteret.Delete;

public class DeleteCentreInteretService
{
    public void DeleteCentreInteret(int id)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteCentreInteretQuery.DeleteCentreInteret;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@centreinteret", id);
                commande.ExecuteNonQuery();
            }

        }
    }
}