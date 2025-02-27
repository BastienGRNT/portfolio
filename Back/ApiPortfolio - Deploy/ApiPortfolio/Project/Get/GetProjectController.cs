using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiPortfolio.Project.Get;

[ApiController]
[Route("api/project")]
public class GetProjectController : ControllerBase
{
    private readonly GetProjectService _getProjectService;

    public GetProjectController()
    {
        _getProjectService = new GetProjectService();
    }

    [HttpGet("{id}")]
    public IActionResult GetProjectById(int id)
    {
        var project = _getProjectService.GetProjectById(id);

        if (project == null)
        {
            return NotFound(new { message = "Projet non trouvé" });
        }

        return Ok(project);
    }

    [HttpGet("all")]
    public IActionResult GetAllProjects()
    {
        var projects = _getProjectService.GetAllProjects();

        return Ok(projects);
    }
}