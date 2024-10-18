using System;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;

namespace CurrencyTask4
{
    public sealed class CurrencyView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currencyText;
        [SerializeField] private float _fillRate;
        [SerializeField] private ScaleTweenParams _startScale;
        [SerializeField] private ScaleTweenParams _endScale;

        private Sequence _sequence;
        private IDisposable _disposable;
        private long _currency;

        public void Show(ICurrencyPresenter presenter)
        {
            _currency = presenter.Currency.Value;
            Setter(_currency);

            _disposable = presenter.Currency.Subscribe(OnCurrencyChanged);
        }

        private void OnCurrencyChanged(long newValue)
        {
            AnimateText(_currency, newValue);
            _currency = newValue;
        }

        private void AnimateText(long currenctValue, long nextValue)
        {
            _sequence?.Kill(); // Остановко твинов, которые проигрывались до этого
            // Анимация перебега текста
            DG.Tweening.Core.TweenerCore<long, long, DG.Tweening.Plugins.Options.NoOptions> tweenerCore =
                DOTween.To(() => currenctValue, Setter, nextValue, _fillRate);
            // Очередь анимаций: увеличение текста, перебег, уменьшение текста
            _sequence = DOTween
                .Sequence()
                .Append(_currencyText.transform.DOScale(_startScale.Scale, _startScale.Fillrate))
                .Append(tweenerCore)
                .Append(_currencyText.transform.DOScale(_endScale.Scale, _endScale.Fillrate));
        }

        private void Setter(long currenctValue)
        {
            _currencyText.text = currenctValue.ToString();
        }

        private void OnDisable()
        {
            _sequence?.Kill();
            _sequence = null;

            _disposable?.Dispose();
            _disposable = null;
        }
    }
}
