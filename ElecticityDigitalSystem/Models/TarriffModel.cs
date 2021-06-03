using System;
using System.Collections.Generic;
using System.Text;

namespace ElectricityDigitalSystem.Models
{
    public class TarriffModel
    {
        public string Id { get; private set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }

    }
}
