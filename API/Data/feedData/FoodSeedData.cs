using API.Entities;

namespace API.Data.feedData
{
    public static class FoodSeedData
    {
        public static List<Food> Foods = new()
        {
            new Food
            {
                Name = "Ham & Cheese Croissant",
                Description = "Buttery croissant layered with black forest ham and Swiss cheese.",
                Price = 15.99m,
                Type = "food",
                Slug = "ham-cheese-croissant",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734311099/menu/pwjd9k9dlr9z6ggjrvwr.jpg"
                
            },
            new Food
            {
                Name = "Mixed Berry Muffin",
                Description = "Moist muffin packed with raspberries, blueberries and blackberries.",
                Price = 7.99m,
                Type = "food",
                Slug = "mixed-berry-muffin",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734311099/menu/tg8yk6orl7ro5khxut2x.jpg"
            },
            new Food
            {
                Name = "Pain au Chocolat",
                Description = "Classic French pastry with dark chocolate batons and flaky layers.",
                Price = 9.99m,
                Type = "food",
                Slug = "pain-au-chocolat",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734311098/menu/o7vwd9hxe8uhaslwom9e.jpg"
            },
            new Food
            {
                Name = "Cream Cheese Danish",
                Description = "Traditional Danish pastry with vanilla-scented cream cheese filling.",
                Price = 9.99m,
                Type = "food",
                Slug = "cream-cheese-danish",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/kmlej0ewzodjiwvp6kyo.jpg"
            },
            new Food
            {
                Name = "Artisan Scone Trio",
                Description = "Three freshly baked scones: cranberry, chocolate chip, and lemon.",
                Price = 8.99m,
                Type = "food",
                Slug = "artisan-scone-trio",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/yrodducy7ulsyvg0sefe.jpg"
            },
            new Food
            {
                Name = "Glazed Cinnamon Swirl",
                Description = "Spiral-shaped pastry with cinnamon sugar and vanilla glaze.",
                Price = 10.99m,
                Type = "food",
                Slug = "glazed-cinnamon-swirl",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/kymq8hequzyhywchdonp.jpg"
            },
            new Food
            {
                Name = "Caramel Apple Danish",
                Description = "Flaky Danish filled with spiced apples and salted caramel.",
                Price = 9.99m,
                Type = "food",
                Slug = "caramel-apple-danish",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/yigwkdhwgug1rtc8x83w.jpg"
            },
            new Food
            {
                Name = "Banana Nut Loaf",
                Description = "Rich banana bread studded with toasted walnuts and pecans.",
                Price = 8.99m,
                Type = "food",
                Slug = "banana-nut-loaf",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/o5h26ofkedj0oitqnfwd.jpg"
            },
            new Food
            {
                Name = "Cinnamon Spice",
                Description = "Warming cinnamon mixed with espresso and steamed milk.",
                Price = 13.99m,
                Type = "drink",
                Slug = "cinnamon-spice",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/qzrys7fuodojyaic5ldt.jpg"
            },
            new Food
            {
                Name = "Toffee Nut",
                Description = "Sweet toffee and nutty flavors with smooth espresso.",
                Price = 14.99m,
                Type = "drink",
                Slug = "toffee-nut",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/y6pkmy9oo3yadjliya7d.jpg"
            },
            new Food
            {
                Name = "Caramel Latte",
                Description = "Smooth espresso with steamed milk and rich caramel syrup.",
                Price = 14.99m,
                Type = "drink",
                Slug = "caramel-latte",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310708/menu/xtlp5qqkbdl74wnphlfk.jpg"
            },
            new Food
            {
                Name = "Classic Blk",
                Description = "A bold, rich shot of pure coffee slowly roasted to perfection.",
                Price = 12.99m,
                Type = "drink",
                Slug = "classic-blk",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/yyz42sfmqeamg4yjpmrp.jpg"
            },
            new Food
            {
                Name = "Mocha Dream",
                Description = "Perfect blend of espresso, chocolate and steamed milk.",
                Price = 15.99m,
                Type = "drink",
                Slug = "mocha-dream",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/ayfvhnde3xldmc6vhr5m.jpg"
            },
            new Food
            {
                Name = "Irish Cream",
                Description = "Non-alcoholic Irish cream flavored coffee with milk.",
                Price = 15.99m,
                Type = "drink",
                Slug = "irish-cream",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/cqttsu6artcwykq3lvtb.jpg"
            },
            new Food
            {
                Name = "Vanilla Bean",
                Description = "Creamy espresso with vanilla bean and frothed milk.",
                Price = 13.99m,
                Type = "drink",
                Slug = "vanilla-bean",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310708/menu/josublkd16whwq2px1ef.jpg"
            },
            new Food
            {
                Name = "Hazelnut Heaven",
                Description = "Rich espresso infused with hazelnut and creamy milk.",
                Price = 14.99m,
                Type = "drink",
                Slug = "hazelnut-heaven",
                ImageUrl = "https://res.cloudinary.com/de1yaxfb4/image/upload/v1734310709/menu/rxpgqfnoiem7kh0mx3mu.jpg"
            }
        };
    }
}