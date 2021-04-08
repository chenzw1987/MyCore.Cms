using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Controllers
{
    /// <summary>
    /// Content控制器
    /// </summary>
    public class ContentController : Controller
    {
        private readonly Content content;
        /// <summary>
        /// 构造函数注入，Content对象
        /// 通过IOption容器注入【由容器统一的管理实例的创建和销毁】，容器创建的对象是有生命周期的
        /// 生命周期：
        /// Transient:每次访问都会创建一个新的
        /// Scoped:每一个请求里创建一个
        /// Singleton:跟应用程序生命周期一样，只有一个
        /// </summary>
        /// <param name="option"></param>
        public  ContentController(IOptions<Content> option)
        {
            content = option.Value;
        }
        /// <summary>
        /// 首页显示
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var contents = new List<Content>();
            //for (int i = 1; i < 11; i++)
            //{
            //    contents.Add(new Content {Id=i,title=$"{i}的标题" ,content=$"{i}的内容",status=1,add_time=DateTime.Now.AddDays(-1)});
            //}
            contents.Add(content);


            return View(new ContentViewModel { Contents = contents});
        }
    }
}
