using UnityEngine;

namespace _Assets.Scripts.Configs
{
    public class ConfigProvider : MonoBehaviour
    {
        [SerializeField] private UIConfig uiConfig;
        [SerializeField] private SkinsConfig skinsConfig;
        [SerializeField] private EnemiesConfig enemiesConfig;
        [SerializeField] private LevelsConfig levelsConfig;
        public UIConfig UIConfig => uiConfig;
        public SkinsConfig SkinsConfig => skinsConfig;
        public EnemiesConfig EnemiesConfig => enemiesConfig;
        public LevelsConfig LevelsConfig => levelsConfig;
    }
}