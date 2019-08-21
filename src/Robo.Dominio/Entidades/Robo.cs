using System;

namespace Robo.Dominio
{
    public class Robo
    {
        public Robo()
        {
            EixoX = 0;
            EixoY = 0;
            Direcao = Direcao.N;
            TerrenoX = 4;
            TerrenoY = 4;
        }

        public Direcao Direcao { get; private set; }
        public int EixoX { get; private set; }
        public int EixoY { get; private set; }
        public int TerrenoX { get; }
        public int TerrenoY { get; }

        public void AplicarComando(string comandos)
        {
            foreach (var comandoChar in comandos)
            {
                var comando = comandoChar.ToString();
                ValidaComando(comando);
                ProcessaComando(comando);
            }
        }

        public string ObterPosicao()
        {
            return $"({EixoX},{EixoY},{Direcao.ToString()})";
        }

        private static void ValidaComando(string comando)
        {
            if (string.IsNullOrWhiteSpace(comando))
                throw new NegocioException("Comando inválido");
            if (!comando.Equals("L", StringComparison.InvariantCultureIgnoreCase) && !comando.Equals("R", StringComparison.InvariantCultureIgnoreCase) && !comando.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                throw new NegocioException("Comando inválido");
        }

        private void Girar(string comando)
        {
            var direcaoAtual = (int)Direcao;
            int movimento;
            if (comando.Equals("R", StringComparison.InvariantCultureIgnoreCase))
            {
                movimento = direcaoAtual + 1;
                if (movimento > 4)
                    movimento = 1;
            }
            else
            {
                movimento = direcaoAtual - 1;
                if (movimento < 1)
                    movimento = 4;
            }
            Direcao = (Direcao)movimento;
        }

        private void Movimentar()
        {
            switch (Direcao)
            {
                case Direcao.N:
                    EixoY++;
                    break;

                case Direcao.L:
                    EixoX++;
                    break;

                case Direcao.S:
                    EixoY--;
                    break;

                case Direcao.W:
                    EixoX--;
                    break;
            }
            if (EixoX < 0 || EixoX > TerrenoX || EixoY < 0 || EixoY > TerrenoY)
                throw new NegocioException("Posição inválida");
        }

        private void ProcessaComando(string comando)
        {
            if (comando.Equals("M", StringComparison.InvariantCultureIgnoreCase))
                Movimentar();
            else
                Girar(comando);
        }
    }
}