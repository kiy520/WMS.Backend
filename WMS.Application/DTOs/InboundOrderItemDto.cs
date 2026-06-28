namespace WMS.Application.DTOs
{
    /// <summary>
    /// 入库单明细 DTO
    /// </summary>
    public class InboundOrderItemDto
    {
        /// <summary>
        /// 明细 Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 商品 Id
        /// </summary>
        public int productId { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        public string productCode { get; set; } = string.Empty;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string productName { get; set; } = string.Empty;

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
