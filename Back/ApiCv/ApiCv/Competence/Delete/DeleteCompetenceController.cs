using ApiCv.Competence.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteCompetenceController : ControllerBase
{
    private readonly DeleteCompetenceService _deleteCompetenceService;

    public DeleteCompetenceController()
    {
        _deleteCompetenceService = new DeleteCompetenceService();
    }

    [HttpDelete("competence/{id}")]
    public IActionResult DeleteCompetence(int id)
    {
        if (id == null)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteCompetenceService.DeleteCompetence(id);
            return Ok(new { message = "Compétence supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}
