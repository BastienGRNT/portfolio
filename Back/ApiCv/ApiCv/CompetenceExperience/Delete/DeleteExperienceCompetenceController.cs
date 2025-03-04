using ApiCv.CompetenceExperience.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteExperienceCompetenceController : ControllerBase
{
    private readonly DeleteExperienceCompetenceService _deleteExperienceCompetenceService;

    public DeleteExperienceCompetenceController()
    {
        _deleteExperienceCompetenceService = new DeleteExperienceCompetenceService();
    }

    [HttpDelete("competence-experience/{id}")]
    public IActionResult DeleteExperienceCompetence(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteExperienceCompetenceService.DeleteExperienceCompetence(id);
            return Ok(new { message = "Compétence associée supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}