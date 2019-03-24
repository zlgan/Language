using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Language.反射和动态编译
{
    public class FormularCalculation: ClientBase
    {
        public static object Build(string[] items, string formular)
        {
            string nameSpace = "A";
            string className = "FormularCalculation";
            string methodName = "Run";
            CSharpCodeProvider compiler = new CSharpCodeProvider();
            CompilerParameters paras = new CompilerParameters();
            paras.GenerateExecutable = false;
            paras.GenerateInMemory = true;

            StringBuilder classSrc = new StringBuilder();
            classSrc.Append(" using  System;" + Environment.NewLine);
            classSrc.Append(" namespace " + nameSpace + " { " + Environment.NewLine);
            classSrc.Append("public  class  " + className + "{ " + Environment.NewLine);
            foreach (string item in items)
            {
                classSrc.Append("public decimal " + item + "{get;set;}" + Environment.NewLine);
            }
            classSrc.Append("public  void Run() { 基本工资=5000; " + Environment.NewLine);
            string[] format = Regex.Split(formular, Environment.NewLine);
            foreach (string prop in format)
            {
                classSrc.Append(prop + " ;" + Environment.NewLine);
            }
            classSrc.Append("}" + Environment.NewLine);
            classSrc.Append("}" + Environment.NewLine);
            classSrc.Append("}" + Environment.NewLine);
            string source = classSrc.ToString();

            CompilerResults result = compiler.CompileAssemblyFromSource(paras, source);
            CompilerErrorCollection error = result.Errors;
            Assembly assembly = result.CompiledAssembly;
            object eval = assembly.CreateInstance(nameSpace + "." + className);
            MethodInfo method = eval.GetType().GetMethod(methodName);
            object reobj = method.Invoke(eval, null);
            return eval;
        }

        public  override void Run()
        {
            base.Run();


            string[] items = { "应发合计", "基本工资", "奖金", "福利费", "扣款合计", "社保", "税", "实发合计", "应税所得额" };
            string formular = @"应发合计 = (基本工资 + 奖金 + 福利费 - 扣款合计)*2;
                                扣款合计 = 社保 + 税 + 应税所得额;
                                实发合计 = 应发合计 - 扣款合计;";


            object obj = FormularCalculation.Build(items, formular);
            Type type = obj.GetType();
            foreach (PropertyInfo fi in type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public
                                               | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                string value = fi.Name;  //取到计算后的各个属性的值 

                Console.WriteLine($"{ fi.Name}: {fi.GetValue(obj)}");
            }
        }
    }

}
