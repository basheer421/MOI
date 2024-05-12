using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
	// public Text uiText;
	public List<user_info> info;
	public int user;

	public void sign_in()
	{
		int rand = Random.Range(0, 2);
		user = rand;
		Debug.Log("the user selected is " + info[user]);
		//switch 
	}
	public void undeveloped_services()
	{
		Debug.Log("Coming Soon!");
	}

	public void vehicle_services()
	{
		//camera switch
	}

}
