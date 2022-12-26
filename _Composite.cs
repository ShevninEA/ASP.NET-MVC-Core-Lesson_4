using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_MVC_Core_Lesson_4
{
    /// <summary>
    /// Composite
    /// </summary>
    internal class _Composite
    {
        static void Main(string[] args)
        {
            var root = new SimpleComposite("Root");
            var sub1 = new EndElement("End1");
            var sub2 = new SimpleComposite("Sub2");
            sub2.Add(new SimpleComposite("Sub3"));
            sub2.Add(new SimpleComposite("Sub4"));

            root.Add(sub1); 
            root.Add(sub2);

            root.Display();

            Console.ReadKey(true);
        } 
    }

    public abstract class Element
    {
        protected string name;

        public Element(string name)
        {
            this.name = name;
        }

        public abstract void Add(Element e);
        public abstract void Remove(Element e);
        public abstract void Display();
    }

    public class EndElement : Element
    {
        public EndElement(string name) : base(name)
        {
        }

        public override void Add(Element e)
        {
            throw new NotImplementedException();
        }

        public override void Display()
        {
            Console.WriteLine(name);
        }

        public override void Remove(Element e)
        {
            throw new NotImplementedException();
        }
    }

    public class SimpleComposite : Element
    {
        List<Element> childrenElements = new List<Element>();

        public SimpleComposite(string name) : base(name)
        {
        }

        public override void Add(Element e)
        {
            childrenElements.Add(e);
        }

        public override void Display()
        {
            Console.WriteLine(name);

            foreach (var child in childrenElements)
                child.Display();
        }

        public Element GetChild(int index)
        {
            if (index >= 0 && index < childrenElements.Count)
                return childrenElements[index];
            throw new IndexOutOfRangeException();
        }

        public override void Remove(Element e)
        {
            childrenElements.Remove(e);
        }
    }
}
