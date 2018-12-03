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

namespace UButtonExpand{

	/// <summary>
	/// Scrollview position transformer, extend PositionTransformer, help deal event conflict in ScrollView.
	/// </summary>
	public class ScrollviewPositionTransformer : PositionTransformer {

		private ScrollRect mScrollRect;

		/// <summary>
		/// Init the specified scrollRect, offset and direction.
		/// </summary>
		/// <param name="scrollRect">Scroll rect, the ScrollRect in ScrollView.</param>
		/// <param name="offset">Offset, transform offset.</param>
		/// <param name="direction">Direction, transform direction.</param>
		public void init(ScrollRect scrollRect, int offset = 0, TRANSFORM_DIRECTION direction = TRANSFORM_DIRECTION.Y_AXIS){
			base.init(offset, direction);
			mScrollRect = scrollRect;
		}

		public override void OnBeginDrag (PointerEventData eventData){
			base.OnBeginDrag (eventData);
			if (mScrollRect != null) {
				mScrollRect.OnBeginDrag (eventData);
			}
		}

		public override void OnDrag (PointerEventData eventData){
			base.OnDrag (eventData);
			if (mScrollRect != null) {
				mScrollRect.OnDrag (eventData);
			}
		}

		public override void OnEndDrag (PointerEventData eventData){
			base.OnEndDrag(eventData);
			if (mScrollRect != null) {
				mScrollRect.OnEndDrag (eventData);
			}
		}

		public override void OnInitializePotentialDrag (PointerEventData eventData){
			base.OnInitializePotentialDrag (eventData);
			if (mScrollRect != null) {
				mScrollRect.OnInitializePotentialDrag (eventData);
			}
		}

		public override void OnScroll (PointerEventData eventData){
			base.OnScroll (eventData);
			if (mScrollRect != null) {
				mScrollRect.OnScroll (eventData);
			}
		}
	}
}