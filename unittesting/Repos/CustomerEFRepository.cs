﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using unittesting.Entities;
using unittesting.Interfaces.Repos;
using unittesting.Models;

namespace unittesting.Repos
{
    public class CustomerEFRepository : GenericEFRepository<Customer>, ICustomerRepository
    {
        public CustomerEFRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Order> GetCustomerOrders(int id)
        {
            return _context.Set<Order>().Include(c => c.Customer).Where(c => c.CustomerId == id).ToList();
        }
    }
}
