// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks.Dataflow;
using SOLIDPrinciples_Examples;
using static System.Console;

WriteLine("Welcome to Solid Principles- Examples");
WriteLine("===========================================");
WriteLine("Single Responsibility Principle");
Journal journal = new Journal();
journal.AddEntry("Have a good day!");
journal.AddEntry("All the Best!");
WriteLine(journal);
Persistence persistence = new Persistence();
persistence.Save(journal, "C:\\Ayyappan\\Learnings\\SolidPrinciples\\SolidPrinciples\\SOLIDPrinciples-Examples\\Test.txt", true);
WriteLine("===========================================");

WriteLine("===========================================");
WriteLine("Open Closed Principle");
List<Product> products = new List<Product>();
products.Add(new Product() { Name = "LipStick", Color = Color.Red, Size = Size.Small });
products.Add(new Product() { Name = "Tree", Color = Color.Green, Size = Size.Medium });
products.Add(new Product() { Name = "Building", Color = Color.Blue, Size = Size.Large });
ISpecification<Product> colorSpecification = new ColorSpecification(Color.Green);   
ISpecification<Product> sizeSpecification = new SizeSpecification(Size.Large);

//ISpecification<Product> colorAndSizeSpecification = new AndSpecification<Product>(colorSpecification, sizeSpecification);
ISpecification<Product> colorOrSizeSpecification = new OrSpecification<Product>(colorSpecification, sizeSpecification);
BetterFilter betterFilter = new BetterFilter();
foreach(Product product in betterFilter.Filter(products, colorOrSizeSpecification))
{
    WriteLine($"ProductName: {product.Name}");
    WriteLine($"ProductColor: {product.Color}");
    WriteLine($"ProductSize: {product.Size}");
}


WriteLine("===========================================");