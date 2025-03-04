using ApiCv.Divers.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/divers")]
public class GetDiversController : ControllerBase
{
    private readonly GetDiversService _getDiversService;

    public GetDiversController()
    {
        _getDiversService = new GetDiversService();
    }

    [HttpGet]
    public IActionResult GetDivers()
    {
        try
        {
            var result = _getDiversService.GetDivers();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}