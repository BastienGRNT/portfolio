using ApiCv.Divers.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteDiversController : ControllerBase
{
    private readonly DeleteDiversService _deleteDiversService;

    public DeleteDiversController()
    {
        _deleteDiversService = new DeleteDiversService();
    }

    [HttpDelete("divers/{id}")]
    public IActionResult DeleteDivers(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteDiversService.DeleteDivers(id);
            return Ok(new { message = "Champ divers supprimé avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}