using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "UI Config", menuName = "Configs/UI")]
    public class UIConfig : ScriptableObject
    {
        [SerializeField] private GameObject mainUI;
        [SerializeField] private GameObject gameUI;
        [SerializeField] private GameObject winUI;
        [SerializeField] private GameObject loseUI;
        public GameObject MainUI => mainUI;
        public GameObject GameUI => gameUI;
        public GameObject WinUI => winUI;
        public GameObject LoseUI => loseUI;
    }
}