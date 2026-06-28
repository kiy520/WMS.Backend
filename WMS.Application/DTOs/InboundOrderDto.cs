namespace WMS.Application.DTOs
{
    /// <summary>
    /// 入库单 DTO，用于入库单信息的传输
    /// </summary>
    public class InboundOrderDto
    {
        /// <summary>
        /// 入库单 Id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string orderNo { get; set; } = string.Empty;

        /// <summary>
        /// 入库类型
        /// </summary>
        public int inboundType { get; set; }

        /// <summary>
        /// 入库类型描述
        /// </summary>
        public string inboundTypeName { get; set; } = string.Empty;

        /// <summary>
        /// 订单状态
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 订单状态描述
        /// </summary>
        public string statusName { get; set; } = string.Empty;

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string? supplier { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? remark { get; set; }

        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string operatorName { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createdAt { get; set; }

        /// <summary>
        /// 入库单明细列表
        /// </summary>
        public List<InboundOrderItemDto> items { get; set; } = new();
    }
}
