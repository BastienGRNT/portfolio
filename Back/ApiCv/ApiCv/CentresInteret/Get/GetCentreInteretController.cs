using Microsoft.AspNetCore.Mvc;

namespace ApiCv.CentresInteret.Get;


[ApiController]
[Route("/api/centre-interet")]
public class GetCentreInteretController : ControllerBase
{
    private readonly GetCentreInteretService _getCentreInteretService;

    public GetCentreInteretController()
    {
        _getCentreInteretService = new GetCentreInteretService();
    }

    [HttpGet]
    public IActionResult GetCentreInteret()
    {
        try
        {
            var result = _getCentreInteretService.GetCentreInteret();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}