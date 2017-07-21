using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSpellSorter.Spells
{
    class SpellList
    {
        public List<SpellInformation> spells { get; private set; }

        public SpellList()
        {
            spells = new List<SpellInformation>();
        }

        public bool AddSpell(SpellInformation spell)
        {
            if (spell != null && !spells.Contains(spell))
            {
                spells.Add(spell);
                return true;
            }
            else
            {
                return false;
            }
        }

        public SpellInformation GetSpellInformation(String name)
        {
            foreach (SpellInformation info in spells)
            {
                if (info.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return info;
                }
            }
            return null;
        }

        public void SortSpells()
        {
            spells = spells.OrderBy(SpellInformation => SpellInformation.Name).ToList();
        }
    }
}
