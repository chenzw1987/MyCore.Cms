using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample
{
    /// <summary>
    /// asp.net core：实际就是一个控制台程序
    /// 在Git上查看源码：https://github.com/dotnet/aspnetcore/blob/release/3.1/src/Hosting/Hosting/src/WebHostBuilder.cs
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)//调用下面的方法，返回一个IHostBuilder对象
                .Build()//用IHostBuilder对象创建一个IHost
                .Run();//运行上面创建的IHost对象，从而运行我们的web应用程序，换句话说就是启动一个一直运行监听http请求的任务
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)//使用默认的配置信息来初始化一个新的 IHostBuilder对象
                .ConfigureAppConfiguration((hostringContent,config)=> {
                    var env = hostringContent.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional:true,reloadOnChange:true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile("content.json",optional:false,reloadOnChange:true);//配置自定义文件，reloadOnChange标识有变化是否自动更新加载
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();//为Host指定了Startup类
                });
    }
}
