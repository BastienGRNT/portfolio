namespace ApiCv.Experience.Get;

public class GetExperienceModele
{
    public int ExperienceId { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public string Entreprise { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime? DateFin { get; set; }
}