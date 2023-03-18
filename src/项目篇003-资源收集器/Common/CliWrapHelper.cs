using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;

namespace NET_FiveMinutes_006_AlbertToolHelperDesktop.Common
{
    public class CliWrapHelper
    {
        /// <summary>
        /// 运行指令，路径
        /// </summary>
        /// <param name="args"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<CommandResult> CallPowerShell(string args,string path)
        {
            var result =  await Cli.Wrap("powershell")
                .WithArguments(args)
                .WithWorkingDirectory(path)
                .ExecuteAsync();
            return result;
        }

        /// <summary>
        /// 提交评论，git路径
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static async Task<(string,string)> CallGit(string comment,string path)
        {
            var gitResult = await  Cli.Wrap("git")
                .WithArguments("add .")
                .WithWorkingDirectory(path)
                .WithValidation(CommandResultValidation.None)
                .ExecuteBufferedAsync();

            var gitResult2 = await  Cli.Wrap("git")
                .WithArguments($"commit -m \"{comment}\"")
                .WithWorkingDirectory(path)
                .WithValidation(CommandResultValidation.None)
                .ExecuteBufferedAsync();

            var gitResult3 = await  Cli.Wrap("git")
                .WithArguments("push")
                .WithWorkingDirectory(path)
                .WithValidation(CommandResultValidation.None)
                .ExecuteBufferedAsync();

            var stdOut = gitResult.StandardOutput+ gitResult2.StandardOutput+ gitResult3.StandardOutput;
            var stdErr = gitResult.StandardError+gitResult2.StandardError+gitResult3.StandardError;

            return (stdOut,stdErr);
        }
    }
}
