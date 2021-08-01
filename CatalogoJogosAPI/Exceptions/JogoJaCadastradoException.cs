using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogosAPI.Exceptions
{
    public class JogoJaCadastradoException : Exception
    {
        public JogoJaCadastradoException() :base("Este cadastro já existe") { }
    }
}
