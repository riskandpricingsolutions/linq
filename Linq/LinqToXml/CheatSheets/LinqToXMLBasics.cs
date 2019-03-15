using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using static System.Console;

namespace LinqToXml.CheatSheets
{
    [TestFixture]
    public class LinqToXMLBasics
    {
        [Test]
        public void ParseElementFromString()
        {
            string xmlString =

                @"<Portfolio>
                    <!-- Some Options -->
                    <Option K='100' Exp='2019-01-01' />
                    <Strategy>
  	                    <Option K='110' Exp='2019-01-01' />
  	                    <Option K='100' Exp='2020-01-01' />
                    </Strategy>
                    <Strategy>
  	                    <Option K='210' Exp='2019-01-01' />
  	                    <Option K='200' Exp='2020-01-01' />
                    </Strategy>
                </Portfolio>";

            XElement el = XElement.Parse(xmlString);
        }

        [Test]
        public void BuildElementByComposingObjects()
        {
            XElement portfolioElement =
                new XElement("Portfolio",
                    new XElement("Option",
                        new XAttribute("K", "100"), new XAttribute("E", "2019-01-01")),
                    new XElement("Option",
                        new XAttribute("K", "100"), new XAttribute("E", "2019-01-01")));

            WriteLine(portfolioElement);
        }

        [Test]
        public void BuildElementByFunctionalComposition()
        {
            var expiries = new[] {"2019-01-01", "2020-01-01"};
            var strikes = new[] { 100, 100 };

            XElement portfolioElement =
                new XElement("Portfolio",
                    from exp in expiries
                    from k in strikes
                    select new XElement("Option", new XAttribute("K", k), new XAttribute("Exp", exp)));

            WriteLine(portfolioElement);
        }

        [Test]
        public void Navigation()
        {
            XElement el = XElement.Parse(
                @"<Portfolio>
                    <!-- Some Options -->
                    <Option K='100' Exp='2019-01-01' />
                    <Strategy>
  	                    <Option K='110' Exp='2019-01-01' />
  	                    <Option K='100' Exp='2020-01-01' />
                    </Strategy>
                    <Strategy>
  	                    <Option K='210' Exp='2019-01-01' />
  	                    <Option K='200' Exp='2020-01-01' />
                    </Strategy>
                    <Option K='1010' Exp='2019-01-01' />
                </Portfolio>");

            // Get a XContainer's first child XNode (<Option K="1010" Exp="2019-01-01" />)
            XNode firstNode = el.FirstNode;
            WriteLine(firstNode);

            // Get an XContainer's last child XNode (<Option K='1010' Exp='2019-01-01' />)
            XNode lastNode = el.LastNode;
            WriteLine(lastNode);

            // Get a sequence consisting of an XContainer's child XNodes
            //  XComment XElement XElement XElement XElement
            IEnumerable<XNode> nodes = el.Nodes();
            WriteLine(nodes);

            // Get a sequence consisting of an XContainer's child nodes whose
            //  type is XElement
            IEnumerable<XElement> elements = el.Elements();
            WriteLine(elements);

            // Alternative means of getting all an XContainer's child elements
            IEnumerable<XElement> elementsViaNodes = el.Nodes().OfType<XElement>();
            WriteLine(elementsViaNodes);

            // Linq Query Syntax SelectMany
            IEnumerable<XElement> strategyLegs = 
                from strategy in el.Elements("Strategy")
                from option in strategy.Elements("Option")
                select option;
            WriteLine(strategyLegs);

            // Return a sequence containing all of an XContainer's
            // child nodes whose type is XElement and whose tag is
            // Strategy
            IEnumerable<XElement> xElements = el.Elements("Strategy");
            WriteLine(xElements);

            // Return first element of specified tag
            XElement firstStrategyElement = el.Element("Strategy");
            WriteLine(firstStrategyElement);

            // Alternative means of getting the first element
            // Alternative Element
            XElement firstStrategyElementAlt = el.Elements("Strategy").FirstOrDefault();
            WriteLine(firstStrategyElementAlt);

            // Dealing with missing elements
            // Null Elements
            string value = el.Element("Missing")?.Value;
            WriteLine(value);

            // Get all descendents of type XElement. Not just
            //  the immediate children
            IEnumerable<XElement> descendantElements = el.Descendants("Option");
            WriteLine(descendantElements);

            // Get an XObject's parent XElement
            XElement childElement = el.Element("Strategy");
            XElement parentElement = childElement?.Parent;
            WriteLine(parentElement);

            // Get an XNode's ancestors
            childElement = el.Element("Strategy")?.Element("Option");
            IEnumerable<XElement> ancestors = childElement?.Ancestors();
            WriteLine(ancestors);

            // Get an XNode's ancestors and include the XNode itself
            IEnumerable<XElement> ancestorsAndSef = childElement?.AncestorsAndSelf();
            WriteLine(ancestorsAndSef);

            // Check if one element is before or after another
            XElement elementA = el.Elements("Strategy").Last().Element("Option");
            XElement elementB = el.Elements("Strategy").First().Element("Option");
            bool isBefore = elementA.IsBefore(elementB);
            bool isAfter = elementA.IsAfter(elementB);
            WriteLine(isBefore);
            WriteLine(isAfter);

            // Get the next sibling node
            XNode nextNode = firstNode.NextNode;
            WriteLine(nextNode);

            // Get the previous sibling node
            XNode previousNode = lastNode.PreviousNode;
            WriteLine(previousNode);

            // Get all sibling nodes after self
            IEnumerable<XNode> nextNodes = firstNode.NodesAfterSelf();
            WriteLine(nextNodes);

            // Get all sibling nodes before self
            IEnumerable<XNode> prevNodes = lastNode.NodesBeforeSelf();
            WriteLine(prevNodes);

            // Get all sibling XElements after self
            IEnumerable<XElement> nextElements = firstNode.ElementsAfterSelf();
            WriteLine(nextElements);

            // Get all sibling XElements before self
            IEnumerable<XElement> prevElements = lastNode.ElementsBeforeSelf();
            WriteLine(prevElements);


            // Get all sibling XElements after self with particular name
            IEnumerable<XElement> nextElementsbyName = firstNode.ElementsAfterSelf("Strategy");
            WriteLine(nextElementsbyName);

            // Get all sibling XElements before self with particular name
            IEnumerable<XElement> prevElementsByName = lastNode.ElementsBeforeSelf("Option");
            WriteLine(prevElementsByName);

            // Return true if an element has XAttributes
            bool elHasAttributes = el.HasAttributes;

            // Select an XElement's attribute by name
            XAttribute xAttribute = el.Element("Option").Attribute("K");

            // Get an XElement's last attribute
            XAttribute lastAttribute = el.Element("Option").LastAttribute;

            // Get all an XElement's attributes
            IEnumerable<XAttribute> xAttributes = el.Element("Option").Attributes();
        }
    }
}