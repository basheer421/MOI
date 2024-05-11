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

	public Button EnableAssistantButton;
	public Button DisableAssistantButton;
	public VoiceManager Assistant;

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

	public void EnableAssistant()
	{
		Button btn = EnableAssistantButton.GetComponent<Button>();
		VoiceManager assistant = Assistant.GetComponent<VoiceManager>();
		// btn.onClick.AddListener(Assistant.StartListening);

		btn.onClick.AddListener(assistant.OnSpeakStart);

	}

	public void DisableAssistant()
	{
		Button btn = DisableAssistantButton.GetComponent<Button>();
		VoiceManager assistant = Assistant.GetComponent<VoiceManager>();
		// btn.onClick.AddListener(Assistant.StopListening);
		btn.onClick.AddListener(assistant.OnSpeakStop);
	}

}
