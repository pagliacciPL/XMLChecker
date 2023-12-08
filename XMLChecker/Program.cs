using System;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XMLChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string xmlpath = args[0];
                string xsdpath = args[1];
                XmlSchemaSet schemas = new XmlSchemaSet();
                schemas.Add("", xsdpath);
                XDocument xmlfile = XDocument.Load(xmlpath);
                bool error = false;
                xmlfile.Validate(schemas, (o, e) =>
                {
                    Console.WriteLine("{0}", e.Message);
                    error = true;
                });
                Console.WriteLine("{0}", error ? "XML is NOT correct against provided XSD" : "XML is correct against provided XSD");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}", e.Message);
            }

        }
    }
}
