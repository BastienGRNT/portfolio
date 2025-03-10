using Microsoft.AspNetCore.Mvc;

namespace ApiCv.Langages.Delete;

[ApiController]
[Route("api/langages")]
public class DeleteLangagesController : ControllerBase
{
    private readonly DeleteLangagesService _deleteLangagesService;

    public DeleteLangagesController()
    {
        _deleteLangagesService = new DeleteLangagesService();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteLangage(int id)
    {
        try
        {
            _deleteLangagesService.DeleteLangage(id);
            return Ok(new { message = "Langage supprimé avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}