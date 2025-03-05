using Microsoft.AspNetCore.Mvc;

namespace ApiCv.CentreInteret.Delete;

[ApiController]
[Route("api/")]
public class DeleteCentreInteretController : ControllerBase
{
    private readonly DeleteCentreInteretService _deleteCentreInteretService;

    public DeleteCentreInteretController()
    {
        _deleteCentreInteretService = new DeleteCentreInteretService();
    }

    [HttpDelete("centre-interet/{id}")]
    public IActionResult DeleteCentreInteret(int id)
    {
        if (id == null)
        {
            return BadRequest("Les données sont manquantes");
        }

        try
        {
            _deleteCentreInteretService.DeleteCentreInteret(id);
            return Ok(new { message = "Centre Interet Deleted" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}



