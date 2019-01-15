using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto2List.Api.Models
{
    public class Item
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime DataCreate {get;set;}
        public int IdNotaTarefa { get; set; }
        public NotaTarefa NotaTarefa { get; set; }

    }
}
