using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult<string> Get(int id)
        {
            var product = _productsService.Get(id.ToString());

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public ActionResult<ProductDto> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Delete(int id)
        {
           var product = _productsService.Delete(id.ToString());

            if (product == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            var product = _productsService.Get(id.ToString());

            if (product == null)
            {

                var putProduct = JsonConvert.DeserializeObject(value, typeof(NewProductDto)) as NewProductDto;

                if(putProduct == null)
                {
                    return BadRequest();
                }

                product.Name = putProduct.Name;
                product.Category = putProduct.Category;
                _productsService.Update(product);
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
