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
using UnityEngine.EventSystems;

namespace UButtonExpand{

	/// <summary>
	/// Position transformer.
	/// </summary>
	public class PositionTransformer : ButtonEventTrigger {

		public enum TRANSFORM_DIRECTION {
			X_AXIS,
			Y_AXIS,
			Z_AXIS
		}
		private TRANSFORM_DIRECTION mTransformDirection = TRANSFORM_DIRECTION.Y_AXIS;

		private Dictionary<Transform, Vector3> mCTransformPosDic = new Dictionary<Transform, Vector3> ();

		private int mOffset = 0;

		private bool isOriginalDown = false, isOriginalUp = true, isPointerDown = false;

		void Start(){
			for (int i = 0; i < transform.childCount; ++i) {
				Transform cTransform = transform.GetChild (i);
				mCTransformPosDic [cTransform] = cTransform.localPosition;
			}
		}

		/// <summary>
		/// Init the specified offset and direction.
		/// </summary>
		/// <param name="offset">Offset, transform offset.</param>
		/// <param name="direction">Direction, transform direction.</param>
		public void init(int offset = 0, TRANSFORM_DIRECTION direction = TRANSFORM_DIRECTION.Y_AXIS){
			mOffset = offset;
			mTransformDirection = direction;
		}

		public override void OnPointerDown(PointerEventData eventData){
			base.OnPointerDown (eventData);
			isPointerDown = true;
			down ();
		}

		public override void OnPointerUp(PointerEventData eventData){
			base.OnPointerUp (eventData);
			isPointerDown = false;
			up ();
		}

		public override void OnPointerExit(PointerEventData eventData){
			base.OnPointerExit (eventData);
			if (isPointerDown) {
				up ();
			}
		}

		public override void OnPointerEnter(PointerEventData eventData){
			base.OnPointerEnter (eventData);
			if(isPointerDown){
				down ();
			}
		}

		private void down(){
			if (isOriginalUp) {
				isOriginalDown = true;
				isOriginalUp = false;
				foreach (KeyValuePair<Transform, Vector3> kv in mCTransformPosDic) {
					kv.Key.localPosition = new Vector3 (
						mTransformDirection == TRANSFORM_DIRECTION.X_AXIS ? kv.Value.x + mOffset : kv.Value.x, 
						mTransformDirection == TRANSFORM_DIRECTION.Y_AXIS ? kv.Value.y + mOffset : kv.Value.y, 
						mTransformDirection == TRANSFORM_DIRECTION.Z_AXIS ? kv.Value.z + mOffset : kv.Value.z
					);
				}
			}
		}

		private void up(){
			if (isOriginalDown) {
				isOriginalDown = false;
				isOriginalUp = true;
				foreach (KeyValuePair<Transform, Vector3> kv in mCTransformPosDic) {
					kv.Key.localPosition = new Vector3 (
						//mTransformDirection == TRANSFORM_DIRECTION.X_AXIS ? kv.Value.x - mOffset : kv.Value.x, 
						//mTransformDirection == TRANSFORM_DIRECTION.Y_AXIS ? kv.Value.y - mOffset : kv.Value.y, 
						//mTransformDirection == TRANSFORM_DIRECTION.Z_AXIS ? kv.Value.z - mOffset : kv.Value.z
                        kv.Value.x,
                        kv.Value.y,
                        kv.Value.z
                    );
				}
			}
		}

	}
}
