namespace BlazorEcommerceProject.Server.Services.CartService
{
	public class CartService : ICartService
	{
		private readonly DataContext _context;
        public CartService(DataContext context)
		{
			_context = context;
		}
        public async Task<ServiceResponse<List<CartProductResponseDTO>>> GetCartProducts(List<CartItem> cartItems)
		{
			var result = new ServiceResponse<List<CartProductResponseDTO>>
			{
				Data = new List<CartProductResponseDTO>()
			};

			foreach(var cartItem in cartItems)
			{
				var product = await _context.Products
					.Where(p => p.Id == cartItem.ProductId)
					.FirstOrDefaultAsync();
				if (product == null)
				{
					continue;
				}

				var cartProduct = new CartProductResponseDTO
				{
					ProductId = product.Id,
					Title = product.Title,
					ImageUrl = product.ImageUrl,
					Price = product.Price,
					Quantity = cartItem.Quantity,
				};
				result.Data.Add(cartProduct);
			}
			return result;
		}
	}
}
