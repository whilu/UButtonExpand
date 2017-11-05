using UnityEngine.EventSystems;

namespace UButtonExpand{
	
	public abstract class ButtonEventTrigger : EventTrigger
	{

		public override void OnPointerDown(PointerEventData eventData){
			base.OnPointerDown (eventData);
			//
		}

		public override void OnPointerUp(PointerEventData eventData){
			base.OnPointerUp (eventData);
			//
		}

		public override void OnPointerExit(PointerEventData eventData){
			base.OnPointerExit (eventData);
			//
		}

		public override void OnPointerEnter(PointerEventData eventData){
			base.OnPointerEnter (eventData);
			//
		}

		public override void OnBeginDrag (PointerEventData eventData){
			base.OnBeginDrag (eventData);
			//
		}

		public override void OnDrag (PointerEventData eventData){
			base.OnDrag (eventData);
			//
		}

		public override void OnEndDrag (PointerEventData eventData){
			base.OnEndDrag(eventData);
			//
		}

		public override void OnInitializePotentialDrag (PointerEventData eventData){
			base.OnInitializePotentialDrag (eventData);
			//
		}

		public override void OnScroll (PointerEventData eventData){
			base.OnScroll (eventData);
			//
		}

	}
}
