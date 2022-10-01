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
                .AsNoTracking()
                .ToList();

            var paymentsDto = _mapper.Map<List<HistoryPaymentDto>>(payments);

            return paymentsDto;
        }

        public bool Sync(HistoryPaymentDto paymentDto)
        {
            var payment = _mapper.Map<HistoryPayment>(paymentDto);

            _context.HistoryPayments.Add(payment);

            return _context.SaveChanges()>0 ? true:false;
        }
    }
}

