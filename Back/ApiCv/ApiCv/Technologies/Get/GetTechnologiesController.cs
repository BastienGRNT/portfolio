using ApiCv.Technologies.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/technologies")]
public class GetTechnologiesController : ControllerBase
{
    private readonly GetTechnologiesService _getTechnologiesService;

    public GetTechnologiesController()
    {
        _getTechnologiesService = new GetTechnologiesService();
    }

    [HttpGet]
    public IActionResult GetTechnologies()
    {
        try
        {
            var result = _getTechnologiesService.GetTechnologies();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}