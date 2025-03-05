using ApiCv.Etude.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/etudes")]
public class GetEtudesController : ControllerBase
{
    private readonly GetEtudesService _getEtudesService;

    public GetEtudesController()
    {
        _getEtudesService = new GetEtudesService();
    }

    [HttpGet]
    public IActionResult GetEtudes()
    {
        try
        {
            var result = _getEtudesService.GetEtudes();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}