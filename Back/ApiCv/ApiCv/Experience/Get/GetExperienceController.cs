using ApiCv.Experience.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/experience")]
public class GetExperienceController : ControllerBase
{
    private readonly GetExperienceService _getExperienceService;

    public GetExperienceController()
    {
        _getExperienceService = new GetExperienceService();
    }

    [HttpGet]
    public IActionResult GetExperience()
    {
        try
        {
            var result = _getExperienceService.GetExperience();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}