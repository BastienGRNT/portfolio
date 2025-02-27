namespace ApiPortfolio.Project.Put;

public class PutProjectQuery
{
    public static string QueryUpdateProject = @"
        UPDATE Project
        SET Title = @title, 
            Description = @description, 
            GithubLink = @githublink, 
            WebLink = @weblink, 
            updated_at = NOW()
        WHERE IdProject = @idProject;
    ";

    public static string QueryDeleteProjectTechno = @"
        DELETE FROM ProjectTechno WHERE IdProject = @idProject;
    ";

    public static string QueryInsertProjectTechno = @"
        INSERT INTO ProjectTechno (IdProject, IdUploadTechno)
        VALUES (@idProject, @idTechno);
    ";

    public static string QueryDeleteProjectImage = @"
        DELETE FROM ProjectImage WHERE IdProject = @idProject;
    ";

    public static string QueryInsertProjectImage = @"
        INSERT INTO ProjectImage (IdProject, IdUploadImage)
        VALUES (@idProject, @idImage);
    ";
}