using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language._1._0
{
    //委托的定义
    public delegate decimal Add(int x, int y);

    public class ClickEventArgs : EventArgs
    {
        public string UserName { get; set; }
    }

    public class Adder
    {
        //声明一个事件
        public event Add addEvent;
        //声明一个委托
        public Add addDelegate;


        //标准事件
        public event EventHandler click;

        public void OnClick()
        {
            //事件和委托都可以在本类中调用，没有差异。
            addEvent(1, 2);
            addDelegate(1, 2);
            //

            ClickEventArgs e = new ClickEventArgs();
            e.UserName = "xiaogang";
            click?.Invoke(this, e);
        }
    }



    public class Client
    {
        event EventHandler run;
        
        public void Run()
        {
            Adder adder = new Adder();
            adder.addDelegate += Adder_add;
            adder.addEvent += Adder_add;
            adder.addDelegate(1, 2);
            //事件不能再外部调用，只能从外部注册，委托则不受此限制
            //adder.addEvent(1, 2);


            //事件标准注册调用方法
            adder.click += Adder_click;
            adder.OnClick();
        }

        private void Adder_click(object sender, EventArgs e)
        {
            ClickEventArgs arg = (ClickEventArgs)e;
            Console.WriteLine(arg.UserName);
        }

        private decimal Adder_add(int x, int y)
        {
            
            return  x + y;
        }
    }
}
