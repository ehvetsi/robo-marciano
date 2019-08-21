namespace Robo.Aplicacao.Comandos
{
    public class MovimentarRobo : IMovimentarRobo
    {
        public string AplicarComando(string comando)
        {
            var robo = new Dominio.Robo();
            robo.AplicarComando(comando);
            return robo.ObterPosicao();
        }
    }
}