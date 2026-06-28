using FluentValidation;
using WMS.Application.DTOs;

namespace WMS.Application.Validators
{
    /// <summary>
    /// 创建商品请求校验器，验证商品编码、名称等字段的格式要求
    /// </summary>
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            // 商品编码不能为空，长度 1-50
            RuleFor(x => x.code)
                .NotEmpty().WithMessage("商品编码不能为空")
                .Length(1, 50).WithMessage("商品编码长度必须在1到50个字符之间");

            // 商品名称不能为空，长度 1-100
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("商品名称不能为空")
                .Length(1, 100).WithMessage("商品名称长度必须在1到100个字符之间");

            // 计量单位不能为空
            RuleFor(x => x.unit)
                .NotEmpty().WithMessage("计量单位不能为空")
                .MaximumLength(20).WithMessage("计量单位长度不能超过20个字符");

            // 安全库存不能为负数
            RuleFor(x => x.safetyStock)
                .GreaterThanOrEqualTo(0).WithMessage("安全库存不能为负数");
        }
    }
}
