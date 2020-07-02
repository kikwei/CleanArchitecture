using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsCleanArch.Application.Products.Commands.CreateProduct;
using ProductsCleanArch.Application.Products.Commands.DeleteProduct;
using ProductsCleanArch.Application.Products.Commands.UpdateProduct;
using ProductsCleanArch.Application.Products.Queries.GetProduct;
using ProductsCleanArch.Application.Products.Queries.GetProducts;
using ProductsCleanArch.Domain.Entities;

namespace ProductsCleanArch.Presentation.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        [Route("api/v1/products/get-products")]
        [DisplayName("Can Get Products Listing")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductsListVm>> GetProducts()
        {
            var vm = await Mediator.Send(new GetProductsCommand());

            return base.Ok(vm);
        }

        [HttpGet]
        [Route("api/v1/products/get-product/{id}")]
        [DisplayName("Can Get Single Product")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var vm = await Mediator.Send(new GetProductCommand { Id = id });
            return base.Ok(vm);
        }

        [HttpPost]
        [Route("api/v1/products/create-product")]
        [DisplayName("Can Create Product")]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductCommand command)
        {
            var product = await Mediator.Send(command);
            return Ok(product);
        }

        [HttpPut]
        [Route("api/v1/products/update-product")]
        [DisplayName("Can Update Product")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("api/v1/products/delete-product/{id}")]
        [DisplayName("Can Delete Product")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]

        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

    }
}