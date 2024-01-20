using Blazored.LocalStorage;

namespace BlazorEcommerceProject.Client.Services.CartService
{
	public class CartService : ICartService
	{
		public readonly ILocalStorageService _localStorage;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="localStorage"></param>
		public CartService(ILocalStorageService localStorage)
		{
			_localStorage = localStorage;
		}

		public event Action OnChange;

		public async Task AddToCart(CartItem cartItem)
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if(cart == null)
			{
				cart = new List<CartItem>();
			}
			cart.Add(cartItem);

			await _localStorage.SetItemAsync("cart", cart);
			OnChange.Invoke();
		}

		public async Task<List<CartItem>> GetCartItems()
		{
			var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
			if (cart == null)
			{
				cart = new List<CartItem>();
			}

			return cart;
		}
	}
}
