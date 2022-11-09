using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;


namespace ExamPrepExercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList names = new ArrayList();
            ArrayList descriptions = new ArrayList();
            ArrayList prices = new ArrayList();

            Console.WriteLine("Welcome to \"The Mafias Grill House\"");
            string choice = "";
            while(choice != "e")
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("<a> Print out the whole menu");
                Console.WriteLine("<b> Order one of everything on the menu");
                Console.WriteLine("<e> Exit");
                Console.Write("Input:");
                choice = Console.ReadLine();
                Console.WriteLine();

                if (choice == "a")
                {
                    XmlTextReader reader = new XmlTextReader(@"..\\..\menu.xml");
                    reader.WhitespaceHandling = WhitespaceHandling.None;

                    XmlDocument doc = new XmlDocument();
                    doc.Load(reader);

                    XmlNodeList nodeListName = doc.DocumentElement.SelectNodes("//TheMafiasGrillhouse/Food/Name");
                    XmlNodeList nodeListDesc = doc.DocumentElement.SelectNodes("//TheMafiasGrillhouse/Food/Desc");
                    XmlNodeList nodeListPrice = doc.DocumentElement.SelectNodes("//TheMafiasGrillhouse/Food/Price");

                    foreach ( XmlNode node in nodeListName)
                    {
                        names.Add(node.FirstChild.Value.ToString());
                    }
                    foreach (XmlNode node in nodeListDesc)
                    {
                        descriptions.Add(node.FirstChild.Value.ToString());
                    }
                    foreach (XmlNode node in nodeListPrice)
                    {
                        prices.Add(node.FirstChild.Value.ToString());
                    }

                    reader.Close();


                    for (int i = 0; i < 5; i++)
                    {
                        string entry = (string)names[i] + "\n" + (string)descriptions[i] + "\n"+ (string)prices[i];
                        Console.WriteLine(entry);
                    } 




                }
                else if (choice == "b")
                {
                    ArrayList morePrices = new ArrayList();
                    XPathDocument xpDoc = new XPathDocument(@"..\..\menu.xml");
                    XPathNavigator xpNav = xpDoc.CreateNavigator();
                    XPathNodeIterator xpNodeIt = xpNav.Select("//TheMafiasGrillhouse/Food/Price");

                    while (xpNodeIt.MoveNext())
                    {
                        morePrices.Add(xpNodeIt.Current.Value);
                    }

                    decimal value = 0;
                    foreach (var item in morePrices)
                    {
                        value = value + Decimal.Parse((string)item);
                        
                    }
                    Console.WriteLine("The total price for each item is R{0}", value);
                }
                else if (choice == "e")
                {
                    Console.WriteLine("Press any key to close the program.");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Please attempt to enter one of the options.");
                    
                }

            }
            



        }
    }
}
