using System;

namespace RotasCSharp.Logic
{
    /// <summary>
    /// Classe que associa a pergunta ao método de resposta
    /// </summary>
    class RouterQuestions
    {
        public RoutesLogic routesLogic { get; set; }

        public void  Router(string question)
        {
            string typeOfQuestion = question.Split(":")[0];
            string content = question.Split(":")[1];
            switch (typeOfQuestion)
            {
                case "D":
                    Console.WriteLine(routesLogic.distanciaRota(content.Split("-")));
                    break;
                case "N":
                    Console.WriteLine(routesLogic.procurarPorRotas(content.Split("-")));
                    break;
                default:
                    break;
            }
        }

    }
}
