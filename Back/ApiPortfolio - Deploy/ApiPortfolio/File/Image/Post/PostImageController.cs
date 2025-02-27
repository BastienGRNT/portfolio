using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.File.Image.Post;

[ApiController]
[Route("api/image")]
public class PostImageController : ControllerBase
{
    private readonly PostImageService _postImageService;

    public PostImageController()
    {
        _postImageService = new PostImageService();
    }

    [HttpPost("upload")]
    public IActionResult UploadImage([FromForm] PostImageModel imageModel)
    {
        if (imageModel.File == null || imageModel.File.Length == 0)
        {
            return BadRequest("Aucun fichier sélectionné.");
        }

        try
        {
            _postImageService.PostImage(imageModel);
            return Ok(new { message = "Image uploadée avec succès", imageModel.Name });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}