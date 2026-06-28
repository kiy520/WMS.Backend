namespace WMS.Domain.Enums
{
    /// <summary>
    /// 订单状态枚举，定义订单在业务流程中的各阶段状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待处理：订单已创建，尚未开始执行
        /// </summary>
        Pending = 0,

        /// <summary>
        /// 处理中：订单正在执行
        /// </summary>
        Processing = 1,

        /// <summary>
        /// 已完成：订单已成功执行
        /// </summary>
        Completed = 2,

        /// <summary>
        /// 已取消：订单已被取消
        /// </summary>
        Cancelled = 3
    }
}
