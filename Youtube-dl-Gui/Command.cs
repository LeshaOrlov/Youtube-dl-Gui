using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Youtube_dl_Gui
{
    class Command
    {
        public string URL { get; set; }
        public string OPTIONS { get; set; }
        public string OutputDirectory { get; set; }
        public string OutputTemplate { get; set; }
        public string Format { get; set; }
        public string MergeOutputFormat { get; set; }
    }
}
