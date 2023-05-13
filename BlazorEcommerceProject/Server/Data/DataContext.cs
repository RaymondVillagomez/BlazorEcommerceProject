using Microsoft.EntityFrameworkCore;

namespace BlazorEcommerceProject.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options ) : base(options)
		{ 

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().HasData(
					new Product
					{
						Id = 1,
						Title = "Star Wars: Episode I – The Phantom Menace",
						Description = "Star Wars: Episode I – The Phantom Menace is a 1999 American epic space opera film written and directed by George Lucas. It stars Liam Neeson, Ewan McGregor, Natalie Portman, Jake Lloyd, Ahmed Best, Ian McDiarmid, Anthony Daniels, Kenny Baker, Pernilla August, and Frank Oz. It is the fourth film in the Star Wars film series, the first film of the prequel trilogy and the first chronological chapter of the Skywalker Saga. Set 32 years before the original trilogy, during the era of the Galactic Republic, the plot follows Jedi Master Qui-Gon Jinn and his apprentice Obi-Wan Kenobi as they try to protect Queen Padmé Amidala of Naboo in hopes of securing a peaceful end to an interplanetary trade dispute. Joined by Anakin Skywalker—a young slave with unusually strong natural powers of the Force—they simultaneously contend with the mysterious return of the Sith. The film was produced by Lucasfilm, with 20th Century Fox distributing.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/4/40/Star_Wars_Phantom_Menace_poster.jpg/220px-Star_Wars_Phantom_Menace_poster.jpg",
						Price = 9.98m
					},
					new Product
					{
						Id = 2,
						Title = "The Lord of the Rings",
						Description = "The Lord of the Rings is an epic[1] high-fantasy novel[a] by English author and scholar J. R. R. Tolkien. Set in Middle-earth, the story began as a sequel to Tolkien's 1937 children's book The Hobbit, but eventually developed into a much larger work. Written in stages between 1937 and 1949, The Lord of the Rings is one of the best-selling books ever written, with over 150 million copies sold.[2]",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/e/e9/First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif/220px-First_Single_Volume_Edition_of_The_Lord_of_the_Rings.gif",
						Price = 10.99m
					},
					new Product
					{
						Id = 3,
						Title = "Blade Runner 2049",
						Description = "Blade Runner 2049 is a 2017 American epic neo-noir science fiction film directed by Denis Villeneuve and written by Hampton Fancher and Michael Green.[10] A sequel to the 1982 film Blade Runner, the film stars Ryan Gosling and Harrison Ford, with Ana de Armas, Sylvia Hoeks, Robin Wright, Mackenzie Davis, Dave Bautista, and Jared Leto in supporting roles. Ford and Edward James Olmos reprise their roles from the original film. Gosling plays K, a Nexus-9 replicant blade runner who uncovers a secret that threatens to destabilize society and the course of civilization.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9b/Blade_Runner_2049_poster.png",
						Price = 11.99m
					}
				);
		}
		public DbSet<Product> Products { get; set; }

	}
}
