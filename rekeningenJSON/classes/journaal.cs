using System;
namespace rekeningenJSON.classes
{
    public class journaal
    {

			public int id { get; set; }
			public string jrnref { get; set; }
			public string jrmnd { get; set; }
			public int van { get; set; }
			public int naar { get; set; }
			public float bedrag { get; set; }
			public int typetransfer { get; set; }
			public string beschrijving { get; set; }
			public string opmerking { get; set; }

    }
}
