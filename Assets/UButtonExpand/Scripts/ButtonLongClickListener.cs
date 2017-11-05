using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

namespace UButtonExpand{
	
	[AddComponentMenu("ButtonLongClickListener")]
	[RequireComponent(typeof(Button))]
	public class ButtonLongClickListener : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerExitHandler {

		private float delay = 0.2f;

		private bool isDown = false;  

		private float lastIsDownTime;

		[Serializable]
		public class ButtonClickedEvent : UnityEvent { }

		[SerializeField]
		private ButtonClickedEvent m_OnLongClick = new ButtonClickedEvent();

		public ButtonClickedEvent onLongClick
		{
			get { return m_OnLongClick; }
			set { m_OnLongClick = value; }
		}

		void Update ()  {
			if (isDown) {
				if (Time.time - lastIsDownTime > delay) {
					lastIsDownTime = Time.time;
					if(m_OnLongClick != null){
						m_OnLongClick.Invoke();
					}
				}
			}
		}

		public void OnPointerDown (PointerEventData eventData){
			isDown = true;
			lastIsDownTime = Time.time;
		}  

		public void OnPointerUp (PointerEventData eventData){
			isDown = false;  
		}  

		public void OnPointerExit (PointerEventData eventData){
			isDown = false;
		}
	}
}