using ApiCv.Experience.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteExperienceController : ControllerBase
{
    private readonly DeleteExperienceService _deleteExperienceService;

    public DeleteExperienceController()
    {
        _deleteExperienceService = new DeleteExperienceService();
    }

    [HttpDelete("experience/{id}")]
    public IActionResult DeleteExperience(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteExperienceService.DeleteExperience(id);
            return Ok(new { message = "Expérience supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}