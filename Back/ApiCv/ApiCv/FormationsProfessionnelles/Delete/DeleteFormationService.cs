using ApiCv.Sql;
using Npgsql;

namespace ApiCv.FormationsProfessionnelles.Delete;

public class DeleteFormationService
{
    public void DeleteFormation(int formationId)
    {
        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = DeleteFormationQuery.DeleteFormation;

            using (var commande = new NpgsqlCommand(query, connection))
            {
                commande.Parameters.AddWithValue("@formationid", formationId);
                commande.ExecuteNonQuery();
            }
        }
    }
}