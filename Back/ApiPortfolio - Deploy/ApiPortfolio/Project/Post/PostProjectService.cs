using ApiPortfolio.Sql;
using Npgsql;

namespace ApiPortfolio.Project.Post;

public class PostProjectService
{
    public void PostProject(PostProjectModel projet)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            int idProject;
            using (var commande = new NpgsqlCommand(PostProjectQuery.QueryPostProject, connection))
            {
                commande.Parameters.AddWithValue("@title", projet.Title);
                commande.Parameters.AddWithValue("@description", projet.Description);
                commande.Parameters.AddWithValue("@githublink", projet.GithubLink);
                commande.Parameters.AddWithValue("@weblink", projet.WebLink);

                idProject = (int)commande.ExecuteScalar();
            }

            if (projet.TechnoIds != null && projet.TechnoIds.Count > 0)
            {
                foreach (var idTechno in projet.TechnoIds)
                {
                    using (var commande = new NpgsqlCommand(PostProjectQuery.QueryPostTechno, connection))
                    {
                        commande.Parameters.AddWithValue("@idproject", idProject);
                        commande.Parameters.AddWithValue("@idtechno", idTechno);
                        commande.ExecuteNonQuery();
                    }
                }
            }

            if (projet.ImageIds != null && projet.ImageIds.Count > 0)
            {
                foreach (var idImage in projet.ImageIds)
                {
                    using (var commande = new NpgsqlCommand(PostProjectQuery.QueryPostImage, connection))
                    {
                        commande.Parameters.AddWithValue("@idproject", idProject);
                        commande.Parameters.AddWithValue("@idimage", idImage);
                        commande.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
