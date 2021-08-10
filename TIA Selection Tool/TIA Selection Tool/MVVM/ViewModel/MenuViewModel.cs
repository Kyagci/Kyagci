using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using TIA_Selection_Tool.MVVM.Model;
using TIA_Selection_Tool.MVVM.View;

namespace TIA_Selection_Tool.MVVM.ViewModel
{

    public class MenuViewModel 
    {
        public List<string> ListBC { get; set; }

        public MenuViewModel() 
        {
            CreateButton();
        }

        public void CreateButton()
        {
            GroupData GD = new GroupData();
            MenuView Menu = new MenuView();
            var Typename = GD.returntypelist();
            foreach (var TN in Typename)
            {
                System.Windows.Controls.Button newBtn = new Button();
                newBtn.Content = TN.ToString();
                newBtn.Name = TN.ToString();
                Menu.MenuList.Children.Add(newBtn);
            }
        }
    }
}
