﻿using UnityEngine;

namespace _Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Enemies Config", menuName = "Configs/Enemies Config")]
    public class EnemiesConfig : ScriptableObject
    {
        [SerializeField] private GameObject[] enemies;
        public GameObject[] Enemies => enemies;
    }
}