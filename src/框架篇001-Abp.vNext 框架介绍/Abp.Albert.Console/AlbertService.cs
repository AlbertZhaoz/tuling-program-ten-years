using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Abp.Albert.Console
{
    [Dependency(ServiceLifetime.Scoped)]
    public class AlbertService
    {
        public void SayHello()
        {
            System.Console.WriteLine("Say hello");
        }
    }
}
