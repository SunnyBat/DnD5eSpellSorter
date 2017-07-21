using System;
using System.Windows.Forms;

namespace DnDSpellSorter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainGUI MyForm = new MainGUI();
            Spells.SpellList SpellList = ResourceParser.SpellLoader.LoadSpells();
            SpellList.SortSpells();
            MyForm.InitializeSpells(SpellList);
            Application.Run(MyForm);
        }
    }
}
