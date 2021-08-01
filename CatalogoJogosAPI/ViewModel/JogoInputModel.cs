using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CatalogoJogosAPI.ViewModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Nome do item deve conter entre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Nome da Produtora deve conter entre 3 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1, 3000, ErrorMessage = "Preço do item não pode ser R$ 0.00 e no maximo R$ 3.000,00")]
        public double Preco { get; set; }

    }
}
