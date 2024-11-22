using System.Drawing;


namespace TakoTea.Models
{
    public class ProductVariant
    {
        public string VariantName { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public Image Image { get; set; }

        public ProductVariant(string variantName, string size, decimal price, string ingredients, string instructions, Image image)
        {
            VariantName = variantName;
            Size = size;
            Price = price;
            Ingredients = ingredients;
            Instructions = instructions;
            Image = image;
        }

        public ProductVariant(string variantName, string size, decimal price, Image image)
        {
            VariantName = variantName;
            Size = size;
            Price = price;
            Image = image;
        }
    }
}
