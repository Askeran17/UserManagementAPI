using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UserManagementAPI.Models;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private static List<User> users = new List<User>();

    [HttpGet]
public IActionResult GetAllUsers(int page = 1, int pageSize = 10)
{
    var paginatedUsers = users.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    return Ok(paginatedUsers);
}


    [HttpGet("{id}")]
public IActionResult GetUserById(int id)
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
        return NotFound(new { Message = $"User with ID {id} not found" });
    }

    return Ok(user);
}


    [HttpPost]
public IActionResult AddUser([FromBody] User newUser)
{
    try
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        users.Add(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { Message = "An error occurred", Details = ex.Message });
    }
}


    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var user = users.Find(u => u.Id == id);
        if (user == null)
            return NotFound();

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = users.Find(u => u.Id == id);
        if (user == null)
            return NotFound();

        users.Remove(user);
        return NoContent();
    }
}
