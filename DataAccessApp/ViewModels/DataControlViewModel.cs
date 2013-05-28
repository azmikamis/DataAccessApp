using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using DataAccessApp.Helpers;
using DataAccessApp.Models;

namespace DataAccessApp.ViewModels
{
    public class DataControlViewModel : DependencyObject
    {
        public string ProductID { get; set; }
        private RelayCommand loadCommand;
        public ICommand LoadCommand
        {
            get { return loadCommand ?? (loadCommand = new RelayCommand(param => Load())); }
        }

        private RelayCommand deleteCommand;
        public ICommand DeleteCommand
        {
            get { return deleteCommand ?? (deleteCommand = new RelayCommand(param => Delete())); }
        }

        private void Load()
        {
            EventSystem.Publish<Boolean>(true);
        }

        private void Delete()
        {
            EventSystem.Publish<String>(this.ProductID);
        }
    }
}
