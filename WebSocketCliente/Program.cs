using System;
using WebSocketSharp;

namespace WebSocketCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ws = new WebSocket("ws://localhost:8181"))
            {
                ws.OnOpen += (sender, e) =>
                {
                    Console.WriteLine("Conectado al servidor WebSocket.");
                    ws.Send("¡Hola desde el cliente C#!");
                };

                ws.OnMessage += (sender, e) =>
                {
                    Console.WriteLine("Mensaje del servidor: " + e.Data);
                };

                ws.OnClose += (sender, e) =>
                {
                    Console.WriteLine("Conexión cerrada.");
                };

                ws.Connect();

                // Permitir enviar mensajes manuales
                string input;
                Console.WriteLine("Escribe un mensaje para enviar al servidor. Escribe 'salir' para terminar.");

                while ((input = Console.ReadLine()) != "salir")
                {
                    ws.Send(input);
                }

                ws.Close();
            }
        }
    }
}