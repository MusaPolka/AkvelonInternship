using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncTask
{
    internal class Downloader
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task Download(string url, string path)
        {
            Console.WriteLine("Start Downloading...");

            var response = await client.GetAsync(url);

            Console.WriteLine("Got the file!!!");

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await response.Content.CopyToAsync(fileStream);
            }

            Console.WriteLine("Saved it!!!");
        }

        /* using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue | DebuggableAttribute.DebuggingModes.DisableOptimizations)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
public class C
{
    [CompilerGenerated]
    private sealed class <M>d__0 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder <>t__builder;

        public C <>4__this;

        private TaskAwaiter <>u__1;

        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
                TaskAwaiter awaiter;
                if (num != 0)
                {
                    awaiter = <>4__this.Download("https://file-examples.com/storage/fe1170c1cf625dc95987de5/2017/10/file_example_PNG_500kB.png", "E:\\downloads\\1.png").GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <M>d__0 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter);
                    num = (<>1__state = -1);
                }
                awaiter.GetResult();
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    [CompilerGenerated]
    private sealed class <Download>d__2 : IAsyncStateMachine
    {
        public int <>1__state;

        public AsyncTaskMethodBuilder <>t__builder;

        public string url;

        public string path;

        public C <>4__this;

        private HttpResponseMessage <response>5__1;

        private HttpResponseMessage <>s__2;

        private FileStream <fileStream>5__3;

        private TaskAwaiter<HttpResponseMessage> <>u__1;

        private TaskAwaiter <>u__2;

        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
                TaskAwaiter<HttpResponseMessage> awaiter;
                if (num != 0)
                {
                    if (num == 1)
                    {
                        goto IL_00c4;
                    }
                    Console.WriteLine("Start Downloading...");
                    awaiter = client.GetAsync(url).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <Download>d__2 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter<HttpResponseMessage>);
                    num = (<>1__state = -1);
                }
                <>s__2 = awaiter.GetResult();
                <response>5__1 = <>s__2;
                <>s__2 = null;
                Console.WriteLine("Got the file!!!");
                <fileStream>5__3 = new FileStream(path, FileMode.Create);
                goto IL_00c4;
                IL_00c4:
                try
                {
                    TaskAwaiter awaiter2;
                    if (num != 1)
                    {
                        awaiter2 = <response>5__1.Content.CopyToAsync(<fileStream>5__3).GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            num = (<>1__state = 1);
                            <>u__2 = awaiter2;
                            <Download>d__2 stateMachine = this;
                            <>t__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter2 = <>u__2;
                        <>u__2 = default(TaskAwaiter);
                        num = (<>1__state = -1);
                    }
                    awaiter2.GetResult();
                }
                finally
                {
                    if (num < 0 && <fileStream>5__3 != null)
                    {
                        ((IDisposable)<fileStream>5__3).Dispose();
                    }
                }
                <fileStream>5__3 = null;
                Console.WriteLine("Saved it!!!");
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <response>5__1 = null;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <response>5__1 = null;
            <>t__builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }

    private static readonly HttpClient client = new HttpClient();

    [AsyncStateMachine(typeof(<M>d__0))]
    [DebuggerStepThrough]
    public Task M()
    {
        <M>d__0 stateMachine = new <M>d__0();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }

    [AsyncStateMachine(typeof(<Download>d__2))]
    [DebuggerStepThrough]
    public Task Download(string url, string path)
    {
        <Download>d__2 stateMachine = new <Download>d__2();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.url = url;
        stateMachine.path = path;
        stateMachine.<>1__state = -1;
        stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
}
*/
    }
}
