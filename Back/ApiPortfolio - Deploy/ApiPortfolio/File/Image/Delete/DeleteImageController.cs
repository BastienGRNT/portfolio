using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.File.Image.Delete;

[ApiController]
[Route("api/image")]
public class DeleteImageController : ControllerBase
{
    private readonly DeleteImageService _deleteImageService;

    public DeleteImageController()
    {
        _deleteImageService = new DeleteImageService();
    }

    [HttpDelete("{name}")]
    public IActionResult DeleteImageByName(string name)
    {
        try
        {
            bool isDeleted = _deleteImageService.DeleteImageByName(name);

            if (isDeleted)
            {
                return Ok(new { message = $"Image '{name}' supprimée de la base de données." });
            }
            else
            {
                return NotFound(new { message = $"Image '{name}' non trouvée en base de données." });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}