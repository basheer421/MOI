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
	public void	traffic_service_view()
	{
		StartCoroutine("camera_transitions");
	}

	IEnumerator	camera_transitions()
	{
		menu.enabled = false;
		yield return new WaitForSeconds(1.5f);
		door_anim.SetBool("open", true);
		yield return new WaitForSeconds(1.1f);
		door_view.enabled = false;
		yield return new WaitForSeconds(1.2f);
		through_door.enabled = false;
	}
}
