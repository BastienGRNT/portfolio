using ApiCv.Sql;
using Npgsql; 

namespace ApiCv.Competence.Delete;

public class DeleteCompetenceService
{
    public void DeleteCompetence(int id)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteCompetenceQuery.DeleteCompetence;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@id", id);
                commande.ExecuteNonQuery();
            }
        }
    }
}