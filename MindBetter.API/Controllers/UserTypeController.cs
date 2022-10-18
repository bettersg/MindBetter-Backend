using Microsoft.AspNetCore.Mvc;
using MindBetter.Core.Model;
using MindBetter.Infrastructure.Data;

namespace MindBetter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionTypeController : ControllerBase
{
    private readonly ILogger<PermissionTypeController> _logger;
    private AppDbContext _appDbContext;

    public PermissionTypeController(ILogger<PermissionTypeController> logger, AppDbContext appDbContext)
    {
        this._logger = logger;
        this._appDbContext = appDbContext;
    }

    [HttpGet(Name = "GetUserTypes")]
    public IEnumerable<PermissionType> Get()
    {
        return _appDbContext.UserTypes.ToList();
    }
}
