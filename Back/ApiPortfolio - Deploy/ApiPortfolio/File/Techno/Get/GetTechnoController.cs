using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.File.Techno.Get;

[ApiController]
[Route("api/techno")]
public class GetTechnoController : ControllerBase
{
    private readonly GetTechnoService _getTechnoService;

    public GetTechnoController()
    {
        _getTechnoService = new GetTechnoService();
    }

    [HttpGet("all")]
    public IActionResult GetAllTechnos()
    {
        try
        {
            var technos = _getTechnoService.GetAllTechnos();
            return Ok(technos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}