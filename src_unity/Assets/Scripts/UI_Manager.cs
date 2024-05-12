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
	public GameObject SignInPage;
	public GameObject FakeLoadScreen;
	public GameObject Home;

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
		SignInPage.transform.GetChild(2).gameObject.SetActive(false);
		SignInPage.GetComponent<Animator>().SetBool("Fade", true);
		yield return new WaitForSeconds(1.7f);
		SignInPage.GetComponent<Canvas>().enabled = false;
		FakeLoadScreen.GetComponent<Canvas>().enabled = true;
		yield return new WaitForSeconds(3f);
		FakeLoadScreen.GetComponent<Canvas>().enabled = false;
		Home.GetComponent<Canvas>().enabled = true;
		// NavBarCanvas.enabled = true;
		NavBar.GetComponent<Canvas>().enabled = true;
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