using Microsoft.AspNetCore.Mvc;
using ValidaSenha.Dto;

namespace ValidaSenha.Controllers;

[ApiController]
[Route("api")]
public class PasswordController : ControllerBase
{
    [HttpPost("password")]
    public IActionResult ValidatePassword([FromBody] PasswordDto passwordDto)
    {
        IActionResult isValidPassword = PasswordValidator(passwordDto.Password); 

        if (isValidPassword is OkResult)
        {
            return Ok(new { Message = "Senha válida!" });
        }

        return BadRequest(new { Message = "Senha invalida"});
    }

    private IActionResult PasswordValidator(string password)
    {
        if (password.Length < 6)
        {
            return BadRequest(new { Message = "A senha deve conter 6 ou mais caracteres."});
        }

        if (!password.Any(char.IsUpper))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos uma letra maiuscula."});
        }
        
        if (!password.Any(char.IsLower))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos 1 letra minuscula."});
        }
        
        if (!password.Any(char.IsDigit))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos 1 numero."});
        }
        
        if(!password.Any(c => "*!_?".Contains(c)))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos 1 caracter especial (*!_?)."});
        }

        return Ok(password);
    }
}