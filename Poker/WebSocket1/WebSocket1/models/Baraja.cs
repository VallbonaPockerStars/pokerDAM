
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WebSocket1.Models
{
    using System;

    public class Baraja
    {
        private Carta[] _baraja;
        private string[] _cartas = new string[]
        {
        "\U0001F0A1", "\U0001F0A2", "\U0001F0A3", "\U0001F0A4", "\U0001F0A5", "\U0001F0A6", "\U0001F0A7", "\U0001F0A8", "\U0001F0A9", "\U0001F0AA", "\U0001F0AB", "\U0001F0AD", "\U0001F0AE", // Corazones (Hearts)
        "\U0001F0B1", "\U0001F0B2", "\U0001F0B3", "\U0001F0B4", "\U0001F0B5", "\U0001F0B6", "\U0001F0B7", "\U0001F0B8", "\U0001F0B9", "\U0001F0BA", "\U0001F0BB", "\U0001F0BD", "\U0001F0BE", // Diamantes (Diamonds)
        "\U0001F0C1", "\U0001F0C2", "\U0001F0C3", "\U0001F0C4", "\U0001F0C5", "\U0001F0C6", "\U0001F0C7", "\U0001F0C8", "\U0001F0C9", "\U0001F0CA", "\U0001F0CB", "\U0001F0CD", "\U0001F0CE", // Tréboles (Clubs)
        "\U0001F0D1", "\U0001F0D2", "\U0001F0D3", "\U0001F0D4", "\U0001F0D5", "\U0001F0D6", "\U0001F0D7", "\U0001F0D8", "\U0001F0D9", "\U0001F0DA", "\U0001F0DB", "\U0001F0DD", "\U0001F0DE"  // Picas (Spades)
        };

        private int[] _valores = new int[]
        {
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, // Corazones (Hearts)
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, // Diamantes (Diamonds)
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, // Tréboles (Clubs)
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13  // Picas (Spades)
        };

        private string[] _palo = new string[] { "corazones", "diamantes", "treboles", "picas" };

        public Baraja()
        {
            _baraja = new Carta[52];
            InicializarBaraja();
        }

        private void InicializarBaraja()
        {
            for (int i = 0; i < _baraja.Length; i++)
            {
                _baraja[i] = new Carta(i.ToString(), _palo[i / 13], _valores[i], _cartas[i]);
            }
        }

        public Carta QuitarCarta(int index)
        {
            if (index >= 0 && index < _baraja.Length && _baraja[index] != null)
            {
                Carta carta = new Carta(_baraja[index].id, _baraja[index].palo, _baraja[index].valor, _baraja[index].carta);
                if (carta.carta.Equals("\U0001F0A0"))
                {
                return null;

                }
                _baraja[index].carta = "\U0001F0A0";
                return carta;
            }
            else
            {
                Console.WriteLine("Índice inválido o carta ya retirada.");
                return null;
            }
        }

        public int LongitudBaraja()
        {
            int longitud = 0;
            for (int i = 0; i < _baraja.Length; i++)
            {
                if (_baraja[i] != null)
                {
                    longitud++;
                }
            }
            return longitud;
        }     
    }
}