using System;
namespace rekeningenJSON.classes
{
    public class trekeningen
    {
        public int nr { get; set; }
        public string naam { get; set; }
        public string type { get; set; }
        public string rekeningnummer { get; set; }
        public DateTime datumstart { get; set; }
        public DateTime datumstop { get; set; }
        public string omschrijving { get; set; }
        public Boolean actief { get; set; }
        public Boolean selected { get; set; }
    }
}