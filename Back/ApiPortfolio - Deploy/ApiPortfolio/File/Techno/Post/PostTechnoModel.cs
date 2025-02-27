namespace ApiPortfolio.File.Techno.Post;

public class PostTechnoModel
{
    public string Name { get; set; }
    
    public IFormFile File { get; set; }
}

public class TechnoModel
{
    public string Name { get; set; }

    public string Extension { get; set; }

    public string FinalName { get; set; } 

    public string FinalPath { get; set; }  

    public string FullPath { get; set; } 

    public string HttpPath { get; set; } 
}