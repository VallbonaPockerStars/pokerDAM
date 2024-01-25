
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebSocket1.Models
{
    public class Carta
    {
        
        public string id { get; set; }
        public string palo { get; set; }
        public int valor { get; set; }
        public string carta { get; set; }

       public Carta(string id, string palo, int valor, string carta)
        {
            this.id = id;
            this.palo = palo;
            this.valor = valor;
            this.carta = carta;
        }
        

    }
}