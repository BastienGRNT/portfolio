using ApiCv.Experience.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class PostExperienceController : ControllerBase
{
    private readonly PostExperienceService _postExperienceService;

    public PostExperienceController()
    {
        _postExperienceService = new PostExperienceService();
    }

    [HttpPost("experience")]
    public IActionResult AddExperience([FromBody] PostExperienceModele experience)
    {
        if (experience == null)
        {
            return BadRequest("Les données de l'expérience sont manquantes ou invalides.");
        }

        try
        {
            _postExperienceService.PostExperience(experience);
            return Ok(new { message = "Expérience ajoutée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}