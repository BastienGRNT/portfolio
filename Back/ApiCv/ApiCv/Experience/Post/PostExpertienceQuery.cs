namespace ApiCv.Experience.Post;

public class PostExperienceQuery
{
    public static string QueryPostExperience = "INSERT INTO ExperiencePro (Titre, Description, Entreprise, DateDebut, DateFin) VALUES (@titre, @description, @entreprise, @datedebut, @datefin);";
}