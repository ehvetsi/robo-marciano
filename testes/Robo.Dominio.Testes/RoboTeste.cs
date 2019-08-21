using Xunit;

namespace Robo.Dominio.Testes
{
    public class RoboTeste
    {
        [Fact]
        public void DeveDispararExcecaoComComandoInvalido()
        {
            string comando = "AAA";

            var robo = new Robo();
            var posicao = robo.ObterPosicao();
            Assert.Equal("(0,0,N)", posicao);

            Assert.Equal("Comando inválido", Assert.Throws<NegocioException>(() => robo.AplicarComando(comando)).Message);
        }

        [Fact]
        public void DeveDispararExcecaoForaDoTerreno()
        {
            string comando = "MMMMMMMMMMMMMMMMMMMMMMMM";

            var robo = new Robo();
            var posicao = robo.ObterPosicao();
            Assert.Equal("(0,0,N)", posicao);

            Assert.Equal("Posição inválida", Assert.Throws<NegocioException>(() => robo.AplicarComando(comando)).Message);
        }

        [Fact]
        public void DeveMovimentarPara02W()
        {
            string comando = "MML";

            var robo = new Robo();
            var posicao = robo.ObterPosicao();
            Assert.Equal("(0,0,N)", posicao);

            robo.AplicarComando(comando);

            posicao = robo.ObterPosicao();
            Assert.Equal("(0,2,W)", posicao);
        }

        [Fact]
        public void DeveMovimentarPara20S()
        {
            string comando = "MMRMMRMM";

            var robo = new Robo();
            var posicao = robo.ObterPosicao();
            Assert.Equal("(0,0,N)", posicao);

            robo.AplicarComando(comando);

            posicao = robo.ObterPosicao();
            Assert.Equal("(2,0,S)", posicao);
        }
    }
}