namespace RotasCSharp.Logic
{
    class RouterQuestions
    {
        public RoutesLogic routesLogic { get; set; }

        public string  Router(string question)
        {
            string typeOfQuestion = question.Split(":")[0];
            string content = question.Split(":")[1];
            switch (typeOfQuestion)
            {
                case "D":
                    return routesLogic.distanciaRota(content.Split("-"));
                case "N":
                    //return routesLogic.numeroViagens(content.Split("-"));
                default:
                    return "";
            }
        }

    }
}
