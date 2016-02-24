using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.ServiceBus.Messaging;

namespace ClienteColaLab07
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = ConfigurationManager.AppSettings["conexioncola"];
            var cl = QueueClient.CreateFromConnectionString (conn, "incidencias");
            while (true)
            {
                var msg = cl.Receive();
                if (msg!=null)
                {
                    Console.WriteLine("Mensaje");
                    Console.WriteLine("Incidencia  {0} fecha {1}", msg.Properties["incidencia"], msg.Properties["fecha"]);
                    msg.Complete();

                }
            }

        }
    }
}
