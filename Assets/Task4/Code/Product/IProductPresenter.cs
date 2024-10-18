using UnityEngine;

namespace CurrencyTask4
{
    public interface IProductPresenter
    {
        int Price { get; }
        string ProductName { get; }
        string CurrencyType { get; }
        Sprite CurrencyImage { get; }
        Sprite ProductIcon { get; }
    }
}
