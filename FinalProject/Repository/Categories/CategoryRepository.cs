using AutoMapper;
using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper _mapper;
        public CategoryRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            return _mapper.Map<CategoryDTO>(await CategoryDAO.CreateCategory(category));
        }

        public async Task DeleteCategory(int id) => await CategoryDAO.DeleteCategory(id);

        public async Task<List<CategoryDTO>> GetCategories()
        {
            List<Category> categories = await CategoryDAO.GetCategories();
            List<CategoryDTO> categoryDTOs = _mapper.Map<List<CategoryDTO>>(categories);

            return categoryDTOs;
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
            Category categories = await CategoryDAO.GetCategoryById(id);
            CategoryDTO categoryDTOs = _mapper.Map<CategoryDTO>(categories);

            return categoryDTOs;
        }

        public async Task<List<string>> GetCategoryGeneral() => await CategoryDAO.GetCategoryGeneral();

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            return _mapper.Map<CategoryDTO>(await CategoryDAO.UpdateCategory(category));
        }
    }
}
