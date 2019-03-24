using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    //task
    public class bingxing
    {
        public static void  dowork()
        {
            string[] messages = { "First task", "Second task","Third task", "Fourth task" };
            foreach (string msg in messages)
            {
                //不明白
                Task myTask = new Task(obj => printMessage((string)obj), msg);
                myTask.Start();
            }
            // wait for input before exiting
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();
        }

        static void printMessage(string message)
        {
            Console.WriteLine("Message: {0}", message);
        }


        public static void TestRetValue()
        {
            Task<int> tt = Task.Factory.StartNew<int>(() => { 
                int ret = 0;
                for (int i = 0; i < 100; i++)
                {
                    ret += i;
                }
                System.Threading.Thread.Sleep(3000);
                return ret;
            });

            tt.Wait();
            Console.WriteLine(tt.Result);
            Console.WriteLine("主线程结束");
        }


    }

    //async,await
    public class AsyncTest
    {
        public static void test()
        {
            Console.WriteLine("主线程测试开始.." + Thread.CurrentThread.ManagedThreadId.ToString());
            AsyncMethod();
            Console.WriteLine("主线程测试结束.." + Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(2000);
            Console.ReadLine();
        }

        static async void AsyncMethod()
        {
            Console.WriteLine("AsyncMethod开始" + Thread.CurrentThread.ManagedThreadId.ToString());
            var result = await MyMethod();
            Console.WriteLine("AsyncMethod结束" + Thread.CurrentThread.ManagedThreadId.ToString());
        }

        static async Task<int> MyMethod()
        {
            Console.WriteLine("MyMethod开始：" + Thread.CurrentThread.ManagedThreadId.ToString());
            await Task.Delay(50);
            Console.WriteLine("MyMethod结束：" + Thread.CurrentThread.ManagedThreadId.ToString());
            return 0;
        }
    }
   }
