using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
public class Lerp : MonoBehaviour
{
	#region Init
	//visible
		[Header("Main Options")] [Space(-5)]
			[SerializeField] bool ShowMain = false;
			[ShowIf("ShowMain")] public bool USEFULLY = false;
			[ShowIf("ShowMain")] [SerializeField] KeyCode Button;
			[ShowIf("ShowMain")] [SerializeField] float resistance, increment;
			[ShowIf("ShowMain")] [SerializeField] Transform start, end;
		
		[Header("Destroer Settings")] [Space(-5)]
			[SerializeField] bool RemoveAtEnd = false;

		[Header("Door Settings")] [Space(-5)]
			[SerializeField] bool UseDoor = false;
			[ShowIf("UseDoor")] [SerializeField] DoorController door;
		
		[Header("Dialog Settings")] [Space(-5)]
			[SerializeField] bool UseDialog = false;
			[ShowIf("UseDialog")] [SerializeField] DialogScript dialog;
	//private
		private float t = 0;
	//button
	#endregion
	private void Start() 
	{
		this.gameObject.transform.position = start.position;
	}
	private void Update()
	{
		if (USEFULLY)
		{
			if (Input.GetKeyUp(Button)) { t = Mathf.Clamp01(t + increment); }
			else { t = Mathf.Clamp01( t - (resistance * Time.fixedDeltaTime)); }
			Vector3 point = Vector3.Lerp(start.position, end.position, t);
			this.gameObject.transform.position = point;
			
			if (t == 1)
			{
				this.gameObject.transform.position = end.position;
				if (UseDoor) { door.USEFULLY = true; }
				if (UseDialog) { dialog.USEFULLY = true; }
				if (RemoveAtEnd) { Destroy(this); }
			}
		}
		
	}
}
