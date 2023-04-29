using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NeanDros.Shared.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        [Display(Name = "Fecha/Hora")]
        public DateTime? Date { get; set; }

        public bool TicketStatus { get; set; }

        [Display(Name = "Entrada")]
        public string? Entrance { get; set; }   


    }
}
