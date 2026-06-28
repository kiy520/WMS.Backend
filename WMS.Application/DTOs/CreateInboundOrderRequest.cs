using WMS.Domain.Enums;

namespace WMS.Application.DTOs
{
    /// <summary>
    /// 创建入库单请求 DTO
    /// </summary>
    public class CreateInboundOrderRequest
    {
        /// <summary>
        /// 入库类型
        /// </summary>
        public InboundType inboundType { get; set; }

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string? supplier { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? remark { get; set; }

        /// <summary>
        /// 入库单明细列表
        /// </summary>
        public List<CreateInboundOrderItemRequest> items { get; set; } = new();
    }

    /// <summary>
    /// 创建入库单明细请求 DTO
    /// </summary>
    public class CreateInboundOrderItemRequest
    {
        /// <summary>
        /// 商品 Id
        /// </summary>
        public int productId { get; set; }

        /// <summary>
        /// 入库数量
        /// </summary>
        public int quantity { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? remark { get; set; }
    }
}
