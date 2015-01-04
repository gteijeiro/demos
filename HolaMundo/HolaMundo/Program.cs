using System;
using System.Threading.Tasks;
using System.Console;

namespace HolaMundo
{
    class HolaMundo
    {
        public HolaMundo()
        {
            this.Nombre = "Guillermo Teijeiro";
            this.Mensaje = string.Format("Primeras lineas de codigo, mi nombre: {0}.", this.Nombre);
        }

        string Nombre { get; }
        string Mensaje { get; }
        

        static void Main(string[] args)
        {
            var holaMundo = new HolaMundo();
            holaMundo.MostrarMensaje();
        }

        public async void MostrarMensaje()
        {        
            WriteLine(this.Mensaje);
            ReadLine();
            await Task.Yield();
        }
    }
}
