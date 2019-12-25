using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace WPFMVVMExample.Model
{
    public class UserModel : INotifyPropertyChanged
    {
        

        /// <summary>
        /// Email
        /// </summary>
        private string userEmail;
        public string UserEmail
        {
            get
            {
                return userEmail;
            }
            set
            {
                userEmail = value;
                OnPropertyChanged("userEmail");
            }
        }
        private string userImage;
        public string UserImage
        {
            get
            {
                return userImage;
            }
            set
            {
                userImage = value;
                OnPropertyChanged("userImage");
            }
        }



        /* public event PropertyChangedEventHandler PropertyChanged;
         public void onPropertyChanged(string propertyName)
         {
             if (PropertyChanged != null)
             {
                 PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
             }
         }*/
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public void Load(string aFileName)
        {
            string[] aLines = File.ReadAllLines(aFileName);
            SourceTexts = aLines;
        }
        public string[] SourceTexts
        {
            get { return _SourceTexts; }
            set
            {
                if (_SourceTexts == value) return;
                _SourceTexts = value;

                OnPropertyChanged(nameof(SourceTexts));
            }
        }
        private string[] _SourceTexts;
        public List<string> Texts
        {
            get { return _Texts; }
            private set
            {
                if (_Texts == value) return;
                _Texts = value;
                OnPropertyChanged(nameof(Texts));
            }
        }
        private List<string> _Texts;
    }
}
