using System;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Consumidor;

namespace Consuimidor
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new Controlador();
        }

    }
}