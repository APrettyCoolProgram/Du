/* A class for AO.cs that does various things with XML data.
 * v00.52.03.161012
 * http://aprettycoolprogram.com/ao
 */

/* This class is under construction.It "works", but it's not efficient or pretty (yet). */

using System.Collections.Generic;
using System.Xml;

namespace AO
{
    public class AOXML
    {
        /* Parses an XML file.
         * ---
         * filePath     -
         * assemblyName -
         * element      -                                                                                             */
        public static List<Dictionary<string, string>> AsDictList(string filePath, string assemblyName, string element)
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