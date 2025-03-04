namespace ApiCv.Etudes.Post;

public class PostEtudesQuery
{
    public static string QueryPostEtudes = "INSERT INTO Etudes (Description, Titre, DateDebut, DateFin, Lieu) VALUES (@description, @titre, @datedebut, @datefin, @lieu);";
}