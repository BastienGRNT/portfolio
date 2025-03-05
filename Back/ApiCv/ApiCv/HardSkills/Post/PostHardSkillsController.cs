using ApiCv.HardSkill.Post;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/hard-skills")]
public class PostHardSkillsController : ControllerBase
{
    private readonly PostHardSkillsService _postHardSkillsService;

    public PostHardSkillsController()
    {
        _postHardSkillsService = new PostHardSkillsService();
    }

    [HttpPost]
    public IActionResult AddHardSkills([FromBody] PostHardSkillsModele hardSkills)
    {
        if (hardSkills == null)
        {
            return BadRequest("Les données de la compétence sont manquantes ou invalides.");
        }

        try
        {
            _postHardSkillsService.PostHardSkills(hardSkills);
            return Ok(new { message = "Compétence ajoutée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}