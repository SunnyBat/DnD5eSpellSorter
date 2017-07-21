using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DnDSpellSorter.Spells;
using System.Reflection;

namespace DnDSpellSorter
{
    public partial class MainGUI : Form
    {
        private String[] FullClassList; // Array with all the classes, not necessarily visible if filtered
        private String[] FullLevelList; // Array with all the spell levels, not necessarily visible if filtered
        private SpellList AllSpells;
        private SpellList CurrentSpells;
        private String CurrentSpellSelection;

        public MainGUI()
        {
            InitializeComponent();
            FullClassList = GetValues(LBClass);
            FullLevelList = GetValues(LBClass);
            this.CurrentSpells = new SpellList();
        }

        private String[] GetValues(ListBox lb)
        {
            String[] Ret = new String[lb.Items.Count];
            int index = 0;
            foreach (String str in lb.Items)
            {
                Ret[index++] = str;
            }
            return Ret;
        }

        internal void InitializeSpells(Spells.SpellList spells)
        {
            this.AllSpells = spells;
            LBClass.SelectedIndex = 0;
            LBLevel.SelectedIndex = 0; // This auto-refreshes spell list due to how controls in WF work
        }

        private void RefreshSpellList()
        {
            if (LBClass.SelectedIndex == -1 || LBLevel.SelectedIndex == -1)
            {
                return;
            }
            CurrentSpellSelection = (String) LBSpell.SelectedItem;
            CurrentSpells.spells.Clear();
            String ClassName = (String)LBClass.SelectedItem;
            String SpellLevel = (String)LBLevel.SelectedItem;
            foreach (SpellInformation info in AllSpells.spells)
            {
                if (!ClassName.Equals("All"))
                {
                    if (info.Classes != null && !info.Classes.Contains(ClassName))
                    {
                        continue;
                    }
                }
                if (LBLevel.SelectedIndex != 0)
                {
                    if (info.Level != LBLevel.SelectedIndex - 1) // Assumption: List is ordered as All then 0-9
                    {
                        continue;
                    }
                }
                CurrentSpells.AddSpell(info);
            }
            LBSpell.SelectedItem = CurrentSpellSelection;
            FilterSpellList();
        }

        private void ReselectCurrentSpell()
        {
            foreach (String spellName in LBSpell.Items)
            {
                if (spellName.Equals(CurrentSpellSelection))
                {
                }
            }
        }

        private void FilterSpellList()
        {
            CurrentSpellSelection = (String)LBSpell.SelectedItem;
            LBSpell.Items.Clear();
            if (TBSpell.Text.Length >= 0)
            {
                foreach (SpellInformation info in CurrentSpells.spells)
                {
                    if (TBSpell.Text != null && TBSpell.Text.Length > 0)
                    {
                        if (!info.Name.ToLower().Contains(TBSpell.Text.ToLower()))
                        {
                            continue;
                        }
                    }
                    LBSpell.Items.Add(info.Name);
                }
            }
            else
            {
                foreach (SpellInformation info in CurrentSpells.spells)
                {
                    LBSpell.Items.Add(info.Name);
                }
            }
            LBSpell.SelectedItem = CurrentSpellSelection;
            RefreshSpellInfo();
        }

        private void RefreshSpellInfo()
        {
            RTBSpellInfo.Text = String.Empty;
            String SpellName = (String)LBSpell.SelectedItem;
            if (SpellName == null)
            {
                return;
            }
            SpellInformation info = CurrentSpells.GetSpellInformation(SpellName);
            foreach (PropertyInfo prop in typeof(SpellInformation).GetProperties())
            {
                object MyObject = prop.GetValue(info, null);
                String ObjectString = ConvertObjectToString(MyObject);
                if (ObjectString != null)
                {
                    if (RTBSpellInfo.Text.Length > 0)
                    {
                        RTBSpellInfo.Text += Environment.NewLine;
                    }
                    RTBSpellInfo.Text += prop.Name + " = ";
                    RTBSpellInfo.Text += ObjectString;
                }
            }
        }

        private String ConvertObjectToString(object MyObject)
        {
            if (MyObject == null)
            {
                return null;
            }
            StringBuilder RetString = new StringBuilder();
            if (MyObject.GetType().IsArray)
            {
                object[] array = (object[])MyObject;
                if (array.Length > 0)
                {
                    RetString.Append(array[0]);
                    for (int i = 1; i < array.Length; i++)
                    {
                        RetString.Append(", ").Append(array[i]);
                    }
                }
                else
                {
                    return null;
                }
            }
            else if (MyObject.GetType() == typeof(List<String>))
            {
                List<String> MyList = (List<String>)MyObject;
                if (MyList.Count > 0)
                {
                    RetString.Append(MyList.ElementAt(0));
                    for (int i = 1; i < MyList.Count; i++)
                    {
                        RetString.Append(", ").Append(MyList.ElementAt(i));
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                RetString.Append(MyObject.ToString());// Assumption: ToString() produces meaningful result - normally, the Object is a primitive
            }
            return RetString.ToString();
        }

        private void TBClass_TextChanged(object sender, EventArgs e)
        {
        }

        private void TBLevel_TextChanged(object sender, EventArgs e)
        {
        }

        private void TBSpell_TextChanged(object sender, EventArgs e)
        {
            FilterSpellList();
        }

        private void LBClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSpellList();
        }

        private void LBLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSpellList();
        }

        private void LBSpells_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSpellInfo();
        }
    }
}
