namespace ApiCv.Technologies.Delete;

public class DeleteTechnologiesQuery
{
    public static string DeleteTechnologies = "DELETE FROM technologies WHERE technologieid = @technologieid;";
}