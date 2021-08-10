using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TIA_Selection_Tool.Core;
using TIA_Selection_Tool.MVVM.Model;

namespace TIA_Selection_Tool.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        internal RelayCommand ClickCommand { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        
        public MenuView()
        {
            InitializeComponent();
            
        }

        public void CreateAButton()
        {
            GroupData GD = new GroupData();
            var Typename = GD.returntypelist();
            foreach (var TN in Typename)
            {
                System.Windows.Controls.Button newBtn = new Button();
                newBtn.Content = TN.ToString();
                newBtn.Name = TN.ToString();
                MenuList.Children.Add(newBtn);
                OnPropertyChanged();
            }
            
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GroupData GD = new GroupData();
            var Typename = GD.returntypelist();
            foreach (var TN in Typename)
            {
                System.Windows.Controls.Button newBtn = new Button();
                newBtn.Content = TN.ToString();
                newBtn.Name = TN.ToString();
                newBtn.Margin = new Thickness(15,40,15,40);
                newBtn.Width = 91;
                newBtn.Background = Brushes.White;
                
                newBtn.Command = ClickCommand = new RelayCommand(o =>
                {
                    newBtn.Background = Brushes.Red;
                    Console.WriteLine(TN.ToString());
                    newBtn.Background = Brushes.White;
                }); 
                MenuList.Children.Add(newBtn);
                
            }
        }
    }
}