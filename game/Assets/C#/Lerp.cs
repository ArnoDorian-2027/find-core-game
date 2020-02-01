using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Lerp : MonoBehaviour
{
	#region Init
	//visible
		[BoxGroup("Main Settings")] [SerializeField] bool ShowMain = false;
		[BoxGroup("Main Settings")] [ShowIf("ShowMain")] public bool USEFULLY = false;
		[BoxGroup("Main Settings")] [ShowIf("ShowMain")] [SerializeField] KeyCode Button;
		[BoxGroup("Main Settings")] [ShowIf("ShowMain")] [SerializeField] float resistance, increment;
		[BoxGroup("Main Settings")] [ShowIf("ShowMain")] [SerializeField] Transform start, end;
		
		[BoxGroup("Remover Settings")] [SerializeField] bool RemoveAtEnd = false;

		[BoxGroup("Door Settings")] [SerializeField] bool UseDoor = false;
		[BoxGroup("Door Settings")] [ShowIf("UseDoor")] [SerializeField] DoorController door;
		
		[BoxGroup("Dialog Settings")] [SerializeField] bool UseDialog = false;
		[BoxGroup("Dialog Settings")] [ShowIf("UseDialog")] [SerializeField] DialogScript dialog;
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
