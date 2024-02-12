using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private GameObject mainUI;
        [SerializeField] private GameObject gameUI;
        public GameObject MainUI => mainUI;
        public GameObject GameUI => gameUI;
    }
}