using _Assets.Scripts.Gameplay.Players;
using _Assets.Scripts.Services.UIs.StateMachine;
using UnityEngine;
using VContainer;

namespace _Assets.Scripts.Gameplay
{
    public class EndOfTheLevel : MonoBehaviour
    {
        [SerializeField] private Transform endPoint;
        [Inject] private UIStateMachine _uiStateMachine;

        public Transform EndPoint => endPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerController _))
            {
                _uiStateMachine.SwitchState(UIStateType.Win);
            }
        }
    }
}