using UnityEngine;

namespace _Assets.Scripts.Gameplay
{
    public class EndOfTheLevel : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        public Transform EndPoint => endPoint;
    }
}