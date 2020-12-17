using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace bulochka.Entities

{
    public class Bulochka
    {
        public long Id { get; set; }
        public BulochkaTypes Type { get; set; }
        public DateTime CreationTimestamp { get; set; }
        public DateTime LastupdateTimestamp {get; set;}
        public DateTime DropTimestamp { get; set; }
        public DateTime ControlSellTime { get; set; }
        [Range(0,100)]
        public float StartPrice { get; set; }
        public float CurrentPrice { get; set; }
    }
}
