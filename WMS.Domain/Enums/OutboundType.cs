namespace WMS.Domain.Enums
{
    /// <summary>
    /// 出库类型枚举，定义不同的出库业务场景
    /// </summary>
    public enum OutboundType
    {
        /// <summary>
        /// 销售出库：销售订单发货出库
        /// </summary>
        Sales = 0,

        /// <summary>
        /// 调拨出库：调拨至其他仓库出库
        /// </summary>
        Transfer = 1,

        /// <summary>
        /// 报废出库：商品报废出库
        /// </summary>
        Scrap = 2,

        /// <summary>
        /// 其他出库：其他特殊出库场景
        /// </summary>
        Other = 3
    }
}
