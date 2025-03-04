using ApiCv.ExperiencePro.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class GetExperienceProController : ControllerBase
{
    private readonly GetExperienceProService _getExperienceProService;

    public GetExperienceProController()
    {
        _getExperienceProService = new GetExperienceProService();
    }

    [HttpGet("experience-pro")]
    public IActionResult GetExperiencePro()
    {
        try
        {
            var result = _getExperienceProService.GetExperiencePro();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}