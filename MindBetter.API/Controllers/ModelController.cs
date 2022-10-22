using Microsoft.AspNetCore.Mvc;
using MindBetter.Core.Model;
using MindBetter.Core.Model.NPMHOAggregate;
using MindBetter.Infrastructure.Data;
using System.Net.WebSockets;

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

    [HttpGet("users")]
    public IEnumerable<User> Users()
    {
        return _appDbContext.Users.ToList();
    }

    [HttpGet("permission-types")]
    public IEnumerable<PermissionType> PermissionTypes()
    {
        return _appDbContext.PermissionTypes.ToList();
    }

    [HttpGet("npmhos")]
    public IEnumerable<NPMHO> NPMHOs()
    {
        return _appDbContext.NPMHOs.ToList();
    }

    [HttpGet("services")]
    public IEnumerable<Service> Services()
    {
        return _appDbContext.Services.ToList();
    }

    [HttpGet("npmho-members")]
    public IEnumerable<NPMHOMember> NPMHOMembers()
    {
        return _appDbContext.NPMHOMembers.ToList();
    }

    [HttpGet("service-categories")]
    public IEnumerable<ServiceCategory> ServiceCategories()
    {
        return _appDbContext.ServiceCategories.ToList();
    }
}
