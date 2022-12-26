using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core_Lesson_4
{
    /// <summary>
    /// Facade
    /// </summary>
    public class _Facade
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade(new SystemA(),
                new SystemB(),
                new SystemC());

            facade.DoWork2();
            Console.ReadKey(true);
        }
    }

    public class Facade
    {
        private SystemA _systemA;
        private SystemB _systemB;
        private SystemC _systemC;

        public Facade(SystemA systemA, SystemB systemB, SystemC systemC)
        {
            _systemA = systemA;
            _systemB = systemB;
            _systemC = systemC;
        }   

        public void DoWork1()
        {
            _systemA.DoProcessA2();
            _systemA.DoProcessA3();
            _systemB.DoProcessB2();
            _systemC.DoProcessC();
        }

        public void DoWork2()
        {
            _systemB.DoProcessB2();
            _systemC.DoProcessC();
        }

        public void DoWork3()
        {
            _systemA.DoProcessA1();
            _systemC.DoProcessC();
        }

    }

    public class SystemA
    {
        public void DoProcessA1()
        {

        }

        public void DoProcessA2()
        {

        }

        public void DoProcessA3()
        {

        }
    }

    public class SystemB
    {
        public void DoProcessB1()
        {

        }

        public void DoProcessB2()
        {

        }
    }

    public class SystemC
    {
        public void DoProcessC()
        {

        }
    }
}
