using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Assets.Scripts.Services.UIs
{
    public class MyButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnButtonDown;
        public event Action OnButtonUp;
        
        public void OnPointerDown(PointerEventData eventData) => OnButtonDown?.Invoke();

        public void OnPointerUp(PointerEventData eventData) => OnButtonUp?.Invoke();
    }
}