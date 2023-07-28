using KlickbookEcommerceService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService._helper
{
    public class ProductListingHelper
    {
        protected readonly MilanoBusinessContextService _context;
        private readonly IServiceScopeFactory _scopeFactory;

        public ProductListingHelper(IServiceScopeFactory factory)
        {
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<MilanoBusinessContextService>();
        }

        public bool IsModuleIdExist(string moduleId)
            => _context.Module.Any(x=>x.ModuleId.Equals(moduleId));

        //public bool CheckUpdateday(string moduleId)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
