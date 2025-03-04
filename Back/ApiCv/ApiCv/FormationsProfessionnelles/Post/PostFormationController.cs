using ApiCv.FormationsProfessionnelles.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/formation")]
public class PostFormationController : ControllerBase
{
    private readonly PostFormationService _postFormationService;

    public PostFormationController()
    {
        _postFormationService = new PostFormationService();
    }

    [HttpPost]
    public IActionResult AddFormation([FromBody] PostFormationModele formation)
    {
        if (formation == null)
        {
            return BadRequest("Les données de la formation sont manquantes ou invalides.");
        }

        try
        {
            _postFormationService.PostFormation(formation);
            return Ok(new { message = "Formation ajoutée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}