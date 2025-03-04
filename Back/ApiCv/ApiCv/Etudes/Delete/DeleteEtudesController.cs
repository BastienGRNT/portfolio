using ApiCv.Etudes.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteEtudesController : ControllerBase
{
    private readonly DeleteEtudesService _deleteEtudesService;

    public DeleteEtudesController()
    {
        _deleteEtudesService = new DeleteEtudesService();
    }

    [HttpDelete("etudes/{id}")]
    public IActionResult DeleteEtudes(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteEtudesService.DeleteEtudes(id);
            return Ok(new { message = "Étude supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}