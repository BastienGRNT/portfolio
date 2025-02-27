namespace ApiPortfolio.Project.Get;

public class GetProjectQuery
{
    public static string QueryGetProjectById = @"
        SELECT 
            p.IdProject, p.Title, p.Description, p.GithubLink, p.WebLink, p.created_at AS CreatedAt, p.updated_at AS UpdatedAt,
            ARRAY(SELECT ui.HttpPath FROM UploadImage ui 
                  INNER JOIN ProjectImage pi ON ui.IdUploadImage = pi.IdUploadImage 
                  WHERE pi.IdProject = p.IdProject) AS ImagePaths,
            ARRAY(SELECT ut.HttpPath FROM UploadTechno ut 
                  INNER JOIN ProjectTechno pt ON ut.IdUploadTechno = pt.IdUploadTechno 
                  WHERE pt.IdProject = p.IdProject) AS TechnoPaths
        FROM Project p
        WHERE p.IdProject = @idProject;
    ";

    public static string QueryGetAllProjects = @"
        SELECT 
            p.IdProject, p.Title, p.Description, p.GithubLink, p.WebLink, p.created_at AS CreatedAt, p.updated_at AS UpdatedAt,
            ARRAY(SELECT ui.HttpPath FROM UploadImage ui 
                  INNER JOIN ProjectImage pi ON ui.IdUploadImage = pi.IdUploadImage 
                  WHERE pi.IdProject = p.IdProject) AS ImagePaths,
            ARRAY(SELECT ut.HttpPath FROM UploadTechno ut 
                  INNER JOIN ProjectTechno pt ON ut.IdUploadTechno = pt.IdUploadTechno 
                  WHERE pt.IdProject = p.IdProject) AS TechnoPaths
        FROM Project p;
    ";
}