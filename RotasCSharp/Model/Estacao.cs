using System.Collections.Generic;

namespace RotasCSharp.Model
{
    class Estacao
    {
        public string nome { get; set; }
        public Dictionary<string, Destino> destinos { get; set; }

        public Estacao()
        {
            
        }

        public Estacao(string nome)
        {
            this.nome = nome;
            destinos = new Dictionary<string, Destino>();
        }
    }
}
