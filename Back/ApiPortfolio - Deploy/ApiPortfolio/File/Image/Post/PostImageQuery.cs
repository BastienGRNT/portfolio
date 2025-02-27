namespace ApiPortfolio.File.Image.Post;

public class PostImageQuery
{
    public static string QueryPostImage = @"INSERT INTO UploadImage (Name, Extension, FinalName, FinalPath, FullPath, HttpPath) VALUES (@name, @extension, @finalName, @finalPath, @fullPath, @httpPath);";
    
    public static string pathVps = "/var/www/upload/images/";
    
    public static string pathHttp = "https://bastiengrnt.fr/upload/images/";
}