using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flunt.Notifications;
using Flunt.Validations;

namespace Projeto2List.Api.Models
{
    public class NotaTarefa 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Item> Itens { get; set; }

        public NotaTarefa(){
            Itens = new List<Item>();
        }
    }
}
