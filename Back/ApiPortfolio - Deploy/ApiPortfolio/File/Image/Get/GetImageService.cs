using System;
using System.Collections.Generic;
using ApiPortfolio.Sql;
using Npgsql;

namespace ApiPortfolio.File.Image.Get;

public class GetImageService
{
    public List<GetImageModel> GetAllImages()
    {
        var images = new List<GetImageModel>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(GetImageQuery.QueryGetAllImages, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    images.Add(new GetImageModel
                    {
                        IdUploadImage = reader.GetInt32(reader.GetOrdinal("IdUploadImage")),
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
        return images;
    }
}