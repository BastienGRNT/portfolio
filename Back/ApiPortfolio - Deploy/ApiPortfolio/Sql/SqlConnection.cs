namespace ApiPortfolio.Sql;

using System;
using Npgsql;

public class SqlConnection
{
    public static NpgsqlConnection ConnectSql()
    {
        string host = "51.83.75.252";
        string port = "5432";
        string database = "portfolio";
        string username = "bastien";
        string password = "BastienVPS2025!";

        var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password};";

        var connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}