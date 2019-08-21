using System;

namespace Robo.Dominio
{
    public class NegocioException : Exception
    {
        public NegocioException(string mensagem) : base(mensagem)
        {
        }
    }
}