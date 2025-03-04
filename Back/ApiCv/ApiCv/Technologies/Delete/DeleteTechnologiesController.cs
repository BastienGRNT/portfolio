using ApiCv.Technologies.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteTechnologiesController : ControllerBase
{
    private readonly DeleteTechnologiesService _deleteTechnologiesService;

    public DeleteTechnologiesController()
    {
        _deleteTechnologiesService = new DeleteTechnologiesService();
    }

    [HttpDelete("technologies/{id}")]
    public IActionResult DeleteTechnologies(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteTechnologiesService.DeleteTechnologies(id);
            return Ok(new { message = "Technologie supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}