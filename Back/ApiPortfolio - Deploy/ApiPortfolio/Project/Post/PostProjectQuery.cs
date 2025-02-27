namespace ApiPortfolio.Project.Post;

public class PostProjectQuery
{
    public static string QueryPostProject = @"
        INSERT INTO Project (Title, Description, GithubLink, WebLink)
        VALUES (@title, @description, @githublink, @weblink)
        RETURNING IdProject;
    ";

    public static string QueryPostTechno = @"
        INSERT INTO ProjectTechno (IdProject, IdUploadTechno)
        VALUES (@idproject, @idtechno);
    ";

    public static string QueryPostImage = @"
        INSERT INTO ProjectImage (IdProject, IdUploadImage)
        VALUES (@idproject, @idimage);
    ";
}