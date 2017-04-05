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
    public static class LogService
    {
        public static ObservableCollection<string> Logs = new ObservableCollection<string>();

        public static void AddLog(string log)
        {
            Logs.Insert(0, log);
            Console.WriteLine("Add: " + log);
        }

    }
}