using ApiCv.CompetenceExperience.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/competence-experience")]
public class GetExperienceCompetenceController : ControllerBase
{
    private readonly GetExperienceCompetenceService _getExperienceCompetenceService;

    public GetExperienceCompetenceController()
    {
        _getExperienceCompetenceService = new GetExperienceCompetenceService();
    }

    [HttpGet]
    public IActionResult GetExperienceCompetence()
    {
        try
        {
            var result = _getExperienceCompetenceService.GetExperienceCompetence();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}