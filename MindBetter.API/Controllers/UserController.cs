using Microsoft.AspNetCore.Mvc;
using MindBetter.Core.Model;
using MindBetter.Infrastructure.Data;

namespace MindBetter.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private AppDbContext _appDbContext;

    public UserController(ILogger<UserController> logger, AppDbContext appDbContext)
    {
        this._logger = logger;
        this._appDbContext = appDbContext;
    }

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<User> Get()
    {
        return _appDbContext.Users.ToList();
    }
}
