namespace ApiCv.Competence.Post;

public class PostCompetenceQuery
{
    public static string QueryPostCompetence = "INSERT INTO competence (Nom, Description) VALUES (@nom, @description);";
}