namespace ApiPortfolio.File.Image.Get;

public class GetImageModel
{
    public int IdUploadImage { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public string FinalName { get; set; }
    public string FinalPath { get; set; }
    public string FullPath { get; set; }
    public string HttpPath { get; set; }
}