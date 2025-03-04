using ApiCv.CompetenceExperience.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/competence-experience")]
public class PostCompetenceExperienceController : ControllerBase
{
    private readonly PostCompetenceExperienceService _postCompetenceExperienceService;

    public PostCompetenceExperienceController()
    {
        _postCompetenceExperienceService = new PostCompetenceExperienceService();
    }

    [HttpPost]
    public IActionResult AddCompetenceExperience([FromBody] PostCompetenceExperienceModele competenceExperience)
    {
        if (competenceExperience == null)
        {
            return BadRequest("Les données sont manquantes ou invalides.");
        }

        try
        {
            _postCompetenceExperienceService.PostCompetenceExperience(competenceExperience);
            return Ok(new { message = "Compétence associée à l'expérience avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}