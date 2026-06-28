using Microsoft.AspNetCore.Mvc;

namespace WMS.API.Controllers
{
    /// <summary>
    /// 测试控制器，用于验证 API 管道是否正常工作
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// 测试接口，返回 Hello WMS
        /// </summary>
        /// <returns>测试消息</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello WMS");
        }
    }
}
