using UnityEngine;

namespace CurrencyTask4
{
    [CreateAssetMenu(fileName = "Product", menuName = "ProductData/New Product")]
    public sealed class ProductData : ScriptableObject
    {
        [SerializeField] private int _price;
        [SerializeField] private string _name;
        [SerializeField] private string _currencyType;
        [SerializeField] private Sprite _currencyImage;
        [SerializeField] private Sprite _productIcon;

        public int Price => _price;
        public string Name => _name;
        public string CurrencyType => _currencyType;
        public Sprite CurrencyImage => _currencyImage;
        public Sprite ProductIcon => _productIcon;
    }
}
