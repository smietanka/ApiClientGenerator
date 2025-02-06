using ApiClientGeneration.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiClientGeneration.Controllers;

[ApiController]
[Route("api/v1/cool")]
public class CoolController : ControllerBase
{
    [HttpGet("user/{userId}")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Unauthorized)]
    public Task<User> GetUser(int userId) => Task.FromResult(new User() { Id = userId });

    [HttpGet("user/{userId}/types")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.Unauthorized)]
    public Task<User> GetUserBySomething(int userId, [FromQuery] GetUserBy request) => Task.FromResult(new User() { Id = userId, Type = UserType.Admin });

    [HttpGet("users")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public Task<List<User>> GetUsers() => Task.FromResult(new List<User>()
    {
        new() { Id = 1 }
    });

    [HttpDelete("user/{userId}")]
    [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public Task<List<User>> DeleteUser(int userId) => Task.FromResult(new List<User>()
    {
        new() { Id = userId }
    });

    [HttpPost("user")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
    public Task<bool> CreateUser(User user) => Task.FromResult(true);
}
