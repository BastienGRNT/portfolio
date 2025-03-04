using ApiCv.Competence.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class GetCompetenceController : ControllerBase
{
    private readonly GetCompetenceService _getCompetenceService;

    public GetCompetenceController()
    {
        _getCompetenceService = new GetCompetenceService();
    }

    [HttpGet("competence")]
    public IActionResult GetCompetence()
    {
        try
        {
            var result = _getCompetenceService.GetCompetence();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}