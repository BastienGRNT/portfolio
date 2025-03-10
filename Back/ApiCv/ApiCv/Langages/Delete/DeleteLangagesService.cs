using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Langages.Delete;

public class DeleteLangagesService
{
    public void DeleteLangage(int langageId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteLangagesQuery.QueryDeleteLangage;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@langagesid", langageId);
                commande.ExecuteNonQuery();
            }
        }
    }
}