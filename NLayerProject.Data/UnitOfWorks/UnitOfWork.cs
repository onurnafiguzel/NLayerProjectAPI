﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.UnitOfWorks;
using NLayerProject.Data.Repositories;

namespace NLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IProductRepository Products =>
            _productRepository = _productRepository ?? new ProductRepository(_context);

        public ICategoryRepository Categories =>
            _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
