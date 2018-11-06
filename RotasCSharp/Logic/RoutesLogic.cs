using RotasCSharp.Model;
using System.Collections.Generic;

namespace RotasCSharp.Logic
{
    class RoutesLogic
    {
        private Dictionary<string, Estacao> estacoes;

        public RoutesLogic(Dictionary<string, Estacao> estacoes)
        {
            this.estacoes = estacoes;
        }

        public string distanciaRota(string[] caminho)
        {
            if (caminho.Length <= 1)
            {
                return "0";
            }

            int distancia = 0;
            for (int i = 0; i < caminho.Length - 1; i++)
            {
                if (!estacoes[caminho[i]].destinos.ContainsKey(caminho[i + 1]))
                {
                    return "Rota não existe";
                }
                distancia += estacoes[caminho[i]].destinos[caminho[i + 1]].distancia;
            }
            return distancia.ToString();
        }
    }
}
