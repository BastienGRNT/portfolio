using Microsoft.AspNetCore.Mvc;

namespace ApiPortfolio.Project.Delete;

[ApiController]
[Route("api/project")]
public class DeleteProjectController : ControllerBase
{
    private readonly DeleteProjectService _deleteProjectService;

    public DeleteProjectController()
    {
        _deleteProjectService = new DeleteProjectService();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProjectById(int id)
    {
        try
        {
            bool isDeleted = _deleteProjectService.DeleteProject(id);

            if (isDeleted)
            {
                return Ok(new { message = $"Projet avec ID {id} supprimé de la base de données." });
            }
            else
            {
                return NotFound(new { message = $"Projet avec ID {id} non trouvé en base de données." });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erreur serveur : {ex.Message}");
        }
    }
}