using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SOLIDPrinciples_Examples
{
    public static class Caller
    {
        public static void CallSingleResponsibility()
        {
            Journal journal = new Journal();
            journal.AddEntry("Have a good day!");
            journal.AddEntry("All the Best!");
            WriteLine(journal);
            Persistence persistence = new Persistence();
            persistence.Save(journal, "C:\\Ayyappan\\Learnings\\SolidPrinciples\\SolidPrinciples\\SOLIDPrinciples-Examples\\Test.txt", true);
        }

        public static void CallOpenClosed()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Name = "LipStick", Color = Color.Red, Size = Size.Small });
            products.Add(new Product() { Name = "Tree", Color = Color.Green, Size = Size.Medium });
            products.Add(new Product() { Name = "Building", Color = Color.Blue, Size = Size.Large });
            ISpecification<Product> colorSpecification = new ColorSpecification(Color.Green);
            ISpecification<Product> sizeSpecification = new SizeSpecification(Size.Large);

            //ISpecification<Product> colorAndSizeSpecification = new AndSpecification<Product>(colorSpecification, sizeSpecification);
            ISpecification<Product> colorOrSizeSpecification = new OrSpecification<Product>(colorSpecification, sizeSpecification);
            BetterFilter betterFilter = new BetterFilter();
            foreach (Product product in betterFilter.Filter(products, colorOrSizeSpecification))
            {
                WriteLine($"ProductName: {product.Name}");
                WriteLine($"ProductColor: {product.Color}");
                WriteLine($"ProductSize: {product.Size}");
            }
        }
        public static void CallLiskovSubstitution()
        {
            Rectangle rectangle = new Rectangle(5, 4);
            WriteLine(rectangle);
            Rectangle square = new Square();
            square.Width = 4;
            WriteLine(square);
        }     
        
        public static void CallOpenClosedPrinciple2()
        {
            MainTask mainTask1 = new MainTask();
            Status status = mainTask1.PerformOperation();
            if(status == Status.Success)
            {
                var notifications = new List<INotification>()
                {
                    new Email(),
                    new Facebook()
                };
                NotificationManager.SendNotification(notifications, "Operation completed Successfully!");
            }
            else
            {
                var notifications = new List<INotification>()
                {
                    new Email(),
                    new SMS(),
                    new Push(),
                    new WhatsApp()
                };
                NotificationManager.SendNotification(notifications, "Exception Occurred!");
            }
                
            
        }
    }
}
