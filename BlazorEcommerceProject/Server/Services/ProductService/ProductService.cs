﻿using BlazorEcommerceProject.Shared;
using System.Collections.Generic;

namespace BlazorEcommerceProject.Server.Services.ProductService
{
	public class ProductService : IProductService
	{
		private readonly DataContext _context;

		public ProductService(DataContext context)
        {
			_context = context;     
        }

		public async Task<ServiceResponse<Product>> GetProductAsync(int productId)
		{
			var response = new ServiceResponse<Product>();
			var product = await _context.Products.FindAsync(productId);
			if (product == null)
			{
				response.Success = false;
				response.Message = "Sorry, but this product does not exist.";
			}
			else
			{
				response.Data = product;
			}

			return response;
		}

        public async Task<ServiceResponse<List<Product>>> GetProductsByCategory(string categoryUrl)
        {
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products.Where(p => p.Category.Url.ToLower().Equals(categoryUrl.ToLower())).ToListAsync()
			};

			return response;
        }

        public  async Task<ServiceResponse<List<Product>>> GetProductsAsync()
		{
			var response = new ServiceResponse<List<Product>>
			{
				Data = await _context.Products.ToListAsync()
			};

			return response;
		}

		public async Task<ServiceResponse<ProductSearchResultDTO>> SearchProducts(string searchText, int page)
		{


			var pageResult = 2f;
			var pageCount = Math.Ceiling((await FindProductsBySearchText(searchText)).Count / pageResult);
			var products = await _context.Products
							.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
							||
							p.Description.ToLower().Contains(searchText.ToLower()))
							.Skip((page - 1) * (int)pageResult)
							.Take((int)pageResult)
							.ToListAsync();


			var response = new ServiceResponse<ProductSearchResultDTO>
			{
				Data = new ProductSearchResultDTO
				{
					Products = products,
					Pages = page,
					CurrentPage = (int)pageCount
				}
			};

			return response;
		}

		private async Task<List<Product>> FindProductsBySearchText(string searchText)
		{
			return await _context.Products
							.Where(p => p.Title.ToLower().Contains(searchText.ToLower())
							||
							p.Description.ToLower().Contains(searchText.ToLower())).ToListAsync();
		}

		public async Task<ServiceResponse<List<string>>> GetProductSearchSuggestions(string searchText)
		{

			var products = await FindProductsBySearchText(searchText);

			List<string> result = new List<string>();

			foreach (var product in products)
			{
				if (product.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase))
				{
					result.Add(product.Title);
				}

				if(product.Description != null)
				{
					var punctuation = product.Description.Where(char.IsPunctuation)
						.Distinct().ToArray();
					var words = product.Description.Split()
						.Select(s => s.Trim(punctuation));

					foreach (var word in words)
					{
						if(word.Contains(searchText, StringComparison.OrdinalIgnoreCase) && !result.Contains(word))
						{
							result.Add(word);
						}
					}
				}
			}

			return new ServiceResponse<List<string>> { Data = result };
		}
	}
}
