using FluentValidation;
using WMS.Application.DTOs;

namespace WMS.Application.Validators
{
    /// <summary>
    /// 登录请求校验器，验证用户名和密码的格式要求
    /// </summary>
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            // 用户名不能为空，长度 2-50
            RuleFor(x => x.username)
                .NotEmpty().WithMessage("用户名不能为空")
                .Length(2, 50).WithMessage("用户名长度必须在2到50个字符之间");

            // 密码不能为空，最短6位
            RuleFor(x => x.password)
                .NotEmpty().WithMessage("密码不能为空")
                .MinimumLength(6).WithMessage("密码长度不能少于6个字符");
        }
    }
}
