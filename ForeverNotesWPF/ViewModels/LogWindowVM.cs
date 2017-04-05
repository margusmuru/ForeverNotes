using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using ForeverNotes.BO;
using ForeverNotes.Domain;
using ForeverNotes.Service;
using ForeverNotes;

namespace ForeverNotesWPF.ViewModels
{
    public class LogWindowVM
    {
        private ObservableCollection<String> _logs;
        public ObservableCollection<String> Logs
        {
            get { return _logs; }
            set { _logs = value; }
        }

        public LogWindowVM()
        {
            _logs = new ObservableCollection<string>();
            _logs.Add("startup");
        }
    }
}
