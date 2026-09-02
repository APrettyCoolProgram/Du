// ---------------------------------------------------------------------------------------------------------------------
// Name: DoXML.cs
// Version: 00.90.01.160731
// Author: Christopher Banwarth (development@aprettycoolprogram.com)
// Description: A class for AO that does various things with XML.
// More: ao.aprettycoolprogram.com OR aprettycoolprogram.github.com
// ---------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Xml;

namespace AO
{
    public class DoXML
    {
        /// <summary>Parses an XML file.</summary>
        /// <param name="filePath"></param>
        /// <param name="assemblyName"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        /// <remarks>WORK IN PROGRESS!</remarks>
        /// <build>160718</build>
        public static List<Dictionary<string, string>> ContentAsDictionaryList(string filePath, string assemblyName, string element)
        {
            List<Dictionary<string, string>> wrkDictionary = new List<Dictionary<string, string>>();
            Dictionary<string, string> tmpDictionary;
            var fileLine = string.Empty;

            if (assemblyName == "")
            {
                XmlDocument xmlDoc = new XmlDocument();                             // xmlDoc is the new xml document.
                xmlDoc.Load(filePath);                                              // load the file. FIX
                XmlNodeList elementNodeList = xmlDoc.GetElementsByTagName(element); // array of the level nodes.

                foreach (XmlNode masterNode in elementNodeList)
                {
                    XmlNodeList dataNode = masterNode.ChildNodes;
                    tmpDictionary = new Dictionary<string, string>();               // Create a object(Dictionary) to colect the both nodes inside the level node and then put into levels[] array.

                    foreach (XmlNode subNode in dataNode) 
                    {
                        XmlNodeList dataSubNode = subNode.ChildNodes;

                        if (dataSubNode.Count >= 2)
                        {
                            foreach (XmlNode theThings in dataSubNode)
                            {
                                tmpDictionary.Add(subNode.Name + "_" + theThings.Name, theThings.InnerText);
                            }
                        }
                        else
                        {
                            tmpDictionary.Add(subNode.Name, subNode.InnerText); 
                        }
                    }
                    wrkDictionary.Add(tmpDictionary);
                }
            }
            else
            { // Embedded data
              //TODO Embedded code will go here
            }

            return wrkDictionary; 
        }
    }
}

// CHANGELOG
// =========
// 00.90.00.160717: Initial release
// 00.90.01.160731: Code and comment cleanup


// ROADMAP
// =======
// * Proper error handling

// NOTES
// =====