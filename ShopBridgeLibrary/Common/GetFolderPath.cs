using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopBridgeLibrary.Common
{
    public class GetFolderPath
    {
        public static string loRootPath;
       
        public GetFolderPath(IConfiguration config)
        {
            loRootPath = config.GetValue<string>("GetFolderPath:RootFolder");
        }
    }
}
