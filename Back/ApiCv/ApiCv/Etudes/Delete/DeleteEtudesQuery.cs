namespace ApiCv.Etudes.Delete;

public class DeleteEtudesQuery
{
    public static string DeleteEtudes = "DELETE FROM Etudes WHERE EtudeID = @etudeid;";
}