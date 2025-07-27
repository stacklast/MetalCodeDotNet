﻿using Backend.DTOs;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BeerRepository : IRepository<Beer>
    {
        private StoreContext _context;

        public BeerRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Beer>> Get() =>
            await _context.Beers.ToListAsync();

        public async Task<Beer> GetById(int id) =>
            await _context.Beers.FindAsync(id);

        public async Task Add(Beer beer) =>
            await _context.Beers.AddAsync(beer);

        public void Update(Beer beer)
        {
            throw new NotImplementedException();
        }

        public void Delete(Beer entity)
        {
            throw new NotImplementedException();
        }
        public async Task Save() => 
            await _context.SaveChangesAsync();
    }
}
