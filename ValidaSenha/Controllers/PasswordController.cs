using Microsoft.AspNetCore.Mvc;
using ValidaSenha.Dto;

namespace ValidaSenha.Controllers;

[ApiController]
[Route("api")]
public class PasswordController : ControllerBase
{
    [HttpPost("password")]
    public IActionResult ValidatePassword([FromBody] PasswordDto password)
    {
        if (password.Password.Length < 6)
        {
            return BadRequest(new { Message = "A senha deve conter 6 ou mais caracteres."});
        }

        if (!password.Password.Any(char.IsUpper))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos uma letra maiuscula."});
        }
        
        if (!password.Password.Any(char.IsLower))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos 1 letra minuscula."});
        }
        
        if (!password.Password.Any(char.IsDigit))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos 1 numero."});
        }
        
        if(!password.Password.Any(c => "*!_?".Contains(c)))
        {
            return BadRequest(new { Message = "A senha deve conter pelo menos 1 caracter especial (*!_?)."});
        }

        return Ok(new {Message = "Senha criada com sucesso!"});
    }
}