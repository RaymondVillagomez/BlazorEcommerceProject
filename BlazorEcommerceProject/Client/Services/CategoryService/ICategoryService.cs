using System.Reflection.Metadata;

namespace BlazorEcommerceProject.Client.Services.CategoryService
{
	public interface ICategoryService
	{
        List<Category> Categories { get; set; }
		Task GetCategories();

	}
}
