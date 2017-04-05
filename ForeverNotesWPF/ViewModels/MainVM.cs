using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Xml;
using System.Xml.Linq;
using ForeverNotes.BO;
using ForeverNotes.Domain;
using ForeverNotes.Service;
using ForeverNotes;


namespace ForeverNotesWPF.ViewModels
{  
    public class MainVM
    {
        protected ILogger _log;

        private ObservableCollection<object> _children;
        public ObservableCollection<object> Children
        {
            get { return _children; }
            set { _children = value; }
            
        }

        private static ObservableCollection<string> _consoleField;
        public static ObservableCollection<string> ConsoleField
        {
            get { return _consoleField; }
            set { _consoleField = value; }
        }


        public MainVM()
        {
            if(_consoleField == null)
                _consoleField = new ObservableCollection<string>();
            _log = new Logger(_consoleField);
            _log.Add("Log started in " + this.ToString());
            Children = new ObservableCollection<object>();
        }
    }
}
