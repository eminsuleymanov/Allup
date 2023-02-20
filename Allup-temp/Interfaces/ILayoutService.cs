using System;
using Allup_temp.Models;
using Allup_temp.Models.ViewModels.BasketViewModels;

namespace Allup_temp.Interfaces
{
    public interface ILayoutService
    {
        Task<IDictionary<string, string>> GetSetting();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<BasketVM>> GetBaskets();
    }
}

