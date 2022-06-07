namespace Invoicing.Controllers.ViewModels
{
    public class InvoiceCreateViewModel
    {
        public DateTime DueDate { get; set; } //DataVencimento
        public double AmountCharge { get; set; } //Valor da cobrança
        public int ClientId { get; set; }
    }
}