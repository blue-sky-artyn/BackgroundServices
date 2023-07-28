using KlickbookEcommerceService.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Service
{

    public interface IXcartService
    {
        List<ProductsModel> ReadActiveData();
    }

    public class XcartService : IXcartService
    {
        private IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<XcartService> _logger;
        internal string _tenant { get; private set; }

        protected readonly IProductService _productService;
        protected readonly MilanoBusinessContextService _context;
        protected readonly XcardDataContext _xcardcontext;
        protected readonly ITenantService _tenantService;
        protected readonly IMasterDataService _masterDataService;

        private readonly IServiceScopeFactory _scopeFactory;

        public XcartService(
            IHostApplicationLifetime hostApplicationLifetime,
            ILogger<XcartService> logger,
            IServiceProvider serviceProvider,
            ITenantService tenantService,
            IServiceScopeFactory factory)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
            //_config = option;
            _tenantService = tenantService;
            //https://www.thecodebuzz.com/cannot-consume-scoped-service-from-singleton-ihostedservice/
            _context = factory.CreateScope().ServiceProvider.GetRequiredService<MilanoBusinessContextService>();
            _xcardcontext = factory.CreateScope().ServiceProvider.GetRequiredService<XcardDataContext>();
            //_context = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<MilanoBusinessContextService>();
        }


        public List<ProductsModel> ReadActiveData()
            => _xcardcontext.klickbookinvent.Where(x=>x.Active == 1 && x.updaterow == 1).ToList();
    }
}
