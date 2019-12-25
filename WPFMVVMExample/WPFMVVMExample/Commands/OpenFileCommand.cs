using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFMVVMExample.ViewModel;

namespace WPFMVVMExample.Commands
{
    public class OpenFileCommand : ICommand
    {
        private UserViewModel _data;
        public OpenFileCommand(UserViewModel data)
        {
            _data = data;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OpenFileDialog dialog = new OpenFileDialog() { Filter = "Image Files|*.jpg;*.png;*.bmp;*.gif" };

            if (dialog.ShowDialog().GetValueOrDefault())
            {
                _data.ImagePath = dialog.FileName;
            }
        }
    }
}
