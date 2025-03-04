namespace ApiCv.FormationsProfessionnelles.Post;

public class PostFormationQuery
{
    public static string QueryPostFormation = "INSERT INTO FormationsProfessionnelles (Nom) VALUES (@nom);";
}