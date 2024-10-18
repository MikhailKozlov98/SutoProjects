using UnityEngine;

namespace CurrencyTask4
{
    public sealed class ProductPresenter : IProductPresenter
    {
        public int Price => _price;
        public string ProductName => _name;
        public string CurrencyType => _currencyType;
        public Sprite CurrencyImage => _currencyImage;
        public Sprite ProductIcon => _productIcon;

        private readonly int _price;
        private readonly string _name;
        private readonly string _currencyType;
        private readonly Sprite _currencyImage;
        private readonly Sprite _productIcon;


        public ProductPresenter(ProductData productData)
        {
            _price = productData.Price;
            _name = productData.Name;
            _currencyType = productData.CurrencyType;
            _currencyImage = productData.CurrencyImage;
            _productIcon = productData.ProductIcon;
        }
    }
}
