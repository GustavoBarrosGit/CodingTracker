using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class CodingRecord
    {
        internal int Id { get; set; }
        internal DateTime DateStart { get; set; }
        internal DateTime DateEnd { get; set; }
        internal TimeSpan Duration { get; set; }
    }
}
