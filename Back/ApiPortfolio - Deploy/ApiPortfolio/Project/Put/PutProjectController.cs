using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.Project.Put;

[ApiController]
[Route("api/project")]
public class PutProjectController : ControllerBase
{
    private readonly PutProjectService _putProjectService;

    public PutProjectController()
    {
        _putProjectService = new PutProjectService();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProject(int id, [FromBody] PutProjectModel projet)
    {
        if (projet == null)
        {
            return BadRequest("Les données du projet sont invalides.");
        }

        bool updated = _putProjectService.UpdateProject(id, projet);

        if (!updated)
        {
            return NotFound(new { message = "Projet non trouvé ou non modifié." });
        }

        return Ok(new { message = "Projet mis à jour avec succès !" });
    }
}