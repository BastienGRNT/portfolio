namespace ApiCv.Etude.Delete;

public class DeleteEtudesQuery
{
    public static string DeleteEtudes = "DELETE FROM Etude WHERE EtudeID = @etudeid;";
}