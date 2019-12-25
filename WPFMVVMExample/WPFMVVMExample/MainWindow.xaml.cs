using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMVVMExample.Model;
using WPFMVVMExample.ViewModel;

namespace WPFMVVMExample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }

        private void TextBoxInput_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUserEmail.Text.Length != 0)
            {
                BtnDelete.IsEnabled = true;
            }
            else
            {
                BtnDelete.IsEnabled = false;
            }
        }
        private UserModel _Model;

        private void OnLoad_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog aDlg = new OpenFileDialog();
            if (aDlg.ShowDialog() != true) return;
            try
            {
                _Model.Load(aDlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnLoad_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
      


    }
}
