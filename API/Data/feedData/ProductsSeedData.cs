using API.Entities;

namespace API.Data
{
    public static class ProductSeedData
    {
        public static List<Product> GetProducts(List<Category> categories)
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Colombian Supremo",
                    ShortDescription = "Rich and smooth Colombian coffee with caramel notes.",
                    Description = "A medium roast with a rich flavor, caramel undertones, and balanced acidity. 100% Arabica beans sourced from the Colombian highlands.",
                    Price = 1899,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/or9k5lchhobkkiesydss.jpg",
                    Stock = 1000,
                    Slug = "colombian-supremo",
                    Categories = new List<Category> { categories[0], categories[1] }
                },

                new Product
                {
                    Name = "Ethiopian Yirgacheffe",
                    ShortDescription = "Bright and floral coffee from Ethiopia.",
                    Description = "A light roast with distinct floral notes, hints of jasmine, and bright citrus acidity. Perfect for pour-over coffee lovers.",
                    Price = 2099,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/dkgkirlghczwagf8xzy4.jpg",
                    Stock = 850,
                    Slug = "ethiopian-yirgacheffe",
                    Categories = new List<Category> { categories[2], categories[8] }
                },

                new Product
                {
                    Name = "Sumatra Mandheling",
                    ShortDescription = "Bold and earthy dark roast coffee.",
                    Description = "A dark roast with a full body, low acidity, and rich notes of dark chocolate and spices. Sourced from Sumatra, Indonesia.",
                    Price = 1999,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/k1qrwppemmrbkh1ua283.jpg",
                    Stock = 750,
                    Slug = "sumatra-mandheling",
                    Categories = new List<Category> { categories[4], categories[10] }
                },

                new Product
                {
                    Name = "Brazil Santos",
                    ShortDescription = "Smooth and nutty medium roast coffee.",
                    Description = "A balanced medium roast with notes of hazelnut, cocoa, and a creamy finish. Grown in the fertile coffee regions of Brazil.",
                    Price = 1799,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/v9hpxqmflttrpddjusqo.jpg",
                    Stock = 1200,
                    Slug = "brazil-santos",
                    Categories = new List<Category> { categories[0], categories[1] }
                },

                new Product
                {
                    Name = "Panama Geisha",
                    ShortDescription = "Exclusive Geisha variety with complex flavors.",
                    Description = "A light roast with delicate notes of jasmine, bergamot, and peach. An exceptional single-origin coffee for true enthusiasts.",
                    Price = 4999,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/wrtndqrleh2ji865tpd6.jpg",
                    Stock = 300,
                    Slug = "panama-geisha",
                    Categories = new List<Category> { categories[2], categories[8] }
                },

                new Product
                {
                    Name = "Kenya AA",
                    ShortDescription = "Bright and fruity Kenyan coffee.",
                    Description = "A medium roast with vibrant acidity, wine-like body, and notes of blackcurrant and grapefruit.",
                    Price = 2299,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/x1limk7boo3vemydfbfk.jpg",
                    Stock = 900,
                    Slug = "kenya-aa",
                    Categories = new List<Category> { categories[0], categories[8] }
                },

                new Product
                {
                    Name = "Costa Rica Tarrazu",
                    ShortDescription = "Well-balanced coffee with honey sweetness.",
                    Description = "A medium roast with clean notes of honey, orange, and subtle nuttiness. Grown in Costa Rica's famed Tarrazu region.",
                    Price = 1999,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/uthm6vnjrumhetvarfzx.jpg",
                    Stock = 1000,
                    Slug = "costa-rica-tarrazu",
                    Categories = new List<Category> { categories[3], categories[10] }
                },

                new Product
                {
                    Name = "Guatemala Antigua",
                    ShortDescription = "Rich and smoky coffee from Antigua.",
                    Description = "A medium-dark roast with notes of cocoa, smoke, and hints of spice. Perfect for those who love bold flavors.",
                    Price = 1899,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/eyecxyyqkvycufvbxyho.jpg",
                    Stock = 950,
                    Slug = "guatemala-antigua",
                    Categories = new List<Category> { categories[0], categories[4] }
                },

                new Product
                {
                    Name = "Hawaiian Kona Blend",
                    ShortDescription = "Smooth and luxurious Kona coffee blend.",
                    Description = "A medium roast with buttery smoothness, tropical fruit notes, and a clean finish. Blended with premium beans.",
                    Price = 3899,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/djeqlfhxvenoiuybe9eb.jpg",
                    Stock = 500,
                    Slug = "hawaiian-kona-blend",
                    Categories = new List<Category> { categories[5], categories[8] }
                },

                new Product
                {
                    Name = "Decaf French Roast",
                    ShortDescription = "Dark and bold decaf coffee.",
                    Description = "A bold and smoky dark roast, 99.9% caffeine-free. Perfect for coffee lovers avoiding caffeine.",
                    Price = 1799,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/wezo2cukn5ikvl3knfiz.jpg",
                    Stock = 700,
                    Slug = "decaf-french-roast",
                    Categories = new List<Category> { categories[4], categories[7] }
                },

                new Product
                {
                    Name = "Vietnam Robusta",
                    ShortDescription = "Strong and full-bodied Robusta coffee.",
                    Description = "A dark roast with intense body, chocolatey richness, and hints of spices. Sourced from Vietnam's best coffee farms.",
                    Price = 1599,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/mvimoadnjyzxelz9r7np.jpg",
                    Stock = 1200,
                    Slug = "vietnam-robusta",
                    Categories = new List<Category> { categories[4], categories[10] }
                },

                new Product
                {
                    Name = "Organic Peru Chanchamayo",
                    ShortDescription = "Organic coffee with vanilla and maple notes.",
                    Description = "A medium roast with smooth vanilla, maple syrup, and floral undertones. 100% organic and fair-trade certified.",
                    Price = 2099,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/mv9y9s0tomuykunlp14f.jpg",
                    Stock = 800,
                    Slug = "organic-peru-chanchamayo",
                    Categories = new List<Category> { categories[3], categories[6] }
                },

                new Product
                {
                    Name = "Limited Edition Caramel Dream",
                    ShortDescription = "Special edition coffee with caramel sweetness.",
                    Description = "A limited-edition blend with rich caramel sweetness, velvety body, and subtle hints of cocoa.",
                    Price = 2499,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/sq2rvrwt5mmgqkb8yowh.jpg",
                    Stock = 300,
                    Slug = "limited-edition-caramel-dream",
                    Categories = new List<Category> { categories[5], categories[10] }
                },

                new Product
                {
                    Name = "Fair Trade Nicaragua",
                    ShortDescription = "Smooth and ethical Nicaraguan coffee.",
                    Description = "A medium roast with notes of chocolate, nuts, and gentle citrus acidity. Fair-trade certified to support farmers.",
                    Price = 1899,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/wdanbjxuftsct1hafv88.jpg",
                    Stock = 1000,
                    Slug = "fair-trade-nicaragua",
                    Categories = new List<Category> { categories[6], categories[1] }
                },

                new Product
                {
                    Name = "House Blend",
                    ShortDescription = "Signature house blend with balanced flavors.",
                    Description = "A medium roast with a perfect balance of sweetness, nuttiness, and a smooth finish. A crowd-pleaser for all coffee lovers.",
                    Price = 1499,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899401/or9k5lchhobkkiesydss.jpg",
                    Stock = 1500,
                    Slug = "house-blend",
                    Categories = new List<Category> { categories[0], categories[10] }
                },

                new Product
                {
                    Name = "Flavored Vanilla Hazelnut",
                    ShortDescription = "Rich vanilla and hazelnut flavored coffee.",
                    Description = "A smooth medium roast infused with the classic flavors of vanilla bean and toasted hazelnut.",
                    Price = 1699,
                    PictureUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1733899400/emm4cu1mcwqxl3kjtub4.jpg",
                    Stock = 600,
                    Slug = "flavored-vanilla-hazelnut",
                    Categories = new List<Category> { categories[9], categories[0] }
                },
            };
        }
    }
}