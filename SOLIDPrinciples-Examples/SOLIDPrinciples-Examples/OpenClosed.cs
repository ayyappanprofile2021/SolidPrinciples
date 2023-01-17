using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples_Examples
{
    public enum Color
    {
        Red,
        Green,
        Blue,
    }

    public enum Size
    {
        Small,
        Medium,
        Large,
    }

    public class Product
    {
        public string ?Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
    }

    public interface ISpecification<T>
    {
        bool IsMatch(T product);
    }

    public class ColorSpecification:ISpecification<Product>
    {
        private Color Color { get; set; }
        public ColorSpecification(Color color)
        {
            this.Color = color;
        }
        public bool IsMatch(Product product)
        {
            return product.Color == this.Color;
        }
    }

    public class SizeSpecification:ISpecification<Product>
    {
        private Size Size { get; set; }
        public SizeSpecification(Size size)
        {
            this.Size = size;
        }

        public bool IsMatch(Product product)
        {
            return product.Size == this.Size;
        }
    }

    public class AndSpecification<T>:ISpecification<T>
    {
        private ISpecification<T> First { get; set; }

        private ISpecification<T> Last { get; set; }

        public AndSpecification(ISpecification<T> first, ISpecification<T> last)
        {
            First = first;
            Last = last;    
        }

        public bool IsMatch(T item)
        {
            return this.First.IsMatch(item) && this.Last.IsMatch(item);
        }
    }

    public class OrSpecification<T>:ISpecification<T>
    {
        public ISpecification<T> First { get; set; }

        public ISpecification<T> Second { get; set; }

        public OrSpecification(ISpecification<T> first, ISpecification<T> second)
        {
            this.First = first;
            this.Second = second;
        }
        public bool IsMatch(T item)
        {
            return this.First.IsMatch(item) || this.Second.IsMatch(item);
        }
    }


    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }

    public class BetterFilter:IFilter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
        {
            foreach(Product product in items)
                if (spec.IsMatch(product))
                    yield return product;            
        }
    }

}
