namespace ApiCv.Langages.Delete;

public class DeleteLangagesQuery
{
    public static string QueryDeleteLangage = "DELETE FROM langages WHERE langagesid = @langagesid;";
}