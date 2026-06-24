using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<List<User>> GetAllUsers()
    {
        return Ok(_userService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetById(id);

        if (user == null)
            return NotFound($"User with ID {id} was not found.");

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        var createdUser = _userService.Create(user);

        return CreatedAtAction(
            nameof(GetUserById),
            new { id = createdUser.Id },
            createdUser
        );
    }

    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, User user)
    {
        var updated = _userService.Update(id, user);

        if (!updated)
            return NotFound($"User with ID {id} was not found.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var deleted = _userService.Delete(id);

        if (!deleted)
            return NotFound($"User with ID {id} was not found.");

        return NoContent();
    }
}