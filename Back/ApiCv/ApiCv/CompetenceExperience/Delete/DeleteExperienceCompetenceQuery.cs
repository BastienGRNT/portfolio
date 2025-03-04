namespace ApiCv.CompetenceExperience.Delete;

public class DeleteExperienceCompetenceQuery
{
    public static string DeleteExperienceCompetence = "DELETE FROM CompetencesExperiences WHERE CompetenceExperienceID = @competenceexperienceid;";
}