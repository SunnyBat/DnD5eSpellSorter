using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using DnDSpellSorter.Spells;

namespace DnDSpellSorter.ResourceParser
{
    class SpellLoader
    {
        public static SpellList LoadSpells()
        {
            return LoadSpellsViaJSON();
        }

        public static SpellList LoadSpellsViaJSON()
        {
            SpellList MySpells = new SpellList();
            FileInfo[] JsonFiles = GetAllJSONResources();
            foreach (FileInfo Info in JsonFiles)
            {
                Console.WriteLine("Processing " + Info.FullName);
                SpellList TempSpells = ParseJSONSpells(Info);
                foreach (SpellInformation Spell in TempSpells.spells)
                {
                    MySpells.AddSpell(Spell);
                }
            }
            return MySpells;
        }

        public static SpellList LoadSpellsViaXML()
        {
            SpellList MySpells = new SpellList();
            FileInfo[] XmlFiles = GetAllXMLResources();
            foreach (FileInfo Info in XmlFiles)
            {
                Console.WriteLine("Processing " + Info.FullName);
                SpellList TempSpells = ParseXMLSpells(Info);
                foreach (SpellInformation Spell in TempSpells.spells)
                {
                    MySpells.AddSpell(Spell);
                }
            }
            return MySpells;
        }

        private static FileInfo[] GetAllJSONResources()
        {
            return GetAllResources(".json");
        }

        private static FileInfo[] GetAllXMLResources()
        {
            return GetAllResources(".xml");
        }

        private static FileInfo[] GetAllResources(String extension)
        {
            DirectoryInfo Directory = new DirectoryInfo("SpellSorterResources");
            FileInfo[] ResourceFiles = new FileInfo[Directory.GetFiles().Length];
            int Index = 0;
            foreach (FileInfo Info in Directory.GetFiles())
            {
                if (Info.Name.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(Info.Name + " IS a " + extension + " file");
                    ResourceFiles[Index++] = Info;
                }
                else
                {
                    Console.WriteLine(Info.Name + " is not a " + extension + " file");
                }
            }
            if (Index != ResourceFiles.Length)
            {
                Console.WriteLine("Resources that are not " + extension + " files exist! Trimming...");
                FileInfo[] TempInfo = new FileInfo[Index];
                Array.Copy(ResourceFiles, TempInfo, Index);
                return TempInfo;
            }
            return ResourceFiles;
        }

        private static SpellList ParseJSONSpells(FileInfo jsonFile)
        {
            SpellList MySpells = new SpellList();
            String RawJSON = ReadFile(jsonFile);
            SpellListJSON.Data jsonObject = JsonConvert.DeserializeObject<SpellListJSON.Data>(RawJSON);
            foreach (SpellListJSON.Spell Spell in jsonObject.compendium.spell)
            {
                MySpells.AddSpell(SpellListConverter.ProcessSpell(Spell));
            }
            return MySpells;
        }

        private static String ReadFile(FileInfo file)
        {
            using (StreamReader streamReader = new StreamReader(file.FullName, Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        private static SpellList ParseXMLSpells(FileInfo xmlFile)
        {
            SpellList MySpells = new SpellList();
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(SpellListXML));
            SpellListXML.compendium XmlSpells = (SpellListXML.compendium)XmlSerializer.Deserialize(new StreamReader(xmlFile.FullName, Encoding.UTF8));
            foreach (SpellListXML.compendiumSpell spell in XmlSpells.spell) {
                MySpells.AddSpell(SpellListConverter.ProcessSpell(spell));
            }
            return MySpells;
        }
    }
}
