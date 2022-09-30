using System;
using AutoMapper;
using PaymentForServices.Models.Data;
using PaymentForServices.Models.Models;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public class AccountService: IAccountService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public AccountService(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool GetEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool GetPhone(string phone)
        {
            return _context.Users.Any(u => u.Phone == phone);
        }

        //public void Sync()
        //{
        //    User user1 = new User
        //    {
        //        Name = "kirill",
        //        LastName = "Bovbel",
        //        Phone = "+375336600928",
        //        Email = "gorboveckirill@gmail.com",
        //        Partonymic = "Alex",
        //        Password = "1234567",
        //        CreaditCard = new CreaditCard
        //        {
        //            CVV = 111,
        //            Date = "01/23",
        //            Number = 325453434
        //        }
        //    };
        //    _context.Users.Add(user1);
        //    _context.SaveChanges();
        //}

        public bool Sync(RegistrationDto registrationDto)
        {
            var user = _mapper.Map<User>(registrationDto);
            _context.Users.Add(user);
            return Save();

        }

        private bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}

