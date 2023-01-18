/*
      Square type is replaced with Rectangle as 'Rectangle rectangle = new Square'
      to call the implementaion of Square by overriding the Width/Height properties.
*/
namespace SOLIDPrinciples_Examples
{
    public class Rectangle
    {
        public virtual int Width { get; set; }  
        public virtual int Height { get; set; }

        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }
        int Area() => this.Width * this.Height;

        public override string ToString()
        {
            return $"Height: {this.Height}, Width: {this.Width} and Area: {Area()}";
        }
    }

    public class Square:Rectangle
    {
        public override int Width
        {
            set { base.Width= base.Height = value;}  
        }
        public override int Height
        {
            set { base.Height= base.Width = value;}  
        }
    }

}
