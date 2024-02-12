using TriInspector;
using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Levels Config", menuName = "Configs/Levels Config")]
    public class LevelsConfig : ScriptableObject
    {
        [Scene, SerializeField] private string[] levels;
        public string[] Levels => levels;
    }
}