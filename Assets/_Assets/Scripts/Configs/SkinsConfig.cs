using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Skins Config", menuName = "Configs/Skins")]
    public class SkinsConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] prefabs;
        public GameObject[] Prefabs => prefabs;
    }
}