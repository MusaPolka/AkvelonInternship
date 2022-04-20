using System;
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

//This is the state of our machine (-1, 0,1,2… -2)      
 public int <>1__state;

//Here, builder is generated, it has Start() mothod that will call MoveNext()
        public AsyncTaskMethodBuilder <>t__builder;

        public C <>4__this;

        private TaskAwaiter <>u__1;

//This is main method that is going to run one or multiple times
//Depending on await calls
        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
                TaskAwaiter awaiter;

//If the state of our machine is not set to Start, it enters this statement
//It is always starts with state set to -1

                if (num != 0)
                {

//Here, it awaits the task by using synchronic GetAwaiter()
//As you can see, it calls Download method, so first, it starts our Download method

                    awaiter = <>4__this.Download("https://file-examples.com/storage/fe1170c1cf625dc95987de5/2017/10/file_example_PNG_500kB.png", "E:\\downloads\\1.png").GetAwaiter();


//After our task is completed without any errors, it enters this statement
                    if (!awaiter.IsCompleted)
                    {

//When it’s done, it sets the state to 0, which means Start state
                        num = (<>1__state = 0);

//It initialize our TaskAwaiter to the task that is completed
                        <>u__1 = awaiter;
                        <M>d__0 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);

//It returns back, and MoveNext method will be called again
                        return;
                    }
                }
//Our state is equal to 0 now, so it skips if statement, and enters else                
                else
                {

                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter);
                    num = (<>1__state = -1);
                }

//At the end, it just takes the results from our task
                awaiter.GetResult();
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }

//Also here, it gives the value of -2 to state, which means that method is finished 
//working            
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

//This part is basicly creating variables, and all the stuff that we created in our method

        public int <>1__state;


//Here, builder is generated, it has Start() mothod that will call MoveNext()
        public AsyncTaskMethodBuilder <>t__builder;

        public string url;

        public string path;

        public C <>4__this;

        private HttpResponseMessage <response>5__1;

        private HttpResponseMessage <>s__2;

        private FileStream <fileStream>5__3;

        private TaskAwaiter<HttpResponseMessage> <>u__1;

        private TaskAwaiter <>u__2;


//This is main method that is going to run one or multiple times
//Depending on await calls
        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
                TaskAwaiter<HttpResponseMessage> awaiter;

//If the state of our machine is not set to Start, it enters this statement
//It is always starts with state set to -1
                if (num != 0)
                {
                    if (num == 1)
                    {
                        goto IL_00c4;
                    }

//Here, it writes some stuff to the console and awaits the task by using synchronic 
//GetAwaiter()
                    Console.WriteLine("Start Downloading...");
                    awaiter = client.GetAsync(url).GetAwaiter();

//After our task is completed without any errors, it enters this statement
                    if (!awaiter.IsCompleted)
                    {

//When it’s done, it sets the state to 0, which means Start state
                        num = (<>1__state = 0);

//It initialize our TaskAwaiter to the task that is completed
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

//After some manipulations with state, it gets the result and does some sync work
                <>s__2 = awaiter.GetResult();
                <response>5__1 = <>s__2;
                <>s__2 = null;
                Console.WriteLine("Got the file!!!");
                <fileStream>5__3 = new FileStream(path, FileMode.Create);
                goto IL_00c4;
                IL_00c4:
                try
                {
//Here we have the second part of our method, it does the same work as the first part
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

//Also here, it gives the value of -2 to state, which means that method is finished 
//working   
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

   
//Method to create and start our state machine for Main method 
[AsyncStateMachine(typeof(<M>d__0))]
    [DebuggerStepThrough]
    public Task M()
    {
//It creates state machine
        <M>d__0 stateMachine = new <M>d__0();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.<>1__state = -1;
       
//And then, it calls Start() method that will call MoveNext () method 

stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }

   
//Method to create and start our state machine for Download method  

[AsyncStateMachine(typeof(<Download>d__2))]
    [DebuggerStepThrough]
    public Task Download(string url, string path)
    {
//It creates state machine
        <Download>d__2 stateMachine = new <Download>d__2();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder.Create();
        stateMachine.<>4__this = this;
        stateMachine.url = url;
        stateMachine.path = path;
        stateMachine.<>1__state = -1;
       
//And then, it calls Start() method that will call MoveNext () method 
stateMachine.<>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
}
