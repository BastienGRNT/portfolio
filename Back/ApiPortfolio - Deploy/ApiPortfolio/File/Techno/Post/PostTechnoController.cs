using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.File.Techno.Post;

[ApiController]
[Route("api/techno")]
public class PostTechnoController : ControllerBase
{
    private readonly PostTechnoService _postTechnoService;

    public PostTechnoController()
    {
        _postTechnoService = new PostTechnoService();
    }

    [HttpPost("upload")]
    public IActionResult UploadTechno([FromForm] PostTechnoModel technoModel)
    {
        if (technoModel.File == null || technoModel.File.Length == 0)
        {
            return BadRequest("Aucun fichier sélectionné.");
        }

        try
        {
            _postTechnoService.PostTechno(technoModel);
            return Ok(new { message = "Technologie uploadée avec succès", technoModel.Name });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}