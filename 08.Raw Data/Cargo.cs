using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Raw_Data
{
    class Cargo
    {
        public string Type { get; set; }
        public int Weight { get; set; }

        public Cargo(string type, int weight)
        {
            Type = type;
            Weight = weight;
        }
    }
}
