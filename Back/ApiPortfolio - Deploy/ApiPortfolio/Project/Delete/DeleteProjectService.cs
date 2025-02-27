using ApiPortfolio.Sql;
using Npgsql;

namespace ApiPortfolio.Project.Delete;

public class DeleteProjectService
{
    public bool DeleteProject(int idProject)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            string queryCheckProject = "SELECT COUNT(*) FROM Project WHERE IdProject = @idProject;";
            using (var command = new NpgsqlCommand(queryCheckProject, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);
                int count = Convert.ToInt32(command.ExecuteScalar());


                if (count == 0)
                    return false;
            }

            using (var command = new NpgsqlCommand(DeleteProjectQuery.QueryDeleteProjectTechno, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);
                command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand(DeleteProjectQuery.QueryDeleteProjectImage, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);
                command.ExecuteNonQuery();
            }

            using (var command = new NpgsqlCommand(DeleteProjectQuery.QueryDeleteProject, connection))
            {
                command.Parameters.AddWithValue("@idProject", idProject);
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}