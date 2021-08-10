using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TIA_Selection_Tool.Core;

namespace TIA_Selection_Tool.MVVM.Model
{
    class GroupData : FilePicker
    {
        public static List<string> TypeName = new List<string>();
        public static List<string> PropertyName = new List<string>();
        
        public void GroupTypename()
        {
            FilePicker FP = new FilePicker();
            XDocument xml = xmltree;
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
        public void GroupPropertyname()
        {
            FilePicker FP = new FilePicker();
            XDocument xml = xmltree;
            List<Dictionary<string, string>> orderList = new List<Dictionary<string, string>>();
            List<XNode> yNode = new List<XNode>();

            //Get Elements

            foreach (var node in xml.Root.Elements("property"))
            {
                string name = node.Element("Key").Value;
            }

        }

        public List<string> returnelementlist()
        {
            return PropertyName;
        }

        public List<string> returntypelist() 
        {
            return TypeName;
        }
    }
}
