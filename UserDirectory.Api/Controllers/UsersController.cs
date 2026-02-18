using Microsoft.AspNetCore.Mvc;
using UserDirectory.Api.Models;
using UserDirectory.Api.Data;

namespace UserDirectory.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // GET: api/users
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(UserStore.Users);
    }

    // GET: api/users/1
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = UserStore.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public IActionResult Create(User user)
    {
        user.Id = UserStore.NextId++;
        UserStore.Users.Add(user);

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    // PUT: api/users/1
    [HttpPut("{id}")]
    public IActionResult Update(int id, User updatedUser)
    {
        var existing = UserStore.Users.FirstOrDefault(u => u.Id == id);

        if (existing == null)
            return NotFound();

        existing.Name = updatedUser.Name;
        existing.Age = updatedUser.Age;
        existing.City = updatedUser.City;
        existing.State = updatedUser.State;
        existing.Pincode = updatedUser.Pincode;

        return NoContent();
    }

    // DELETE: api/users/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = UserStore.Users.FirstOrDefault(u => u.Id == id);

        if (user == null)
            return NotFound();

        UserStore.Users.Remove(user);

        return NoContent();
    }
}