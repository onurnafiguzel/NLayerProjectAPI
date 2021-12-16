﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Models;

namespace NLayerProject.Core.Services
{
    public interface ICategorySerivce : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
