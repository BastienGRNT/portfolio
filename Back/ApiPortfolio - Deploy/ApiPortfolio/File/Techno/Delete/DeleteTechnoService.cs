using ApiPortfolio.Sql;
using Npgsql;
using System;

namespace ApiPortfolio.File.Techno.Delete;

public class DeleteTechnoService
{
    public bool DeleteTechnoByName(string name)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(DeleteTechnoQuery.QueryDeleteTechnoByName, connection))
            {
                command.Parameters.AddWithValue("@name", name);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0; // True si une ligne a été supprimée, sinon False
            }
        }
    }
}