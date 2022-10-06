using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Api;

public class ProductGet
{
    private readonly IProductData productData;

    public ProductGet(IProductData productData)
    {
        this.productData = productData;
    }

    [FunctionName("ProductGet")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        var products = await productData.GetProducts();
        return new OkObjectResult(products);
    }
}
