using DellChallenge.D1.Api.Dto;
using System.Collections.Generic;

namespace DellChallenge.D1.Api.Dal
{
    public interface IProductsService
    {
        ProductDto Get( string id);

        IEnumerable<ProductDto> GetAll();

        ProductDto Add(NewProductDto newProduct);

        ProductDto Delete(string id);

        void Update(ProductDto product);
    }
}
