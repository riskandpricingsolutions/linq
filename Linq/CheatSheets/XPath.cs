using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using NUnit.Framework;

namespace CheatSheets
{
    [TestFixture]
    public class XPathCheatSheat
    {
        [Test]
        public void TestXPathCheatSheat()
        {
            XDocument doc = XDocument.Parse(@"<Portfolio>
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
	        </Portfolio>");

            // Select the first child of the document which is the Portfolio node
            XElement rootEl = ((IEnumerable) 
                doc
                .XPathEvaluate("Portfolio"))
                .Cast<XElement>()
                .First();

            // Select the first child of the document by specifying an absolute path. In this
            // case the result is the same as the previous expression
            // Select the first child of the document which is the Portfolio node
            XElement rootEl2 = ((IEnumerable)
                    doc
                        .XPathEvaluate("/Portfolio"))
                .Cast<XElement>()
                .First();

            XElement nonRootEl = doc.Element("Portfolio").Element("Option");
            XElement rootEl3 = ((IEnumerable)
                    nonRootEl
                        .XPathEvaluate("/Portfolio"))
                .Cast<XElement>()
                .First();

            // Select all Strategy children of the portfolio node using a path
            // relative to the root element
            IEnumerable<XElement> optEls = ((IEnumerable)
                    doc
                    .XPathEvaluate("Portfolio/Strategy"))
                    .Cast<XElement>()
                    .ToList();

            // Select all Option nodes irrespective of their location
            IEnumerable<XElement> allOptEls = ((IEnumerable)
                    doc
                        .XPathEvaluate("//Option"))
                .Cast<XElement>()
                .ToList();
            string allOptElsStr = allOptEls.Aggregate("", (s, element) => s += element + "\n");

        }

    }

    public static class XPathExtenstion
    {
        public static String ExecuteXPath(this XDocument document, string xpath)
        {
            List<XElement> xPathEvaluate = ((IEnumerable)document.XPathEvaluate(xpath)).Cast<XElement>().ToList();

            return xPathEvaluate.Aggregate("", (s, element) => s += element.ToString() + "\n");
        }

        public static String ExecuteXPath(this XElement document, string xpath)
        {
            List<XElement> xPathEvaluate = ((IEnumerable)document.XPathEvaluate(xpath)).Cast<XElement>().ToList();

            return xPathEvaluate.Aggregate("", (s, element) => s += element.ToString() + "\n");
        }
    }
}