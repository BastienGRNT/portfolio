namespace ApiPortfolio.Project.Put;

public class PutProjectModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string GithubLink { get; set; }
    public string WebLink { get; set; }
    public List<int> ImageIds { get; set; }  
    public List<int> TechnoIds { get; set; }  
}