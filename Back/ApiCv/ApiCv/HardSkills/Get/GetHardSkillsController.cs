using ApiCv.HardSkills.Get;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/hard-skills")]
public class GetHardSkillsController : ControllerBase
{
    private readonly GetHardSkillsService _getHardSkillsService;

    public GetHardSkillsController()
    {
        _getHardSkillsService = new GetHardSkillsService();
    }

    [HttpGet]
    public IActionResult GetHardSkills()
    {
        try
        {
            var result = _getHardSkillsService.GetHardSkills();
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}