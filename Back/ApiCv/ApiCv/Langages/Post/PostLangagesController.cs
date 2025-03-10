using Microsoft.AspNetCore.Mvc;

namespace ApiCv.Langages;

[ApiController]
[Route("api/langages")]
public class PostLangagesController : ControllerBase
{
    private readonly PostLangagesService _postLangagesService;

    public PostLangagesController()
    {
        _postLangagesService = new PostLangagesService();
    }

    [HttpPost]
    public IActionResult AddLangages([FromBody] PostLangagesModele langages)
    {
        if (langages == null)
        {
            return BadRequest("Les données de la technologie sont manquantes ou invalides.");
        }

        try
        {
            _postLangagesService.PostLangages(langages);
            return Ok(new { message = "Langage ajoutée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}