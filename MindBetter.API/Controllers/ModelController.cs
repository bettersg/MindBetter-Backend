using Microsoft.AspNetCore.Mvc;
using MindBetter.Core.Model;
using MindBetter.Core.Model.NPMHOAggregate;
using MindBetter.Infrastructure.Data;

namespace MindBetter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelController : ControllerBase
{
    private readonly ILogger<ModelController> _logger;
    private AppDbContext _appDbContext;

    public ModelController(ILogger<ModelController> logger, AppDbContext appDbContext)
    {
        this._logger = logger;
        this._appDbContext = appDbContext;
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        return _appDbContext.Users.ToList();
    }

    [HttpGet("GetPermissionTypes")]
    public IEnumerable<PermissionType> GetPermissionTypes()
    {
        return _appDbContext.PermissionTypes.ToList();
    }

    [HttpGet("GetNPMHOs")]
    public IEnumerable<NPMHO> GetNPMHOs()
    {
        return _appDbContext.NPMHOs.ToList();
    }

    [HttpGet("GetServices")]
    public IEnumerable<Service> GetServices()
    {
        return _appDbContext.Services.ToList();
    }

    [HttpGet("GetNPMHOMembers")]
    public IEnumerable<NPMHOMember> GetNPMHOMembers()
    {
        return _appDbContext.NPMHOMembers.ToList();
    }
}
