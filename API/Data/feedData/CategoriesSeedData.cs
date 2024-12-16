using API.Entities;

namespace API.Data
{
    public static class CategorySeedData
    {
        public static List<Category> Categories = new()
        {
            new Category
                { Name = "Ground coffee", Description = "A mix of different coffee beans for a unique blend" },
            new Category
                { Name = "Medium roast", Description = "A mix of different coffee beans for a unique blend" },
            new Category
                { Name = "Light roast", Description = "A mix of different coffee beans for a unique blend" },
            new Category
                { Name = "Organic", Description = "Grown without synthetic pesticides or fertilizers" },
            new Category
                { Name = "Espresso", Description = "A strong coffee brewed by forcing hot water through finely-ground coffee beans" },
            new Category
                { Name = "Limited Edition", Description = "A special, limited run of coffee blends" },
            new Category
                { Name = "Fair Trade", Description = "Coffee that supports fair wages for farmers" },
            new Category
                { Name = "Decaf", Description = "Coffee with most of the caffeine removed" },
            new Category
                { Name = "Single Origin", Description = "Coffee sourced from a single location" },
            new Category
                { Name = "Flavored", Description = "Coffee infused with different flavors" },
            new Category
                { Name = "Blend", Description = "A mix of different coffee beans for a unique blend" }
        };
    }
}