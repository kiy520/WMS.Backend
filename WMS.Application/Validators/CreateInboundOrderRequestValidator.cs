using FluentValidation;
using WMS.Application.DTOs;

namespace WMS.Application.Validators
{
    /// <summary>
    /// 创建入库单请求校验器，验证入库单整体和明细的格式要求
    /// </summary>
    public class CreateInboundOrderRequestValidator : AbstractValidator<CreateInboundOrderRequest>
    {
        public CreateInboundOrderRequestValidator()
        {
            // 入库单必须包含至少一条明细
            RuleFor(x => x.items)
                .NotEmpty().WithMessage("入库单必须包含至少一条明细");

            // 入库类型必须在枚举范围内
            RuleFor(x => x.inboundType)
                .IsInEnum().WithMessage("入库类型无效");

            // 对每条明细进行校验
            RuleForEach(x => x.items).ChildRules(items =>
            {
                items.RuleFor(i => i.productId)
                    .GreaterThan(0).WithMessage("商品Id必须大于0");
                items.RuleFor(i => i.quantity)
                    .GreaterThan(0).WithMessage("入库数量必须大于0");
            });
        }
    }
}
