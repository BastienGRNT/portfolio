namespace ApiPortfolio.File.Image.Delete;

public class DeleteImageQuery
{
    public static string QueryDeleteImageByName = "DELETE FROM UploadImage WHERE Name = @name;";
}