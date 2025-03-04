using Microsoft.AspNetCore.Mvc;

namespace ApiCv.Competence.Post;

[ApiController]
[Route("api/competence")]
public class PostCompetenceController : ControllerBase
{
    private readonly PostCompetenceService _postCompetenceService;

    public PostCompetenceController()
    {
        _postCompetenceService = new PostCompetenceService();
    }

    [HttpPost]
    public IActionResult AddCompetence([FromBody] PostCompetenceModele competence)
    {
        if (competence == null)
        {
            return BadRequest("Les données de la compétence sont manquantes ou invalides.");
        }

        try
        {
            _postCompetenceService.PostCompetence(competence);
            return Ok(new { message = "Compétence ajoutée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}
