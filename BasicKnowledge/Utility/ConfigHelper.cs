using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utility
{
    public static class ConfigHelper
    {
        /// <summary>
        /// 读取appsettings.json配置
        /// 调用：string str=ConfigHelper.GetAppSettings("ReflectSection:Two:Three");
        /// </summary>
        /// <param name="domTree">完整的节点路径</param>
        /// <returns></returns>
        public static string  GetAppSettings(string domTree)
        {
            try
            {
                var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

                var config = builder.Build();
                return config[domTree];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
