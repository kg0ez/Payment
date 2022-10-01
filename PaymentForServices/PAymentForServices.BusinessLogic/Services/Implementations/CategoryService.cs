using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentForServices.Models.Data;
using PaymentForServices.Models.Models;
using PAymentForServices.Common.ModelsDto;

namespace PAymentForServices.BusinessLogic.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ApplicationContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<ServiceDto> GetServices()
        {
            var services = _context.Services
                .AsNoTracking()
                .ToList();

            var servicesDto = _mapper.Map<List<ServiceDto>>(services);

            return servicesDto;
        }

        public List<CategoryDto> GetCategories(int id)
        {
            var categories = _context.Categories
                .Where(c => c.ServiceId == id)
                .AsNoTracking()
                .ToList();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesDto;
        }

        public int GetCategoryId(string name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == name)!.Id;
        }




        public void Sync()
        {
            var categories = new List<Service>
            {
                new Service{
                    Name = "Транспортные билеты",
                    Categories = new List<Category>{
                        new Category { Name = "321.by"},
                        new Category { Name = "Avtoturizm.by"},
                        new Category { Name = "Eurotrans.by"},
                        new Category { Name = "Pass.rw.by - Ж/д билеты"},
                        new Category { Name = "Pereletnaya.by - билеты"},
                        new Category { Name = "Taf.by - автобусные билеты"},
                        new Category { Name = "Билеты Белавиа, ЖД"},
                        new Category { Name = "Авиабилеты"},
                        new Category { Name = "Автобусные билеты"},
                        new Category { Name = "Фаворит-Экспресс"},
                        new Category { Name = "Экспрессбас-Тикет"},
                        new Category { Name = "Starbus.by"},
                    }
                },
                new Service{
                    Name = "ИТ услуги",
                    Categories = new List<Category>{
                        new Category { Name = "Регистрация ПК"},
                        new Category { Name = "Абонентская плата"},
                        new Category { Name = "Услуги хостинга"},
                        new Category { Name = "Разработка ПО"},
                    }
                },
                new Service{
                    Name = "Коммунальные платежи",
                    Categories = new List<Category>{
                        new Category { Name = "Водоснабжение"},
                        new Category { Name = "Вывоз мусора"},
                        new Category { Name = "Газоснабжение"},
                        new Category { Name = "Домофоны"},
                        new Category { Name = "Общежития"},
                        new Category { Name = "Садоводческие товарищества"},
                        new Category { Name = "Электроснабжение"},
                        new Category { Name = "Теплоснажение"},
                    }
                },
                new Service{
                    Name = "Мобильная связь",
                    Categories = new List<Category>{
                        new Category { Name = "МТС - Домашний интернет"},
                        new Category { Name = "МТС по № телефона"},
                        new Category { Name = "life:) по № телефона"},
                        new Category { Name = "life:) в счёт штрафа"},
                        new Category { Name = "А1 по № телефона"},
                    }
                },
                new Service{
                    Name = "Налоги",
                    Categories = new List<Category>{
                        new Category { Name = "Аренда земли"},
                        new Category { Name = "Земельный налог"},
                        new Category { Name = "На игровой бизнес"},
                        new Category { Name = "На недвижимость"},
                        new Category { Name = "Плата за размещение рекламы"},
                        new Category { Name = "Подоходный налог"},
                        new Category { Name = "Квартсдача"},
                        new Category { Name = "Транспортный налог"},
                        new Category { Name = "Единый налог с ИП"},
                    }
                },
                new Service{
                    Name = "Автошкола",
                    Categories = new List<Category>{
                        new Category { Name = "Дополнительное занятие"},
                        new Category { Name = "Курсы водителей"},
                        new Category { Name = "Топливо"},
                        new Category { Name = "Пересдача экзамена"},
                        new Category { Name = "Авто для экзамена в ГАИ"},
                        new Category { Name = "Прочие услуги"},
                    }
                },
                new Service{
                    Name = "Высшее образование",
                    Categories = new List<Category>{
                        new Category { Name = "Академическая задолженность"},
                        new Category { Name = "Взносы на укрепление МТБ"},
                        new Category { Name = "Возмещение средств за обучение"},
                        new Category { Name = "Коммунальные платежи"},
                        new Category { Name = "Курсы"},
                        new Category { Name = "Обучение"},
                        new Category { Name = "Общежитие"},
                        new Category { Name = "Прочие услуги"},
                        new Category { Name = "Прочие услуги (бюджет)"},
                        new Category { Name = "Путевки в санаторий"},
                    }
                },
                new Service{
                    Name = "РИКЗ",
                    Categories = new List<Category>{
                        new Category { Name = "Репетиционное тестирование"},
                        new Category { Name = "Централизованное тестирование"},
                    }
                },
                new Service{
                    Name = "Оплата В ЕРИП по коду услуги",
                    Categories = new List<Category>{
                        new Category { Name = "ВВести код и оплатить"},
                    }
                },
                new Service{
                    Name = "Сервис E-POS",
                    Categories = new List<Category>{
                        new Category { Name = "E-POS - оплата товаров и услуг"},
                    }
                },
                new Service{
                    Name = "ФСЗН",
                    Categories = new List<Category>{
                        new Category { Name = "Взносы за себя"},
                        new Category { Name = "Взносы за наёмных"},
                        new Category { Name = "Пеня за наёмных"},
                        new Category { Name = "Пеня за себя"},
                        new Category { Name = "Штрафы за себя"},
                        new Category { Name = "Штрафы за наёмных"},
                    }
                },
                new Service{
                    Name = "Прочие платежи",
                    Categories = new List<Category>{
                        new Category { Name = "Гостехосмотр"},
                        new Category { Name = "ГАИ - штрафы"},
                        new Category { Name = "Медицинские услуги"},
                        new Category { Name = "Социальные услуги"},
                        new Category { Name = "Ветеринарные услуги"},
                        new Category { Name = "Парковка"},
                        new Category { Name = "Суды"},
                        new Category { Name = "ЗАГС"},
                        new Category { Name = "СМИ"},
                        new Category { Name = "Таможенные платежи"},
                    }
                },
            };
            _context.Services.AddRange(categories);
            _context.SaveChanges();
        }
    }
}

