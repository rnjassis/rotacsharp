using System.Collections.Generic;

namespace RotasCSharp.Model
{
    /// <summary>
    /// Classe da estação
    /// </summary>
    class Estacao
    {
        /// <summary>
        /// Nome da estação
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Destinos possíveis
        /// </summary>
        public Dictionary<Estacao, int> estAdj { get; set; }

        public Estacao()
        {

        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome">
        /// Nome da estação
        /// </param>
        public Estacao(string nome)
        {
            this.nome = nome;
            estAdj = new Dictionary<Estacao, int>();
        }

        /// <summary>
        /// Override do método Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns> true se this.nome==obj.nome ou false se caso contrário</returns>
        public override bool Equals(object obj)
        {
            Estacao est = (Estacao)obj;
            if (this.nome == est.nome)
                return true;
            return false;
        }
    }
}
