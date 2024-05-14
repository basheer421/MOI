using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
	public List<user_info> info;
	public int user;

	[Header("Images")]
	public	List<Sprite>	license;
	public	List<Sprite>	registration;
	[Header("Camera Manager")]
	public camera_manager camera;
	[Header("Canvases")]
	public GameObject SignInCanvas;
	public GameObject FakeLoadScreen;
	public GameObject HomeCanvas;
	public GameObject ProfileCanvas;
	public GameObject ServicesCanvas;
	public GameObject SocialCanvas;
	public GameObject TrafficServicesCanvas;
	public GameObject NavBar;
	private int imageIndex = 0;
	int	license_idx = 0;
	int	registration_idx = 0;
	private string[] post_links = new string[] {
		"https://www.instagram.com/uaemgov/p/C61LXNwMX5w/?img_index=2",
		"https://www.instagram.com/uaemgov/p/C66VieDt7dW/?img_index=1"
		};

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
		TrafficServicesCanvas.GetComponent<Canvas>().enabled = false;
	}

	public void navigate_home()
	{
		render_main_view();
		all_false();
		HomeCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void navigate_profile()
	{
		render_main_view();
		all_false();
		Canvas canvas = ProfileCanvas.GetComponent<Canvas>();
		canvas.enabled = true;
		canvas.transform.Find("profile_image").GetComponent<Image>().sprite = info[user].propic;
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
		render_main_view();
		all_false();
		ServicesCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void navigate_social()
	{		
		render_main_view();
		all_false();
		SocialCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void sign_out()
	{
		render_main_view();
		HomeCanvas.GetComponent<Canvas>().enabled = false;
		ProfileCanvas.GetComponent<Canvas>().enabled = false;
		ServicesCanvas.GetComponent<Canvas>().enabled = false;
		TrafficServicesCanvas.GetComponent<Canvas>().enabled = false;
		SocialCanvas.GetComponent<Canvas>().enabled = false;
		NavBar.GetComponent<Canvas>().enabled = false;
		SignInCanvas.GetComponent<Canvas>().enabled = true;
		SignInCanvas.transform.GetChild(2).gameObject.SetActive(true);
	}

	public void Social_next_image()
	{
		imageIndex = imageIndex == 0 ? 1 : 0; // Change if more images are added

		string imageName = "post#" + imageIndex;
		Image imageToLoad = SocialCanvas.transform.Find(imageName).GetComponent<Image>();
		SocialCanvas.transform.Find("MainPost").GetComponent<Image>().sprite = imageToLoad.sprite;
	}

	public void Social_previous_image()
	{
		imageIndex = imageIndex == 0 ? 1 : 0; // Change if more images are added

		string imageName = "post#" + imageIndex;
		Image imageToLoad = SocialCanvas.transform.Find(imageName).GetComponent<Image>();
		SocialCanvas.transform.Find("MainPost").GetComponent<Image>().sprite = imageToLoad.sprite;
	}

	public void Social_open_post()
	{
		Application.OpenURL(post_links[imageIndex]);
	}

	public void undeveloped_services()
	{
		Debug.Log("Coming Soon!");
	}

	public void traffic_services_start()
	{
		StartCoroutine("traffic_services_start_IE");
	}

	IEnumerator traffic_services_start_IE()
	{
		all_false();
		NavBar.GetComponent<Canvas>().enabled = false;
		camera.StartCoroutine("into_garage");
		//camera.traffic_service_view();
		yield return new WaitForSeconds(2.7f);
		TrafficServicesCanvas.GetComponent<Canvas>().enabled = true;
		NavBar.GetComponent<Canvas>().enabled = true;
	}

	public void	from_traffic_to_all_services()
	{
		StartCoroutine("from_traffic_to_all_services_IE");
	}
	IEnumerator from_traffic_to_all_services_IE()
	{
		all_false();
		camera.StartCoroutine("outof_garage");
		yield return new WaitForSeconds(2.7f);
		ServicesCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void vehicle_services()
	{
		//camera switch
	}

	void	render_main_view()
	{
		camera.menu.enabled = true;
		camera.door_view.enabled = true;
		camera.through_door.enabled = true;
		camera.door_anim.SetBool("open", false);
	}

	public	void	flip_license()
	{
		if (license_idx == 0)
		{
			license_idx ++;
			ProfileCanvas.transform.GetChild(15).transform.GetChild(0).GetComponent<Image>().sprite = license[license_idx];
			ProfileCanvas.transform.GetChild(15).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
		}
		else
		{
			license_idx --;
			ProfileCanvas.transform.GetChild(15).transform.GetChild(0).GetComponent<Image>().sprite = license[license_idx];
			ProfileCanvas.transform.GetChild(15).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
			ProfileCanvas.transform.GetChild(15).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = info[user].propic;
		}
	}

	public void	flip_registration()
	{
		if (registration_idx == 0)
		{
			registration_idx ++;
			ProfileCanvas.transform.GetChild(15).transform.GetChild(1).GetComponent<Image>().sprite = registration[registration_idx];
		}
		else
		{
			registration_idx --;
			ProfileCanvas.transform.GetChild(15).transform.GetChild(1).GetComponent<Image>().sprite = registration[registration_idx];
		}
	}
	public void open_digital_cards()
	{
		ProfileCanvas.transform.GetChild(15).gameObject.SetActive(true);
		NavBar.GetComponent<Canvas>().enabled = false;
	}
	public void	back_to_personal_info()
	{
		ProfileCanvas.transform.GetChild(15).gameObject.SetActive(false);
		NavBar.GetComponent<Canvas>().enabled = true;
	}
	

}