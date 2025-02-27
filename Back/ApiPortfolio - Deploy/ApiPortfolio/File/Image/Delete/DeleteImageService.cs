using ApiPortfolio.Sql;
using Npgsql;
using System;

namespace ApiPortfolio.File.Image.Delete;

public class DeleteImageService
{
    public bool DeleteImageByName(string name)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(DeleteImageQuery.QueryDeleteImageByName, connection))
            {
                command.Parameters.AddWithValue("@name", name);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // True si une ligne a été supprimée, sinon False
            }
        }
    }
}