using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string[] Users = new[]
        {
        "Michael", "Jim", "Dwight", "Ryan", "Stanley", "Toby", "Pam", "Phylis", "Andy", "Meridith"
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "User")]
        public IEnumerable<User> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new User
            {
                Id = Guid.NewGuid(),
                Name = Users[Random.Shared.Next(Users.Length)]
            })
            .ToArray();
        }
    }
}
