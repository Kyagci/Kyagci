using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using TIA_Selection_Tool.Core;

namespace TIA_Selection_Tool.MVVM.Model
{
    public class GroupData : FilePicker
    {
        public static List<string> TypeName = new List<string>();
        XDocument xml = xmltree;

        public void GroupTypename()
        {

            List<string> orderList = new List<string>();
            var xNodes = xml.Descendants("node").GroupBy(x => (string)x.Attribute("Type")).ToList();

            //For each orderProperty, get all attributes
            foreach (var attribute in xNodes)
            {
                orderList.Add(attribute.Key.ToString());

            }
            foreach (var list in orderList)
            {
                Console.WriteLine(list);
                TypeName.Add(list);
            }

        }

        public void ReadXmlFile()
        {
            XmlDataCollection XmlDatas = null;
            string path = "C:/Users/kyagci/Documents/Privat/Bewerbung/Projekt/WPF_Teil 1/Tia-Files/Test2.tia";

            XmlSerializer serializer = new XmlSerializer(typeof(XmlDataCollection));

            StreamReader reader = new StreamReader(path);
            XmlDatas = (XmlDataCollection)serializer.Deserialize(reader);
            reader.Close();
        }

        [Serializable()]
        public class XmlData
        {
            [System.Xml.Serialization.XmlElement("key")]
            public string key { get; set; }

            [System.Xml.Serialization.XmlElement("value")]
            public string value { get; set; }

            //[System.Xml.Serialization.XmlElement("Model")]
            //public string Model { get; set; }
        }


        [Serializable()]
        [System.Xml.Serialization.XmlRoot("XmlDataCollection")]
        public class XmlDataCollection
        {
            [XmlArray("XmlDatas")]
            [XmlArrayItem("XmlData", typeof(XmlData))]
            public XmlData[] XmlData { get; set; }

        }

        public List<string> returntypelist()
        {
            return TypeName;
        }
    }
}
