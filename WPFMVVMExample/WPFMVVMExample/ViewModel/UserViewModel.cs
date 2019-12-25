using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPFMVVMExample.Commands;
using WPFMVVMExample.Model;

namespace WPFMVVMExample.ViewModel
{
    public class UserViewModel :ViewModelBase
    {
        private string _imagePath;

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                if (_imagePath != value)
                {
                    _imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

       

        private ICommand _openFileCommand;

        public ICommand OpenFileCommand
        {
            get { return _openFileCommand; }
        }

      




        public DelegateCommand ShowCommand { get; set; }
        public DelegateCommand BtnDeleteCommand { get; set; }
        public UserModel User { get; set; }


        public UserViewModel()
        {
            User = new UserModel();
            ShowCommand = new DelegateCommand();
            ShowCommand.ExecuteCommand = new Action<object>(ShowUserEmailText);
            ShowCommand.ExecuteCommand = new Action<object>(ShowUserImage);
            BtnDeleteCommand = new DelegateCommand();
            BtnDeleteCommand.ExecuteCommand = new Action<object>(BtnDelete);
            _openFileCommand = new OpenFileCommand(this);



        }
        private void ShowUserEmailText(object obj)
        {
            //TODO
            
        }
        private void ShowUserImage(object obj)
        {
            //TODO
        }
        private void BtnDelete(object obj)
        {
            //TODO
        }

    }

    public class DelegateCommand : ICommand
    {
        public Action<object> ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return this.CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteCommand != null)
            {
                this.ExecuteCommand(parameter);
            }
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
