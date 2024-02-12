using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private SkinsConfig skinsConfig;
        public UIConfig UIConfig => uiConfig;
        public SkinsConfig SkinsConfig => skinsConfig;
    }
}