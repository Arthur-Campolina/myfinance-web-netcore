using System.ComponentModel.DataAnnotations;

namespace myfinance_web_netcore.Models {
    public class PlanoContaModel {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do Plano de Conta!")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o tipo do Plano de Conta!")]
        public required string Tipo { get; set; }
    }
}