using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using ValidaSenha.Models;
using ValidaSenha.Validation;

namespace ValidaSenha.Controllers;

[ApiController]
[Route("api")]
public class PasswordController : ControllerBase
{
    [HttpPost("password")]
    public IActionResult ValidatePassword([FromBody] Password senha)
    {
        var validator = new PasswordValidator();
            ValidationResult result = validator.Validate(senha);

            if (result.IsValid)
            {
                return Ok(new { Message = "Senha válida!" });
            }

            return BadRequest(new { Message = "Senha inválida", Errors = result.Errors.Select(error => error.ErrorMessage) });
    }
}