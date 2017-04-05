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

namespace ForeverNotes.Service
{
    public class Logger : ILogger
    {
        private ObservableCollection<string> _collection;

        public Logger(ObservableCollection<string> returnCollection)
        {
            Console.WriteLine(returnCollection.ToString());
            _collection = returnCollection;
        }

        public void Add(string msg)
        {
            string _msg = DateTime.Now + " | " + msg;
            LogService.AddLog(_msg);
            if (_collection != null)
                _collection.Insert(0, _msg);
        }
    }
}
