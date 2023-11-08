using FluentValidation;
using ValidaSenha.Models;

namespace ValidaSenha.Validation;

public class PasswordValidator : AbstractValidator<Password>
{
    public PasswordValidator()
    {
        RuleFor(password => password.Senha)
            .NotEmpty().WithMessage("Senha não pode ser vazia.")
            .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.")
            .Must(HaveUpperCase).WithMessage("A senha deve conter pelo menos 1 letra maiúscula.")
            .Must(HaveDigit).WithMessage("A senha deve conter pelo menos um número.")
            .Must(HaveSpecialCharacter).WithMessage("A senha deve conter pelo menos um caractere especial (* ! _ : ?).");
    }

    private bool HaveUpperCase(string password)
    {
        return password.Any(char.IsUpper);
    }
    
    private bool HaveDigit(string password)
    {
        return password.Any(char.IsDigit);
    }
    
    private bool HaveSpecialCharacter(string password)
    {
        string specialCharacters = "*!_:?";
        return password.Any(c => specialCharacters.Contains(c));
    }
}