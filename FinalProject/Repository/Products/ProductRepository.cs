using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        public ProductRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ProductCreateUpdateDTO> CreateProduct(ProductCreateUpdateDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return _mapper.Map<ProductCreateUpdateDTO>(await ProductDAO.CreateProduct(product));
        }

        public async Task<bool> CreateProductMany(List<ProductCreateUpdateDTO> listProductDTO)
        {
            var listProducts = _mapper.Map<List<Product>>(listProductDTO);
            return await ProductDAO.CreateProductMany(listProducts);
        }

        public async Task DeleteProduct(int id) => await ProductDAO.DeleteProduct(id);

        public async Task<ProductDTO> GetProductById(int id)
        {
            Product product = await ProductDAO.GetProductById(id);
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);

            return productDTO;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            List<Product> products = await ProductDAO.GetProducts();
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return productDTOs;
        }

        public async Task<List<ProductDTO>> GetProducts(int? categoryId, string? text, string? sortType, decimal? startPrice, decimal? endPrice, bool? isAdmin)
        {
            List<Product> products = await ProductDAO.GetProducts(categoryId, text, sortType, startPrice, endPrice, isAdmin);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return productDTOs;
        }

        public async Task<List<ProductDTO>> GetProductsByCategory(int catId)
        {
            List<Product> products = await ProductDAO.GetProductsByCategory(catId);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return productDTOs;
        }

        public async Task<List<ProductDTO>> GetProductsByCategoryGeneral(string catGeneral)
        {
            List<Product> products = await ProductDAO.GetProductsByCategoryGeneral(catGeneral);
            List<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);

            return productDTOs;
        }

        public async Task<ProductCreateUpdateDTO> UpdateProduct(ProductCreateUpdateDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return _mapper.Map<ProductCreateUpdateDTO>(await ProductDAO.UpdateProduct(product));
        }
    }
}
