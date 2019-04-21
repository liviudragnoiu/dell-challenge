using System.Collections.Generic;
using System.Linq;
using DellChallenge.D1.Api.Dto;

namespace DellChallenge.D1.Api.Dal
{
    public class ProductsService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsService(ProductsContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _context.Products.Select(p => MapToDto(p));
        }

        public ProductDto Get(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                return MapToDto(product);
            }

            return null;
        }

        public ProductDto Add(NewProductDto newProduct)
        {
            var product = MapToData(newProduct);
            _context.Products.Add(product);
            _context.SaveChanges();
            var addedDto = MapToDto(product);
            return addedDto;
        }

        public bool Delete(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if(product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        private Product MapToData(NewProductDto newProduct)
        {
            return new Product
            {
                Category = newProduct.Category,
                Name = newProduct.Name
            };
        }

        private ProductDto MapToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category
            };
        }

        public bool Update(ProductDto productDto)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productDto.Id);

            if(product == null)
            {
                return false;
            }

            product.Name = productDto.Name;
            product.Category = productDto.Category;

            _context.SaveChanges();

            return true;
        }
    }
}
