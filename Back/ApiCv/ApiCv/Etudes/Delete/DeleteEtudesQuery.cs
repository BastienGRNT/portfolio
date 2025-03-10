namespace ApiCv.Etude.Delete;

public class DeleteEtudesQuery
{
    public static string DeleteEtudes = "DELETE FROM etudes WHERE EtudeID = @etudeid;";
}