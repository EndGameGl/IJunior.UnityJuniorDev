using UnityEngine;

namespace Assets.Scripts
{
    public class Inventory : MonoBehaviour
    {
        [field: SerializeField]
        public int MoneyAmount { get; private set; }
    }
}
