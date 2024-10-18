using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CurrencyTask4
{

    public sealed class PopupView : MonoBehaviour
    {
        [SerializeField] private Button _positiveButton;
        [SerializeField] private Button _negativeButton;
        [SerializeField] private TMP_Text _questionText;
        [SerializeField] private TMP_Text _productNameText;
        [SerializeField] private Image _currencyImage;
        [SerializeField] private Image _productIcon;

        private PopupViewModel _popupViewModel;

        public void Initialize(PopupViewModel viewModel, IProductPresenter presenter, bool enoughCurrency)
        {
            _popupViewModel = viewModel;

            _questionText.text = $"Списать {presenter.Price} {presenter.CurrencyType} за";
            _productNameText.text = $"{presenter.ProductName}?";

            _currencyImage.sprite = presenter.CurrencyImage;
            _productIcon.sprite = presenter.ProductIcon;

            _positiveButton.interactable = enoughCurrency;
            if (!enoughCurrency) Debug.Log("Недостаточно денег на покупку предмета.");
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _positiveButton.onClick.AddListener(PositiveResponceButtonOnClick);
            _negativeButton.onClick.AddListener(NavigationResponceButtonOnClick);
        }

        private void OnDisable()
        {
            _positiveButton.onClick.RemoveListener(PositiveResponceButtonOnClick);
            _negativeButton.onClick.RemoveListener(NavigationResponceButtonOnClick);
            _popupViewModel = null;
        }

        private void PositiveResponceButtonOnClick()
        {
            _popupViewModel.PositiveResponse();
            Hide();
        }

        private void NavigationResponceButtonOnClick()
        {
            _popupViewModel.NegativeResponse();
            Hide();
        }
    }
}
