using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camera_manager : MonoBehaviour
{
	public Animator door_anim;
    public  CinemachineVirtualCamera menu;
	public  CinemachineVirtualCamera door_view;
	public  CinemachineVirtualCamera through_door;
	public  CinemachineVirtualCamera inside_garage;

	IEnumerator	into_garage()
	{
		menu.enabled = false;
		yield return new WaitForSeconds(1f);
		door_anim.SetBool("open", true);
		yield return new WaitForSeconds(.35f);
		door_view.enabled = false;
		yield return new WaitForSeconds(0.6f);
		through_door.enabled = false;
	}

	IEnumerator	outof_garage()
	{
		Debug.Log("called coroutine");
		through_door.enabled = true;
		yield return new WaitForSeconds(.7f);
		door_view.enabled = true;
		yield return new WaitForSeconds(.7f);
		door_anim.SetBool("open", false);
		yield return new WaitForSeconds(.4f);
		menu.enabled = true;
	}

}
