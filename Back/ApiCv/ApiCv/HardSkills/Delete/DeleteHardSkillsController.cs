using ApiCv.HardSkills.Delete;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/")]
public class DeleteHardSkillsController : ControllerBase
{
    private readonly DeleteHardSkillsService _deleteHardSkillsService;

    public DeleteHardSkillsController()
    {
        _deleteHardSkillsService = new DeleteHardSkillsService();
    }

    [HttpDelete("hard-skills/{id}")]
    public IActionResult DeleteHardSkills(int id)
    {
        if (id <= 0)
        {
            return BadRequest("ID invalide.");
        }

        try
        {
            _deleteHardSkillsService.DeleteHardSkills(id);
            return Ok(new { message = "Hard Skill supprimée avec succès." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}