using EComm.Domain.Models;

namespace EComm.Infrastructure.Interfaces
{
    public interface ISubCategoryRepository
    {
 

        public Task<IEnumerable<SubCategory>> GetSubCategoriesByCategoryId(int id);
        public Task<IEnumerable<SubCategory>> GetSubCategories();


        public Task SetSubCategory(SubCategory SubCategory);
        public Task UpdateSubCategory(SubCategory SubCategory);
        public Task DeleteSubCategory(int id);

    }
}
