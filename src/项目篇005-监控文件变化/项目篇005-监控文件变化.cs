using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;

namespace NET_FiveMinutes
{
    public static class NET001_MonitorFileChanged
    {
        public static void Run()
        {
            var sp = new ServiceCollection()
                .AddSingleton<IFileProvider>(new PhysicalFileProvider(Environment.CurrentDirectory))
                .AddScoped<FileManager>()
                .BuildServiceProvider();

            sp.GetService<FileManager>()?.WatchAsync("Text.txt").Wait();
            Console.ReadLine();

        }

        public class FileManager
        {
            public readonly IFileProvider _fileProvider;

            public FileManager(IFileProvider fileProvider)
            {
                _fileProvider = fileProvider;
            }

            public async Task WatchAsync(string path)
            {
                Console.WriteLine(await ReadAsync(path));
                ChangeToken.OnChange(() => _fileProvider.Watch(path), async () =>
                {
                    Console.Clear();
                    Console.WriteLine(await ReadAsync(path));
                });
            }

            public async Task<string> ReadAsync(string path)
            {
                await using var stream = _fileProvider.GetFileInfo(path).CreateReadStream();
                var buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer);
            }
        }
    }
}
