using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.eShopWeb.Web.Services;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ICatalogViewModelService _catalogViewModelService;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ICatalogViewModelService catalogViewModelService, ILogger<IndexModel> logger)
    {
        _catalogViewModelService = catalogViewModelService;
        _logger = logger;
    }

    public CatalogIndexViewModel CatalogModel { get; set; } = new CatalogIndexViewModel();

    public async Task OnGet(CatalogIndexViewModel catalogModel, int? pageId)
    {
        var brand = catalogModel.Brands?.FirstOrDefault()?.Text??"All";
        var type = catalogModel.CatalogItems?.FirstOrDefault()?.Name??"All";

        _logger.LogWarning("Fetching catalog items - Brand: {ProductBrand} - Type: {ProductType}",brand,type);

        if (pageId.HasValue & pageId > 0)
            throw new NotImplementedException("Paging is not implemented yet!");
        CatalogModel = await _catalogViewModelService.GetCatalogItems(pageId ?? 0, Constants.ITEMS_PER_PAGE, catalogModel.BrandFilterApplied, catalogModel.TypesFilterApplied);

    }
}
