using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UButtonExpand;
using UnityEngine.UI;
using System.Text;

public class Demo : MonoBehaviour {

	public PositionTransformer mPositionTransformer;

	public Text mLogText;

	private StringBuilder mLogStringBuilder;

	// Use this for initialization
	void Start () {
		mLogStringBuilder = new StringBuilder ();
		mPositionTransformer.init (5, PositionTransformer.TRANSFORM_DIRECTION.X_AXIS);
	}

	public void onClick(){
		mLogStringBuilder.Append ("Demo -- onClick() -- Button click\n");
		log ();
	}

	public void onLongClick(){
		mLogStringBuilder.Append ("Demo -- onLongClick() -- Button long click\n");
		log ();
	}

	public void onEventTriggerButtonClick(){
		mLogStringBuilder.Append ("Demo -- onEventTriggerButtonClick() -- EventTrigger Button click\n");
		log ();
	}

	private void log(){
		mLogText.text = mLogStringBuilder.ToString ();
	}
}
