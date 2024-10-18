using UnityEngine;

namespace CurrencyTask4
{
    public sealed class ProductStorage : MonoBehaviour
    {
        [SerializeField] private ProductCatalog _productCatalog;

        public ProductPresenter GetRandomProductForMoney()
        {
            return new ProductPresenter(
                _productCatalog.ProductsForMoney[Random.Range(0, _productCatalog.ProductsForMoney.Length)]);
        }

        public ProductPresenter GetRandomProductForRubins()
        {
            return new(_productCatalog.ProductsForRubins[Random.Range(0, _productCatalog.ProductsForRubins.Length)]);
        }
    }
}
