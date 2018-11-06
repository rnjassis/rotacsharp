using RotasCSharp.Logic;
using RotasCSharp.Model;
using System;
using System.Collections.Generic;

namespace RotasCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            LoadFile loadFile = new LoadFile();
            RouterQuestions routerQuestions = new RouterQuestions();
            routerQuestions.routesLogic = new RoutesLogic(loadFile.LoadProperties());

            List<string> questions = loadFile.loadQuestions();
            foreach (string question in questions)
            {
                Console.WriteLine(routerQuestions.Router(question));
            }

            Console.Read();
        }
    }
}
