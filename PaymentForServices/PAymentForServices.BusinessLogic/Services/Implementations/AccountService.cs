using System;
using PaymentForServices.Models.Data;
using PaymentForServices.Models.Models;

namespace PAymentForServices.BusinessLogic.Services
{
    public class AccountService: IAccountService
    {
        private ApplicationContext _context;

        public AccountService(ApplicationContext context)
        {
            _context = context;
        }

        public void Sync()
        {
            User user1 = new User
            {
                Name = "kirill",
                LastName = "Bovbel",
                Phone = "+232",
                Emain = "SDFSD",
                Partonymic = "fgsl",
                Password = "dsfsd",
                CreaditCard = new CreaditCard
                {
                    CVV = 111,
                    Date = "01/23",
                    Number = 325453434
                }
            };
            _context.Users.Add(user1);
            _context.SaveChanges();
        }
    }
}

