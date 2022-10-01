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

        public bool EmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool PhoneExist(string phone)
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

        public bool Get(LoginDto login)
        {
            return _context.Users
                .Any(u => (u.Email == login.UserLogin || u.Phone == login.UserLogin)
                && u.Password == login.Password);
        }

        public bool LoginExist(string login)
        {
            return _context.Users
                .Any(u => u.Email == login || u.Phone == login);
        }

        public int GetId(string login)
        {
            return _context.Users
                .FirstOrDefault(u => u.Email == login || u.Phone == login)!.Id;
        }

        public UserDto GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u=>u.Id == id);

            var userDro = _mapper.Map<UserDto>(user);

            return userDro;
        }
    }
}

