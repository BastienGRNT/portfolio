namespace ApiPortfolio.File.Techno.Post;

public class PostTechnoQuery
{
    public static string QueryPostTechno = @"INSERT INTO UploadTechno (Name, Extension, FinalName, FinalPath, FullPath, HttpPath) VALUES (@name, @extension, @finalName, @finalPath, @fullPath, @httpPath);";
    
    public static string pathVps = "/var/www/upload/technos/";
    
    public static string pathHttp = "https://bastiengrnt.fr/upload/technos/";
}