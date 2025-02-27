﻿using ApiPortfolio.Sql;
using Npgsql;
using System;
using System.Collections.Generic;

namespace ApiPortfolio.Project.Get;

public class GetProjectService
{
    public GetProjectModel GetProjectById(int idProject)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(GetProjectQuery.QueryGetProjectById, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new GetProjectModel
                        {
                            IdProject = reader.GetInt32(reader.GetOrdinal("IdProject")),
                            Title = reader.GetString(reader.GetOrdinal("Title")),
                            Description = reader.GetString(reader.GetOrdinal("Description")),
                            GithubLink = reader.GetString(reader.GetOrdinal("GithubLink")),
                            WebLink = reader.GetString(reader.GetOrdinal("WebLink")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                            ImagePaths = reader.IsDBNull(reader.GetOrdinal("ImagePaths")) 
                                ? new List<string>() 
                                : reader.GetFieldValue<string[]>(reader.GetOrdinal("ImagePaths")).ToList(),
                            TechnoPaths = reader.IsDBNull(reader.GetOrdinal("TechnoPaths")) 
                                ? new List<string>() 
                                : reader.GetFieldValue<string[]>(reader.GetOrdinal("TechnoPaths")).ToList()
                        };
                    }
                }
            }
        }
        return null; // Retourne null si aucun projet n'est trouvé
    }

    public List<GetProjectModel> GetAllProjects()
    {
        var projects = new List<GetProjectModel>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(GetProjectQuery.QueryGetAllProjects, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    projects.Add(new GetProjectModel
                    {
                        IdProject = reader.GetInt32(reader.GetOrdinal("IdProject")),
                        Title = reader.GetString(reader.GetOrdinal("Title")),
                        Description = reader.GetString(reader.GetOrdinal("Description")),
                        GithubLink = reader.GetString(reader.GetOrdinal("GithubLink")),
                        WebLink = reader.GetString(reader.GetOrdinal("WebLink")),
                        CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                        UpdatedAt = reader.GetDateTime(reader.GetOrdinal("UpdatedAt")),
                        ImagePaths = reader.IsDBNull(reader.GetOrdinal("ImagePaths")) 
                            ? new List<string>() 
                            : reader.GetFieldValue<string[]>(reader.GetOrdinal("ImagePaths")).ToList(),
                        TechnoPaths = reader.IsDBNull(reader.GetOrdinal("TechnoPaths")) 
                            ? new List<string>() 
                            : reader.GetFieldValue<string[]>(reader.GetOrdinal("TechnoPaths")).ToList()
                    });
                }
            }
        }
        return projects;
    }
}
