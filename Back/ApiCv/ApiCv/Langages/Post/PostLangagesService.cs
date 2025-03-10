using ApiCv.Sql;
using Npgsql;

namespace ApiCv.Langages;

public class PostLangagesService
{
   public void PostLangages(PostLangagesModele data)
   {
      using (var connection = SqlConnection.ConnectSql())
      {
         if (connection.State != System.Data.ConnectionState.Open)
         {
            connection.Open();
         }

         var query = PostLangageQuery.QueryPostLanagages;

         using (var commande = new NpgsqlCommand(query, connection))
         {
            commande.Parameters.AddWithValue("@nom", data.Nom);
            commande.Parameters.AddWithValue("@iconepath", data.IconPath);
            commande.ExecuteNonQuery();
         }
         
      }
   }
}