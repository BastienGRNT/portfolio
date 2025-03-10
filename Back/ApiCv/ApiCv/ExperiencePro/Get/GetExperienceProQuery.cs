namespace ApiCv.ExperiencePro.Get;

public class GetExperienceProQuery
{
    public static string QueryGetExperiencePro = @"
        SELECT e.ExperienceID, e.Titre, e.Description, e.Entreprise, e.DateDebut, e.DateFin,
               COALESCE(string_agg(c.Competence, ', '), '') AS Competences
        FROM experiences e
        LEFT JOIN CompetencesExperiences c ON e.ExperienceID = c.ExperienceID
        GROUP BY e.ExperienceID;";
}