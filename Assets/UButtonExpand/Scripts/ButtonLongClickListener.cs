/*
 * MIT License
 * 
 * Copyright (c) 2017 lujun
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

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