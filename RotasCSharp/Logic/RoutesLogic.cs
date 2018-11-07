using RotasCSharp.Model;
using System;
using System.Collections.Generic;

namespace RotasCSharp.Logic
{
    class RoutesLogic
    {

        private Dictionary<string, Estacao> estacoes;
        private int maxIterations = 0;
        List<Estacao> possiveis = new List<Estacao>();

        public RoutesLogic(Dictionary<string, Estacao> estacoes)
        {
            this.estacoes = estacoes;
        }

        /// <summary>
        /// Calcula o custo de um caminho determinado
        /// </summary>
        /// <param name="caminho"> Estações que deve ser percorridas</param>
        /// <returns>
        /// O custo total ou "Rota não existe" se o caminho não é possível
        /// </returns>
        public string distanciaRota(string[] caminho)
        {
            if (caminho.Length <= 1)
            {
                return "0";
            }

            int distancia = 0;
            for (int i = 0; i < caminho.Length - 1; i++)
            {
                if (!estacoes[caminho[i]].estAdj.ContainsKey(estacoes[caminho[i + 1]]))
                {
                    return "Rota não existe";
                }
                distancia += estacoes[caminho[i]].estAdj[estacoes[caminho[i + 1]]];
            }
            return distancia.ToString();
        }

        /// <summary>
        /// Procura por rotas de uma estação a outra respeitando um limite de paradas possíveis
        /// </summary>
        /// <param name="caminho">array com a estação origem, estação destino e paradas máximas</param>
        /// <returns>
        /// Quantas rotas são possíveis
        /// </returns>
        public int procurarPorRotas(string[] caminho)
        {
            bool[] visitado = new bool[estacoes.Count];
            maxIterations = int.Parse(caminho[2]);
            possiveis = new List<Estacao>();
            FindPath(estacoes[caminho[0]], estacoes[caminho[1]], maxIterations);

            int count = 0;
            foreach (Estacao est in possiveis) {
                if (est.Equals(estacoes[caminho[1]]))
                {
                    count++;
                }
            }

            return count;
        }
        /// <summary>
        /// Função que realiza a busca iterativa dentro das estações adjacentes.
        /// </summary>
        /// <param name="inicial">Estação que inicia a procura</param>
        /// <param name="final">Estação a ser procurada</param>
        /// <param name="max">Máximo de iteraões que podem ser realidadas</param>
        /// <returns> true se foi encontrado <paramref name="final"/>, false caso contrário</returns>
        private bool FindPath(Estacao inicial, Estacao final, int max)
        {
            if (inicial.Equals(final) && max < maxIterations)
            {
                return true;
            }

            if (max > 0)
            {
                List<Estacao> nodes = new List<Estacao>();
                foreach (var dic in inicial.estAdj)
                {
                    nodes.Add(dic.Key);
                }


                foreach (var est in nodes)
                {
                    int max_1 = max - 1;
                    if (FindPath(est, final, max_1))
                    {
                        possiveis.Add(est);
                        return true;
                    }
                }
            }

            return false;
        } 
    }
}
