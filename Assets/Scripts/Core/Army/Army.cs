using System;
using System.Collections.Generic;
using System.IO;

namespace Core.Army
{
    public class Army
    {
        private List<UnitsStack> army;

        public Army(List<UnitsStack> army)
        {
            if (army.Count > 6)
            {
                Console.WriteLine("Max 6 UnitStack");
            }

            for (int i = 0; i < Math.Min(army.Count, 6); i++)
            {
                this.army.Add(army[i]);
            }
        }

        public Army(params UnitsStack[] army)
        {
            if (army.Length > 6)
            {
                Console.WriteLine("Max 6 UnitStack");
            }

            this.army = new List<UnitsStack>();
            for (int i = 0; i < Math.Min(army.Length, 6); i++)
            {
                this.army.Add(army[i]);
            }
        }

        //    public Army(Army army) {
        //        this(army.getArmy());
        //    }

        public UnitsStack[] getArmy()
        {
            return army.ToArray();
        }

        public override string ToString()
        {
            string res = "Army:\n";
            for (int i = 0; i < army.Count; i++)
            {
                res += "     " + army[i] + "\n";
            }

            return res;
        }

        public string ToFile()
        {
            string res = "" + army.Count + " ";
            for (int i = 0; i < army.Count; i++)
            {
                if (army[i] == null)
                    res += "" + 0 + " ";
                else
                    res += "" + army[i].Count + " " + army[i].Type.Type + " ";
            }

            return res;
        }
    }
}