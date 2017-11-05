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