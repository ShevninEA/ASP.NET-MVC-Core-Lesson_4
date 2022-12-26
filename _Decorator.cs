using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core_Lesson_4
{
    /// <summary>
    /// Decorator
    /// </summary>
    internal class _Decorator
    {
        static void Main(string[] args)
        {
            FinalWorkDecoratorComponent finalWorkDecoratorComponent1 = new FinalWorkDecoratorComponent();
            finalWorkDecoratorComponent1.DoWork();

            finalWorkDecoratorComponent1.SetComponent(new WorkComponent());
            finalWorkDecoratorComponent1.DoWork();

            Console.ReadKey(true);
        }
    }

    public abstract class BaseComponent
    {
        public abstract void DoWork();
    }

    public class WorkComponent : BaseComponent
    {
        public override void DoWork()
        {
            Console.WriteLine("Do work [WorkComponent] ...");
        }
    }

    /// <summary>
    /// Базовый интерфейс декоратора
    /// </summary>
    public abstract class WorkDecoratorComponent : BaseComponent
    {
        private BaseComponent _baseComponent;

        public void SetComponent(BaseComponent baseComponent)
        {
            _baseComponent = baseComponent; 
        }

        public override void DoWork()
        {
            if (_baseComponent != null)
                _baseComponent.DoWork();
            else
                Console.WriteLine("Do work [WorkDecoratorComponent] ...");
        }
    }
    public class FinalWorkDecoratorComponent : WorkDecoratorComponent { }
}
