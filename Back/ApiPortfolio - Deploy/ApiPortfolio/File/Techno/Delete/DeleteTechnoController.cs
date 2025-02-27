using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.File.Techno.Delete;

[ApiController]
[Route("api/techno")]
public class DeleteTechnoController : ControllerBase
{
    private readonly DeleteTechnoService _deleteTechnoService;

    public DeleteTechnoController()
    {
        _deleteTechnoService = new DeleteTechnoService();
    }

    [HttpDelete("{name}")]
    public IActionResult DeleteTechnoByName(string name)
    {
        try
        {
            bool isDeleted = _deleteTechnoService.DeleteTechnoByName(name);

            if (isDeleted)
            {
                return Ok(new { message = $"Technologie '{name}' supprimée avec succès." });
            }
            else
            {
                return NotFound(new { message = $"Technologie '{name}' non trouvée." });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}