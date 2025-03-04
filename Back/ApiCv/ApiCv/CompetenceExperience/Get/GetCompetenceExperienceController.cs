using ApiCv.CompetenceExperience.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/competence-experience")]
public class GetCompetenceExperienceController : ControllerBase
{
    private readonly GetExperienceCompetenceService _getExperienceCompetenceService;

    public GetCompetenceExperienceController()
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