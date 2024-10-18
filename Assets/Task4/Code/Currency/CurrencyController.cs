using UnityEngine;
using Zenject;

namespace CurrencyTask4
{
    public sealed class CurrencyController : MonoBehaviour
    {
        [SerializeField] private CurrencyView _moneyView;
        [SerializeField] private CurrencyView _rubinView;

        private MoneyStorage _moneyStorage;
        private RubinStorage _rubinStorage;

        [Inject]
        private void Construct(MoneyStorage moneyStorage, RubinStorage rubinStorage)
        {
            _moneyStorage = moneyStorage;
            _rubinStorage = rubinStorage;
        }

        private void Start()
        {
            _moneyView.Show(new MoneyPresenter(_moneyStorage));
            _rubinView.Show(new RubinPresenter(_rubinStorage));
        }
    }
}
