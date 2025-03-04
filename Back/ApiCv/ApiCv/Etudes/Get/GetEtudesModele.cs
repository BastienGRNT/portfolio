namespace ApiCv.Etudes.Get;

public class GetEtudesModele
{
    public int EtudeId { get; set; }
    public string Description { get; set; }
    public string Titre { get; set; }
    public DateTime DateDebut { get; set; }
    public DateTime? DateFin { get; set; }
    public string Lieu { get; set; }
}