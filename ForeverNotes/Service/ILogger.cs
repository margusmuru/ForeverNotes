using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForeverNotes.Service
{
    public interface ILogger
    {
        void Add(string msg);
    }
}
