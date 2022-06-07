using System;
namespace Invoicing.Models.Domain
{
	public class Invoice
	{
        public int Id { get; set; }
        public DateTime IssuanceDate { get; set; } //Data Emissão
        public DateTime DueDate { get; set; } //DataVencimento
        public double AmountCharge { get; set; } //Valor da cobrança
        public DateTime? PaymentDate { get; set; } //DataPagamento
        public bool Status { get; set; } //Status do pagamento
        public Client Client { get; set; }
        public int ClientId { get; set; }
    }
}

