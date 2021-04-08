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
    /// asp.net core��ʵ�ʾ���һ������̨����
    /// ��Git�ϲ鿴Դ�룺https://github.com/dotnet/aspnetcore/blob/release/3.1/src/Hosting/Hosting/src/WebHostBuilder.cs
    /// </summary>
    public class Program
    {
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)//��������ķ���������һ��IHostBuilder����
                .Build()//��IHostBuilder���󴴽�һ��IHost
                .Run();//�������洴����IHost���󣬴Ӷ��������ǵ�webӦ�ó��򣬻��仰˵��������һ��һֱ���м���http���������
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)//ʹ��Ĭ�ϵ�������Ϣ����ʼ��һ���µ� IHostBuilder����
                .ConfigureAppConfiguration((hostringContent,config)=> {
                    var env = hostringContent.HostingEnvironment;
                    config.AddJsonFile("appsettings.json", optional:true,reloadOnChange:true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                        .AddJsonFile("content.json",optional:false,reloadOnChange:true);//�����Զ����ļ���reloadOnChange��ʶ�б仯�Ƿ��Զ����¼���
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();//ΪHostָ����Startup��
                });
    }
}
