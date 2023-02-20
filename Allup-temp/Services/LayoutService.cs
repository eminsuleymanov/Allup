using System;
using Allup_temp.DataAccesLayer;
using Allup_temp.Interfaces;
using Allup_temp.Models;
using Allup_temp.Models.ViewModels.BasketViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Allup_temp.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext appDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LayoutService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            this.appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IEnumerable<BasketVM>> GetBaskets()
        {
            string basket = _httpContextAccessor.HttpContext.Request.Cookies["basket"];

            List<BasketVM> basketVMs = null;

            if (!string.IsNullOrWhiteSpace(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                foreach (BasketVM basketVM in basketVMs)
                {
                    Product product = await appDbContext.Products
                        .FirstOrDefaultAsync(p => p.Id == basketVM.Id && p.IsDeleted == false);

                    if (product != null)
                    {
                        basketVM.ExTax = product.ExTax;
                        basketVM.Price = product.DiscountedPrice > 0 ? product.DiscountedPrice : product.Price;
                        basketVM.Title = product.Title;
                        basketVM.Image = product.MainImage;
                    }
                }
            }
            else
            {
                basketVMs = new List<BasketVM>();
            }

            return basketVMs;

        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await appDbContext.Categories.Include(c=>c.Children).Where(c=>c.IsMain && c.IsDeleted == false).ToListAsync();
        }

        public async Task<IDictionary<string, string>> GetSetting()
        {
            IDictionary<string,string> settings = await appDbContext.Settings.ToDictionaryAsync(s=>s.Key,s=>s.Value);
            return settings;
        }
    }
}

