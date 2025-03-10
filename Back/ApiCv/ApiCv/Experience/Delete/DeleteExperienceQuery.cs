namespace ApiCv.Experience.Delete;

public class DeleteExperienceQuery
{
    public static string DeleteExperience = "DELETE FROM experiences WHERE ExperienceID = @experienceid;";
}