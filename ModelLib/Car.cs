using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib
{
    public class Car
    {
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNr { get; set; }

        public override string ToString()
        {
            return $"Model: {Model} - Color: {Color} - RegNr: {RegNr}";
        }
    }
}
