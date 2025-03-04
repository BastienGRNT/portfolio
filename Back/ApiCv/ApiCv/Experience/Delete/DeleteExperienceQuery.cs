namespace ApiCv.Experience.Delete;

public class DeleteExperienceQuery
{
    public static string DeleteExperience = "DELETE FROM Experiences WHERE ExperienceID = @experienceid;";
}