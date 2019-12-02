using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lerp : MonoBehaviour
{
	#region Init
	[SerializeField] KeyCode Button;
	[SerializeField] float resistance, increment;
	[SerializeField] Transform start, end;
	public bool USEFULLY = false;
	[SerializeField] bool RemoveAtEnd = false;
	[SerializeField] bool UseDoor = false;
	[SerializeField] DoorController door;
	[SerializeField] bool UseDialog = false;
	[SerializeField] DialogScript dialog;
	private float t = 0;
	#endregion
	private void Start() 
	{
		this.gameObject.transform.position = start.position;
	}
	private void Update()
	{
		if (USEFULLY == true)
		{
			if (Input.GetKeyUp(Button)) { t = Mathf.Clamp01(t + increment); }
			else { t = Mathf.Clamp01( t - (resistance * Time.fixedDeltaTime)); }
			Vector3 point = Vector3.Lerp(start.position, end.position, t);
			this.gameObject.transform.position = point;
			
			if (t == 1)
			{
				this.gameObject.transform.position = end.position;
				if (UseDoor == true) { door.USEFULLY = true; }
				if (UseDialog == true) { dialog.USEFULLY = true; }
				if (RemoveAtEnd == true) { Destroy(this); }
			}
		}
		
	}
}
