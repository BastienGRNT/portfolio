﻿using ApiPortfolio.Sql;
using Npgsql;
using System.Collections.Generic;

namespace ApiPortfolio.Project.Put;

public class PutProjectService
{
    public bool UpdateProject(int idProject, PutProjectModel projet)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            using (var command = new NpgsqlCommand(PutProjectQuery.QueryUpdateProject, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);
                command.Parameters.AddWithValue("@title", projet.Title);
                command.Parameters.AddWithValue("@description", projet.Description);
                command.Parameters.AddWithValue("@githublink", projet.GithubLink);
                command.Parameters.AddWithValue("@weblink", projet.WebLink);
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                    return false;
            }

            using (var command = new NpgsqlCommand(PutProjectQuery.QueryDeleteProjectTechno, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);
                command.ExecuteNonQuery();
            }

            if (projet.TechnoIds != null)
            {
                using (var command = new NpgsqlCommand(PutProjectQuery.QueryDeleteProjectTechno, connection))
                {
                    command.Parameters.AddWithValue("@idProject", idProject);
                    command.ExecuteNonQuery();
                }

                foreach (var idTechno in projet.TechnoIds)
                {
                    using (var command = new NpgsqlCommand(PutProjectQuery.QueryInsertProjectTechno, connection))
                    {
                        command.Parameters.AddWithValue("@idProject", idProject);
                        command.Parameters.AddWithValue("@idTechno", idTechno);
                        command.ExecuteNonQuery();
                    }
                }
            }

            if (projet.ImageIds != null)
            {
                using (var command = new NpgsqlCommand(PutProjectQuery.QueryDeleteProjectImage, connection))
                {
                    command.Parameters.AddWithValue("@idProject", idProject);
                    command.ExecuteNonQuery();
                }

                foreach (var idImage in projet.ImageIds)
                {
                    using (var command = new NpgsqlCommand(PutProjectQuery.QueryInsertProjectImage, connection))
                    {
                        command.Parameters.AddWithValue("@idProject", idProject);
                        command.Parameters.AddWithValue("@idImage", idImage);
                        command.ExecuteNonQuery();
                    }
                }
            }


            return true;
        }
    }
}
