using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.File.Image.Get;

[ApiController]
[Route("api/image")]
public class GetImageController : ControllerBase
{
    private readonly GetImageService _getImageService;

    public GetImageController()
    {
        _getImageService = new GetImageService();
    }

    [HttpGet("all")]
    public IActionResult GetAllImages()
    {
        try
        {
            var images = _getImageService.GetAllImages();
            return Ok(images);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}