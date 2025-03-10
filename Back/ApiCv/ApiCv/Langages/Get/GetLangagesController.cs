using Microsoft.AspNetCore.Mvc;

namespace ApiCv.Langages.Get;

[ApiController]
[Route("api/langages")]
public class GetLangagesController : ControllerBase
{
    private readonly GetLangagesService _getLangagesService;

    public GetLangagesController()
    {
        _getLangagesService = new GetLangagesService();
    }

    [HttpGet]
    public IActionResult GetLangages()
    {
        try
        {
            var result = _getLangagesService.GetLangages();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}