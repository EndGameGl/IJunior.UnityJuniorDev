using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    public class CoinAnimator : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Tweener _tweener;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _tweener = _rigidbody
                .DOMoveY(-0.5f, 1, false)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad)
                .SetRelative(true);
        }

        private void OnDisable()
        {
            DOTween.Kill(_tweener);
        }
    }
}
