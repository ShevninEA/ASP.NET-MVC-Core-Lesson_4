using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core_Lesson_4
{
    /// <summary>
    /// Proxy
    /// </summary>
    internal class _Proxy
    {
        static void Main(string[] args)
        {
            new Proxy().Request();
            Console.ReadKey(true);
        }
    }

    public abstract class BaseSampleObj
    {
        public abstract void Request();
    }

    public class SampleObj : BaseSampleObj
    {
        public override void Request()
        {
            Console.WriteLine("Do request ...");
        }
    }

    public class Proxy : BaseSampleObj
    {
        private BaseSampleObj _baseSampleObj;

        public override void Request()
        {
            if (_baseSampleObj == null)
                _baseSampleObj = new SampleObj();
            _baseSampleObj.Request();
        }
    }
}
