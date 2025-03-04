using ApiCv.Sql;
using Npgsql;

namespace ApiCv.FormationsProfessionnelles.Get;

public class GetFormationService
{
    public List<GetFormationModele> GetFormation()
    {
        var formations = new List<GetFormationModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetFormationQuery.QueryGetFormation;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    formations.Add(new GetFormationModele
                    {
                        FormationId = reader.GetInt32(reader.GetOrdinal("FormationId")),
                        Nom = reader.GetString(reader.GetOrdinal("Nom"))
                    });
                }
            }
        }

        return formations;
    }
}