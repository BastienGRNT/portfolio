namespace ApiCv.CompetenceExperience.Post;

public class PostCompetenceExperienceQuery
{
    public static string QueryPostCompetenceExperience = "INSERT INTO CompetencesExperiences (Competence, ExperienceID) VALUES (@competence, @experienceid);";
}