using Microsoft.AspNetCore.Mvc;

namespace ApiCv.CentresInteret.Post;

[ApiController]
[Route("api/")]
public class PostCentreInteretController : ControllerBase
{
    private readonly PostCentreInteretService _postCentreInteretService;

    public PostCentreInteretController()
    {
        _postCentreInteretService = new PostCentreInteretService();
    }

    [HttpPost("CentreInteret")]
    public IActionResult AddCentreInteret([FromBody] PostCentreInteretModele centreInteret)
    {
        if (centreInteret == null)
        {
            return BadRequest("Les données du centre d'intérêt sont manquantes ou invalides.");
        }

        try
        {
            _postCentreInteretService.PostCentreInteret(centreInteret);
            return Ok(new { message = "Centre d'intérêt ajouté avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}
