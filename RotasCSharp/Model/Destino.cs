namespace RotasCSharp.Model
{
    class Destino
    {
        public Estacao destino { get; set; }
        public int distancia { get; set; }

        public Destino()
        {
        }

        public Destino(Estacao est, int dist)
        {
            this.destino = est;
            this.distancia = dist;
        }
    }
}
