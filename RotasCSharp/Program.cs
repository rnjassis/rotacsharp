using RotasCSharp.Logic;
using RotasCSharp.Model;
using System;
using System.Collections.Generic;

namespace RotasCSharp
{
    /// <summary>
    /// Main do programa
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            CarregarArquivo loadFile = new CarregarArquivo();
            RouterQuestions routerQuestions = new RouterQuestions();
            routerQuestions.routesLogic = new RoutesLogic(loadFile.LoadProperties());

            List<string> questions = loadFile.loadQuestions();
            int count = 1;
            foreach (string question in questions)
            {
                Console.Write("#"+count+": ");
                routerQuestions.Router(question);
                count++;
            }

            Console.Read();
        }
    }
}
