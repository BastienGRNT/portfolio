using System;
using System.Collections.Generic;
using ApiPortfolio.Sql;
using Npgsql;

namespace ApiPortfolio.File.Techno.Get;

public class GetTechnoService
{
    public List<GetTechnoModel> GetAllTechnos()
    {
        var technos = new List<GetTechnoModel>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(GetTechnoQuery.QueryGetAllTechnos, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    technos.Add(new GetTechnoModel
                    {
                        IdUploadTechno = reader.GetInt32(reader.GetOrdinal("IdUploadTechno")),
                        Name = reader.GetString(reader.GetOrdinal("Name")),
                        Extension = reader.GetString(reader.GetOrdinal("Extension")),
                        FinalName = reader.GetString(reader.GetOrdinal("FinalName")),
                        FinalPath = reader.GetString(reader.GetOrdinal("FinalPath")),
                        FullPath = reader.GetString(reader.GetOrdinal("FullPath")),
                        HttpPath = reader.GetString(reader.GetOrdinal("HttpPath"))
                    });
                }
            }
        }
        return technos;
    }
}