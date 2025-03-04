using ApiCv.Divers.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/divers")]
public class PostDiversController : ControllerBase
{
    private readonly PostDiversService _postDiversService;

    public PostDiversController()
    {
        _postDiversService = new PostDiversService();
    }

    [HttpPost]
    public IActionResult AddDivers([FromBody] PostDiversModele divers)
    {
        if (divers == null)
        {
            return BadRequest("Les données du champ divers sont manquantes ou invalides.");
        }

        try
        {
            _postDiversService.PostDivers(divers);
            return Ok(new { message = "Champ divers ajouté avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}