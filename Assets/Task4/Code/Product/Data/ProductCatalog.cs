using UnityEngine;

namespace CurrencyTask4
{
    [CreateAssetMenu(fileName = "ProductCatalog", menuName = "ProductData/New ProductCatalog")]
    public sealed class ProductCatalog : ScriptableObject
    {
        public ProductData[] ProductsForMoney;
        public ProductData[] ProductsForRubins;
    }
}
