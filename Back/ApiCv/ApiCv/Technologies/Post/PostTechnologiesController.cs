using ApiCv.Technologies.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/technologies")]
public class PostTechnologiesController : ControllerBase
{
    private readonly PostTechnologiesService _postTechnologiesService;

    public PostTechnologiesController()
    {
        _postTechnologiesService = new PostTechnologiesService();
    }

    [HttpPost]
    public IActionResult AddTechnologies([FromBody] PostTechnologiesModele technologies)
    {
        if (technologies == null)
        {
            return BadRequest("Les données de la technologie sont manquantes ou invalides.");
        }

        try
        {
            _postTechnologiesService.PostTechnologies(technologies);
            return Ok(new { message = "Technologie ajoutée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}