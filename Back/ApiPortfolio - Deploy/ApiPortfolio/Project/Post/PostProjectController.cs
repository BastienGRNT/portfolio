using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.Project.Post;

[ApiController]
[Route("api/project")]
public class PostProjectController : ControllerBase
{
    private readonly PostProjectService _postProjectService;

    public PostProjectController()
    {
        _postProjectService = new PostProjectService();
    }

    [HttpPost("add")]
    public IActionResult AddProject([FromBody] PostProjectModel projet)
    {
        if (projet == null)
        {
            return BadRequest("Les données du projet sont invalides.");
        }

        try
        {
            _postProjectService.PostProject(projet);
            return Ok(new { message = "Projet ajouté avec succès !" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}