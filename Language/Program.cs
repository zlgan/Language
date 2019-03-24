using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    class Program
    {
        //TestThread.Test1();
        //TestThread.qiangpiao();
        //TestThread.AsyncForDelegate();

        //TestThread.parallelMethod();

        // //测试EF
        // NorthwindEntities db = new NorthwindEntities();
        // Customer cus = new Customer { CustomerID = "000111", ContactName = "zlgan",CompanyName="博彦科技"};
        // Customer cus2= new Customer { CustomerID = "12345", ContactName = "zlgan", CompanyName = "博彦科技" };
        ////新增数据方式一
        //// db.Customers.Add(cus);

        // //新增数据方式二
        // DbEntityEntry<Customer> entry= db.Entry<Customer>(cus2);
        // entry.State = System.Data.EntityState.Added;

        // // db.SaveChanges();

        // //LINQ查询
        // IQueryable<Customer> result = db.Customers.Where(u => u.ContactName == "zlgan").OrderBy(n => n.CustomerID);

        // Func<Customer, bool> condition = (Customer cus1) => { return cus1.ContactName == "zlgan"; };

        // //Console.Write(condition(cus));

        // //Console.ReadKey();
        // //return;
        // IQueryable<Customer> result2 = db.Customers.Where(n=>n.ContactName=="zlgan");
        // IEnumerable<Customer> result3 = db.Customers.Where(condition);

        /*
           Customers的数据类型的继承关系：
           DbSet<TEntity> : DbQuery<TEntity>, IDbSet<TEntity>, IQueryable<TEntity>, IEnumerable<TEntity>, IQueryable, IEnumerable, IInternalSetAdapter where TEntity : class
            以上两个方法的返回值并不相同，因为传入的参数不一样，框架选择了不同的方法调用；
            第一个实际调用的是System.Linq.Queryable.Where方法；
            第二个实际调用的是类Enumerable的扩展方法where，他是如何找到这个方法的呢？原来DbSet<TEntity>继承了IEnumerable<TEntity>，而静态类Enumerable上面的所有方法就是对上述接口的扩展

            结论：
           1、 扩展方法不仅可以用于类，也可以用于接口；但是对于接口的扩展不仅仅是声明方法签名，而且要有实现；也就是所有实现了被扩展到接口，自动拥有了已经实现的扩展方法。
           2、IQueryable和IEnumerable区别：前一个查询生成的是表达式树，在需要的时候才会去查询远程数据，后一个查询的是本地对象，也就是内存中的数据；
         */


        //简单查询
        //var collection = from c in db.Customers
        //                 where c.ContactName == "zlgan"
        //                 orderby c.CustomerID descending
        //                 select c;

        //Console.WriteLine(collection);//sql语句

        //foreach (var c in collection)//集合
        //{
        //    Console.WriteLine(c.CustomerID);
        //}

        // Console.WriteLine(collection);//sql语句

        /*
          collection只是个查询的定义，打印出来的是一个select语句，但是在遍历的时候却又是一个集合；某种意义来讲他们是的等价的。
         */

        //var a = collection.Skip(1).Take(1);

        //foreach (var c in a)//集合
        //{
        //    Console.WriteLine(c.CustomerID);
        //}

        //链接查询

        //var b = from c in db.Customers
        //        join o in db.Orders
        //        on c.CustomerID equals o.CustomerID
        //        group new { c, o } by new { c.CompanyName } into g
        //        select new
        //        {
        //            SName = g.Key.CompanyName,
        //            Sex = "男"
        //        };

        //foreach (var c in b)//集合
        //{
        //    Console.WriteLine(c.SName+"--"+c.Sex);
        //}
        //Console.ReadKey();
        // Lang4.test();
        //Lang4.Express();



        //UnsafePerson p = new UnsafePerson();
        //p.TestUnsafe();


        //string aa = ConfigurationManager.AppSettings["CommandTimeout"].ToString().Trim();
        //Console.WriteLine(aa);

        // Language._1._0.Client cli = new _1._0.Client();
        public static void Main(string[] args)
        {
            //Language._1._0.Client cli = new _1._0.Client();
            //cli.Run();

            Language.反射和动态编译.FormularCalculation client = new 反射和动态编译.FormularCalculation();

            client.Run();




            Console.ReadKey();

            

        }
    }
}
