using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentForServices.Models.Data;
using PaymentForServices.Models.Models;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public class HistoryPaymentService: IHistoryPaymentService
    {
        private readonly IMapper _mapper;

        private readonly ApplicationContext _context;

        public HistoryPaymentService(IMapper mapper,ApplicationContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<HistoryPaymentDto> Get(int Id)
        {
            var payments = _context.HistoryPayments
                .Where(hp => hp.UserId == Id)
                .Include(hp => hp.User)
                .Include(hp => hp.Category)
                .AsNoTracking()
                .ToList();

            var paymentsDto = _mapper.Map<List<HistoryPaymentDto>>(payments);

            return paymentsDto;
        }

        public bool Sync(HistoryPaymentDto paymentDto)
        {
            var payment = _mapper.Map<HistoryPayment>(paymentDto);

            _context.HistoryPayments.Add(payment);

            return Save();
        }

        public bool Delete(int id)
        {
            var hirstoryPayment = _context.HistoryPayments.FirstOrDefault(hp => hp.Id == id)!;

            _context.HistoryPayments.Remove(hirstoryPayment);

            return Save();
        }

        private bool Save() {
            return _context.SaveChanges() > 0 ? true : false;
        }
    }
}

