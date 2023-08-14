using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickAnimation : MonoBehaviour
{
    private Button _button;
    private Image _image;

    private TextMeshProUGUI _text;

    private bool _playingAnimation;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HandleButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        if (_playingAnimation)
            return;

        _playingAnimation = true;
        var tweener = _button.transform
            .DOScale(new Vector3(1.8f, 1.8f, 1f), 0.1f)
            .SetLoops(2, LoopType.Yoyo);
        tweener.onComplete = () =>
        {
            _playingAnimation = false;
            _image.color = Random.ColorHSV();
            _text.color = Random.ColorHSV();
        };
    }
}
