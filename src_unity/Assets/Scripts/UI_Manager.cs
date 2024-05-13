using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
	public List<user_info> info;
	public int user;

	[Header("Canvases")]
	public GameObject SignInCanvas;
	public GameObject FakeLoadScreen;

	public GameObject HomeCanvas;
	public GameObject ProfileCanvas;
	public GameObject ServicesCanvas;
	public GameObject SocialCanvas;

	public GameObject NavBar;

	public void sign_in()
	{
		int rand = Random.Range(0, 2);
		user = rand;
		Debug.Log("the user selected is " + info[user]);
		StartCoroutine("SignInIEnum");
	}

	IEnumerator SignInIEnum()
	{
		SignInCanvas.transform.GetChild(2).gameObject.SetActive(false);
		SignInCanvas.GetComponent<Animator>().SetBool("Fade", true);
		yield return new WaitForSeconds(1.7f);
		SignInCanvas.GetComponent<Canvas>().enabled = false;
		FakeLoadScreen.GetComponent<Canvas>().enabled = true;
		yield return new WaitForSeconds(3f);
		FakeLoadScreen.GetComponent<Canvas>().enabled = false;
		HomeCanvas.GetComponent<Canvas>().enabled = true;
		NavBar.GetComponent<Canvas>().enabled = true;
	}

	private void all_false()
	{
		HomeCanvas.GetComponent<Canvas>().enabled = false;
		ProfileCanvas.GetComponent<Canvas>().enabled = false;
		ServicesCanvas.GetComponent<Canvas>().enabled = false;
		SocialCanvas.GetComponent<Canvas>().enabled = false;
	}

	public void navigate_home()
	{
		all_false();
		HomeCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void navigate_profile()
	{
		all_false();
		Canvas canvas = ProfileCanvas.GetComponent<Canvas>();
		canvas.enabled = true;
		canvas.GetComponentInChildren<Image>().sprite = info[user].propic;
		// canvas.GetComponentInChildren<TextMeshProUGUI>().text = info[user].user_name;
		canvas.transform.Find("user_name").GetComponent<TextMeshProUGUI>().text = info[user].user_name;
		canvas.transform.Find("uid1").GetComponent<TextMeshProUGUI>().text = info[user].uid;
		canvas.transform.Find("uid2").GetComponent<TextMeshProUGUI>().text = info[user].uid;
		canvas.transform.Find("email").GetComponent<TextMeshProUGUI>().text = info[user].email;
		canvas.transform.Find("unified_number").GetComponent<TextMeshProUGUI>().text = info[user].unified_number;
		canvas.transform.Find("traffic_no").GetComponent<TextMeshProUGUI>().text = info[user].traffic_no;
		canvas.transform.Find("phone_no").GetComponent<TextMeshProUGUI>().text = info[user].phone_no;
	}

	public void navigate_services()
	{
		all_false();
		ServicesCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void navigate_social()
	{
		all_false();
		SocialCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void sign_out()
	{
		HomeCanvas.GetComponent<Canvas>().enabled = false;
		ProfileCanvas.GetComponent<Canvas>().enabled = false;
		ServicesCanvas.GetComponent<Canvas>().enabled = false;
		SocialCanvas.GetComponent<Canvas>().enabled = false;
		NavBar.GetComponent<Canvas>().enabled = false;
		SignInCanvas.GetComponent<Canvas>().enabled = true;
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