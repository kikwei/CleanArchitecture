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
        [AllowAnonymous]
        public async Task<ActionResult<ProductsListVm>> GetProducts()
        {
            var vm = await Mediator.Send(new GetProductsCommand());

            return base.Ok(vm);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var vm = await Mediator.Send(new GetProductCommand { Id = id });
            return base.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Create([FromBody] CreateProductCommand command)
        {
            var product = await Mediator.Send(command);
            return Ok(product);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]

        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }

    }
}