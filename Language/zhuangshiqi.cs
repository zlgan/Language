using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public interface Iweapen
    {
         List<string> skills { get; set; }
    }

    public class defaultwuqi : Iweapen
    {
        List<string> defSkill = new List<string> {"默认攻击方式"};

        public List<string> skills
        {
            get
            {
                return defSkill;
            }
            set
            {
                defSkill = value;
            }
        }
    }

    public class knife : Iweapen
    {
        private Iweapen myweapen;

        public knife(Iweapen weapon)
        {
            this.myweapen = weapon;
            myweapen.skills.Add("砍人");
        }

        public List<string> skills
        {
            get
            {
               
                return myweapen.skills;
            }
            set
            {
                skills = value;
            }
        }
    }
    public class gun : Iweapen
    {
        private Iweapen myweapen;

        public gun(Iweapen weapon)
        {
            this.myweapen = weapon;
            myweapen.skills.Add("射击");

        }

        public List<string> skills
        {
            get
            {
             
                return myweapen.skills;
            }
            set
            {
                skills = value;
            }
        }
    }

    //客户端代码
    public  class WeaponService
    {
        public void  Attack1()
        {
            Iweapen InitWepon1, InitWepon2, InitWepon3;
            //被装饰的对象
            InitWepon1 = new defaultwuqi();
            InitWepon2 = new gun(InitWepon1);
            InitWepon3 = new knife(InitWepon2);
            foreach (var s in InitWepon3.skills)
            {
                Console.WriteLine(s);
            }
        }
    }
}
