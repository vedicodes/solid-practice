namespace SolidConsoleApp
{
    public class Rectangle
    {
        int height { get; set; }
        int width { get; set; }

        public virtual void SetHeight(int height)
        {
            this.height = height;
        }
        public virtual void SetWidth(int width)
        {
            this.width = width;
        }
        public int Area()
        {
            return height * width;
        }
    }

    public class Square : Rectangle // To implement correct behaviour of Square class we have to override SetHeight and SetWidth methods.
    {
        public override void SetHeight(int height)
        {
            base.SetHeight(height);
            base.SetWidth(height);
        }

        public override void SetWidth(int width)
        {
            base.SetHeight(width);
            base.SetWidth(width);
        }

        //The Rectangle/Square hierarchy violates the Liskov Substitution Principle (LSP)! Square is behaviorally not a correct substitution for Rectangle.
        //A Square does not comply with the behavior of a rectangle: Changing the height/width of a square behaves differently from changing the height/width of a rectangle
    }

    public interface Shape
    {
        public int Area();
    }

    public class AfterRectangle : Shape
    {
        int height { get; set; }
        int width { get; set; }

        public AfterRectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }
        public void SetWidth(int width)
        {
            this.width = width;
        }
        public int Area()
        {
            return height * width;
        }
    }

    public class AfterSquare : Shape
    {
        int size { get; set; }

        public AfterSquare(int size)
        {
            this.size = size;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }
        public int Area()
        {
            return size * size;
        }
    }

    public class LiskovSubstitution
    {
        public static void Run()
        {
            Shape shape = new AfterRectangle(10, 20);
            ShowArea(shape);
            shape = new AfterSquare(10);
            ShowArea(shape);
        }
        public static void ShowArea(Shape shape)
        {
            Console.WriteLine("{0}", shape.Area());
        }
    }
}
