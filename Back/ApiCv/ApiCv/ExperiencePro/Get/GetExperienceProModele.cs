namespace ApiCv.ExperiencePro.Get;

public class GetExperienceProModele
{
    public int ExperienceId { get; set; }
    public string Titre { get; set; }
    public string Description { get; set; }
    public string Entreprise { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime? DateFin { get; set; }
    public List<string> Competences { get; set; }
}