using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DLLGramtoOunces;

namespace TCPServer
{
    class ClientAction
    {
        public static void DoIt(TcpClient client)
        {
            Class1 conventer = new Class1();
            NetworkStream stream = client.GetStream();

            StreamReader reader = new StreamReader(stream);

            StreamWriter writer = new StreamWriter(stream) {AutoFlush = true};

           
            while (true)
            {
                  

               string request = reader.ReadLine();
                string[] words = request.Split(' ');

                switch (words[0])
                {
                    case "togram":

                        double number = double.Parse(words[1]);
                        number = conventer.ConvertToGrams(number);
                        writer.WriteLine(number);
                        writer.Flush();
                        break;

                    case "toounces":
                       
                        var number1 = double.Parse(words[1]);
                        number1 = conventer.ConvertToOunces(number1);
                        writer.WriteLine(number1);
                        writer.Flush();
                        break;

                }




            }
        }

    }
}
