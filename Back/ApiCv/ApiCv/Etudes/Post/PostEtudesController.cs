using ApiCv.Etude.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/etudes")]
public class PostEtudesController : ControllerBase
{
    private readonly PostEtudesService _postEtudesService;

    public PostEtudesController()
    {
        _postEtudesService = new PostEtudesService();
    }

    [HttpPost]
    public IActionResult AddEtudes([FromBody] PostEtudesModele etudes)
    {
        if (etudes == null)
        {
            return BadRequest("Les données des études sont manquantes ou invalides.");
        }

        try
        {
            _postEtudesService.PostEtudes(etudes);
            return Ok(new { message = "Études ajoutées avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}