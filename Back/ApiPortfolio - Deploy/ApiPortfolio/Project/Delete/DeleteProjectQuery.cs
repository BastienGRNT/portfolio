namespace ApiPortfolio.Project.Delete;

public class DeleteProjectQuery
{
    public static string QueryDeleteProjectTechno = @"
        DELETE FROM ProjectTechno WHERE IdProject = @idProject;
    ";

    public static string QueryDeleteProjectImage = @"
        DELETE FROM ProjectImage WHERE IdProject = @idProject;
    ";

    public static string QueryDeleteProject = @"
        DELETE FROM Project WHERE IdProject = @idProject;
    ";
}