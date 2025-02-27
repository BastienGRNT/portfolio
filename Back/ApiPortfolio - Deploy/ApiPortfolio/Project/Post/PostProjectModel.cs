namespace ApiPortfolio.Project.Post;

public class PostProjectModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string GithubLink { get; set; }
    public string WebLink { get; set; }

    public List<int> ImageIds { get; set; }
    public List<int> TechnoIds { get; set; }
}

public class ProjectModel
{
    public int IdProject { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string GithubLink { get; set; }
    public string WebLink { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<string> ImagePaths { get; set; }
    public List<string> TechnoPaths { get; set; }
}