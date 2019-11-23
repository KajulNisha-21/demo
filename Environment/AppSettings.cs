using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webapi_Microservices_Docker.Environment
{
    public class AppSettings : IAppSettings
    {
        public string EnvKey { get ; set; }
    }
}
