namespace ApiCv.Experience.Post;

public class PostExperienceModele
{
    public string Titre { get; set; }
    public string Description { get; set; }
    public string Entreprise { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime? DateFin { get; set; }
}