namespace WMS.Domain.Enums
{
    /// <summary>
    /// 入库类型枚举，定义不同的入库业务场景
    /// </summary>
    public enum InboundType
    {
        /// <summary>
        /// 采购入库：从供应商采购商品入库
        /// </summary>
        Purchase = 0,

        /// <summary>
        /// 退货入库：客户退货商品入库
        /// </summary>
        Return = 1,

        /// <summary>
        /// 调拨入库：从其他仓库调拨入库
        /// </summary>
        Transfer = 2,

        /// <summary>
        /// 其他入库：其他特殊入库场景
        /// </summary>
        Other = 3
    }
}
