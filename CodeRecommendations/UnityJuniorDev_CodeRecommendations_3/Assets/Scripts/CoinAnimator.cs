using DG.Tweening;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CoinAnimator : MonoBehaviour
    {
        private Vector2 _defaultPosition;
        private Rigidbody2D _rigidbody;
        private Tweener _tweener;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _defaultPosition = _rigidbody.position;
        }

        private void OnEnable()
        {
            _rigidbody.position = _defaultPosition;
            _tweener = _rigidbody
                .DOMoveY(-0.5f, 1, false)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutQuad)
                .SetRelative(true)
                .SetId(this);
        }

        private void OnDisable()
        {          
            DOTween.Kill(_tweener.id);
        }
    }
}
