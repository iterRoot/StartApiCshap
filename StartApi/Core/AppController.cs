using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StartApi.Core;

[ApiController]
[Route("[controller]")]
public class MyController : ControllerBase
{


    [NonAction]
    protected IActionResult Existed(string name)
    {
        return Error($"{name} is already exited!");
    }

    [NonAction]
    protected IActionResult Denied()
    {
        return Error("Access Denied!");
    }

    [NonAction]
    protected IActionResult Required(string name)
    {
        return Error($"{name} is required!");
    }

    [NonAction]
    protected IActionResult ItemNotFound()
    {
        return Error("Item is not found!");
    }

    [NonAction]
    protected IActionResult Error(string message)
    {
        return Ok(new { Status = "E", Message = message });
    }
}