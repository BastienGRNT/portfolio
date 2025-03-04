namespace ApiCv.Technologies.Post;

public class PostTechnologiesQuery
{
    public static string QueryPostTechnologies = "INSERT INTO technologies (nom, iconepath) VALUES (@nom, @iconepath);";
}