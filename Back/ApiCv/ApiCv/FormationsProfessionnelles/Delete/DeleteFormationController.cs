using ApiCv.FormationsProfessionnelles.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteFormationController : ControllerBase
{
    private readonly DeleteFormationService _deleteFormationService;

    public DeleteFormationController()
    {
        _deleteFormationService = new DeleteFormationService();
    }

    [HttpDelete("formation/{id}")]
    public IActionResult DeleteFormation(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteFormationService.DeleteFormation(id);
            return Ok(new { message = "Formation supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}