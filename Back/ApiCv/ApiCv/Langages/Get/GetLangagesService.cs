using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Langages.Get;

public class GetLangagesService
{
    public List<GetLangagesModele> GetLangages()
    {
        var langages = new List<GetLangagesModele>();

        using (var connection = SqlConnection.ConnectSql())
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }

            var query = GetLangagesQuery.QueryGetLangages;

            using (var commande = new NpgsqlCommand(query, connection))
            using (var reader = commande.ExecuteReader())
            {
                while (reader.Read())
                {
                    langages.Add(new GetLangagesModele
                    {
                        LangageId = reader.GetInt32(reader.GetOrdinal("langagesid")),
                        Nom = reader.GetString(reader.GetOrdinal("nom")),
                        IconePath = reader.GetString(reader.GetOrdinal("iconepath"))
                    });
                }
            }
        }

        return langages;
    }
}