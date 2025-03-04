using ApiCv.FormationsProfessionnelles.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class GetFormationController : ControllerBase
{
    private readonly GetFormationService _getFormationService;

    public GetFormationController()
    {
        _getFormationService = new GetFormationService();
    }

    [HttpGet("formation")]
    public IActionResult GetFormation()
    {
        try
        {
            var result = _getFormationService.GetFormation();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}