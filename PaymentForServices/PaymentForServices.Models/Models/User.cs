using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentForServices.Models.Models
{
    public class User:Account
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Partonymic { get; set; } = null!;

        public int CreaditCardId { get; set; }
        public CreaditCard CreaditCard { get; set; }

        public List<HistoryPayment> HistoryPayments { get; set; }
    }
}

