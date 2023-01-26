using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Operations are created as different interfaces.So, the old printer can include only the Printing
  feature and new printer can include the Printing,Scanning,Faxing features.
  
  If we have all these features in one interface then both old/new printers are forced to implement
  all the features of that interface.
 */
namespace SOLIDPrinciples_Examples
{
    public class Document
    { }
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public interface IScan
    {
        void Scan(Document d);
    }

    public class OldPrinter:IPrinter
    {
        public void Print(Document d)
        {
            Console.WriteLine("Printed the Document using Old Printer");
        }
    }

    public class NewPrinter:IPrinter,IScan,IFax
    {
        public void Print(Document d)
        {
            Console.WriteLine("Printed the Document using New Printer");
        }

        public void Scan(Document d)
        {
            Console.WriteLine("Scanned the Document using New Printer");
        }

        public void Fax(Document d)
        {
            Console.WriteLine("Faxed the Document using New Printer");
        }
    }    
}
