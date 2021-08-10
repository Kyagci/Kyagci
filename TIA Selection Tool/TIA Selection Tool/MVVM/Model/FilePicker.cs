using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TIA_Selection_Tool.Core;

namespace TIA_Selection_Tool.MVVM.Model
{
    public class FilePicker
    {
        public static XDocument xmltree;

        public void PickFile() 
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                XDocument _xEL = XDocument.Load(ofd.FileName);
                Console.WriteLine(_xEL);
                xmltree = _xEL;
            }
        }
    }
}

