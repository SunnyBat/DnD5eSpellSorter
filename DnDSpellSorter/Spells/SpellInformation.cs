using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellSorter
{
    class SpellInformation
    {
        public String Name { get; set; }
        public int Level { get; set; }
        public String School { get; set; }
        public String CastingTime { get; set; }
        public String Range { get; set; }
        public String Components { get; set; }
        public String Materials { get; set; }
        public String Duration { get; set; }
        public String Description { get; set; }
        public List<String> Classes { get; set; }
        public List<String> Subclasses { get; set; }
        public Boolean Concentration { get; set; }
        public Boolean Ritual { get; set; }
    }
}
