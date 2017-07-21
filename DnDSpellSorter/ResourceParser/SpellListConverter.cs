using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace DnDSpellSorter.ResourceParser
{
    class SpellListConverter
    {
        public static SpellInformation ProcessSpell(SpellListJSON.Spell SpellJSON)
        {
            SpellInformation SpellInfo = new SpellInformation();
            SpellInfo.CastingTime = SpellJSON.time;
            // This is basically a 1:1 mapping, however it's required to normalize data
            SpellInfo.Classes = new List<string>();
            SpellInfo.Subclasses = new List<string>();
            foreach (String str in SpellJSON.classes.Split(new char[] { ',' }))
            {
                String beforeParen;
                String insideParen;
                ParseParentheses(str, out beforeParen, out insideParen);
                if (beforeParen != null && !SpellInfo.Classes.Contains(beforeParen)) // Can have Cleric, Cleric (sub1), Cleric (sub2)
                {
                    SpellInfo.Classes.Add(beforeParen);
                }
                if (insideParen != null) // Assumption: Subclasses are all unique
                {
                    SpellInfo.Subclasses.Add(insideParen);
                }
            }
            String Components;
            String Materials;
            ParseParentheses(SpellJSON.components, out Components, out Materials);
            SpellInfo.Components = Components;
            SpellInfo.Materials = Materials;
            SpellInfo.Concentration = SpellJSON.duration.StartsWith("Concentration");
            if (SpellJSON.text is JArray)
            {
                foreach (JValue obj in ((JArray)SpellJSON.text))
                {
                    if (SpellInfo.Description == null || SpellInfo.Description.Length == 0)
                    {
                        SpellInfo.Description = obj.ToString();
                    }
                    else
                    {
                        SpellInfo.Description += Environment.NewLine;
                        SpellInfo.Description += obj.ToString();
                    }
                }
            }
            else if (SpellJSON.text.GetType() == typeof(String))
            {
                SpellInfo.Description = (String)SpellJSON.text;
            }
            else
            {
                Console.WriteLine("Unknown object: " + SpellJSON.text.GetType());
            }
            SpellInfo.Duration = SpellJSON.duration; // Contains "Concentration"
            int TempLevel = -1;
            int.TryParse(SpellJSON.level, out TempLevel);
            SpellInfo.Level = TempLevel;
            // Materials - Processed with Components above
            SpellInfo.Name = SpellJSON.name;
            SpellInfo.Range = SpellJSON.range;
            if (SpellJSON.ritual != null)
            {
                SpellInfo.Ritual = SpellJSON.ritual.Equals("YES", StringComparison.OrdinalIgnoreCase);
            }
            SpellInfo.School = ConvertSchoolLetterToWord(SpellJSON.school);
            // Subclass - Processed with Classes above
            return SpellInfo;
        }

        public static SpellInformation ProcessSpell(SpellListXML.compendiumSpell SpellXML)
        {
            SpellInformation SpellInfo = new SpellInformation();
            SpellInfo.CastingTime = SpellXML.time;
            SpellInfo.Classes = new List<string>();
            foreach (String str in SpellXML.classes.Split(new char[] { ',' }))
            {
                SpellInfo.Classes.Add(str.Trim());
            }
            SpellInfo.Components = SpellXML.components;
            SpellInfo.Concentration = SpellXML.duration.StartsWith("Concentration");
            foreach (String str in SpellXML.text)
            {
                if (SpellInfo.Description == null || SpellInfo.Description.Length == 0)
                {
                    SpellInfo.Description = str;
                }
                else
                {
                    SpellInfo.Description += Environment.NewLine;
                    SpellInfo.Description += str;
                }
            }
            SpellInfo.Duration = SpellXML.duration; // Contains "Concentration"
            SpellInfo.Level = SpellXML.level;
            // materials - in components
            SpellInfo.Name = SpellXML.name;
            SpellInfo.Range = SpellXML.range;
            SpellInfo.Ritual = SpellXML.ritual.Equals("YES");
            SpellInfo.School = ConvertSchoolLetterToWord(SpellXML.school);
            // subclass - not present
            return SpellInfo;
        }

        private static String ConvertSchoolLetterToWord(String Letter)
        {
            switch (Letter)
            {
                case "A":
                    return "Abjuration";
                case "C":
                    return "Conjuration";
                case "D":
                    return "Divination";
                case "EN":
                    return "Enchantment";
                case "EV":
                    return "Evocation";
                case "I":
                    return "Illusion";
                case "N":
                    return "Necromancy";
                case "T":
                    return "Transformation";
            }
            return Letter;
        }

        private static void ParseParentheses(String input, out String beforeParen, out String insideParen)
        {
            if (input == null)
            {
                beforeParen = null;
                insideParen = null;
            }
            else if (input.Contains("("))
            {
                beforeParen = input.Substring(0, input.IndexOf("(")).Trim();
                insideParen = input.Substring(input.IndexOf("(") + 1);
                if (insideParen.Contains(")"))
                {
                    insideParen = insideParen.Substring(0, insideParen.IndexOf(")"));
                }
                insideParen = insideParen.Trim();
            }
            else
            {
                beforeParen = input.Trim();
                insideParen = null;
            }
        }
    }
}
