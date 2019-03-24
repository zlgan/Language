using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestThread
    {

        static int ticketCount = 10;

        static object obj = new object();

        public static void bookTicket()
        {
            //object obj = new object();
            //注意这个obj一定要是所有访问线程共享的变量，而不是每个线程各自堆栈上的变量
            lock (obj)
            {
                if (ticketCount > 0)
                {
                    Thread.Sleep(100);
                    Console.WriteLine("剩余" + ticketCount.ToString() + "张票");
                    ticketCount--;
                }
                else
                {
                    Console.WriteLine("票已经订完!");
                }
            }
            
        }

        //thread 的异步的方式
        public static void  Test1()
        {
            Thread t = new Thread(() =>
            {
                for
                (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(200);
                    Console.Write("a");
                }
            });

            t.Start();

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(20);
                Console.Write("b");
            }
        }

        //thread的同步
        public static void qiangpiao()
        {
            Thread thr = null;
            for (int i = 0; i < 30; i++)
            {
                thr = new Thread(new ThreadStart(bookTicket));
                thr.Start();
            }
        }

        //使用委托的方式启动异步
        public static void AsyncForDelegate()
        {
            Func<int> act = () =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(100);
                    Console.Write(" a"+i);

                }
                return 10;
            };

           IAsyncResult res= act.BeginInvoke((result)=> {
               var ret = act.EndInvoke(result);
               Console.WriteLine("异步返回的结果是" + ret);
           }, null);

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(50);
                Console.Write(" b" + i);

            }

        }

        //并行的方式
        public static void parallelMethod()
        {
            Action a1 = () => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(" a" + i.ToString());
                }
            };

            Action b1 = () => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(" b" + i.ToString());
                }
            };

            Action c1 = () => {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(" c" + i.ToString());
                }
            };


            Action[] tt= { a1,b1,c1};
            Parallel.Invoke(tt);
        }

     
        
    }
}
