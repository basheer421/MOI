using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
	[Header("user controller")]
	public user_controller u_ctr;
	public List<user_info> info;
	public int user;
	[Header("car manager")]
	public Car_Mngr car_mgr;

	[Header("Images")]
	public List<Sprite> license;
	public List<Sprite> registration;
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
	public GameObject PopupCanvas;
	public GameObject ColorChangeCanvas;
	public GameObject StoreCanvas;

	[Header("Voice Manager")]
	public VoiceManager voiceManager;
	private int imageIndex = 0;
	int license_idx = 0;
	int registration_idx = 0;
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
		car_mgr.enable_car(user);
		car_mgr.set_original_color(user);
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
		PopupCanvas.GetComponent<Canvas>().enabled = false;
		ColorChangeCanvas.GetComponent<Canvas>().enabled = false;
		StoreCanvas.GetComponent<Canvas>().enabled = false;
	}

	public void navigate_home()
	{
		render_main_view();
		all_false();
		HomeCanvas.GetComponent<Canvas>().enabled = true;
		HomeCanvas.transform.Find("uid1").GetComponent<TextMeshProUGUI>().text = info[user].uid;
		HomeCanvas.transform.Find("profile_image").GetComponent<Image>().sprite = info[user].propic;
		HomeCanvas.transform.Find("user_name").GetComponent<TextMeshProUGUI>().text = info[user].user_name;
		HomeCanvas.transform.Find("Points").GetComponent<TextMeshProUGUI>().text = info[user].score.ToString();
		HomeCanvas.transform.Find("Fines").GetComponent<TextMeshProUGUI>().text = user == 0 ? "500" : "0";
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
		if (SocialCanvas.GetComponent<Canvas>().enabled == false)
			return;
		imageIndex = imageIndex == 0 ? 1 : 0; // Change if more images are added

		string imageName = "post#" + imageIndex;
		Image imageToLoad = SocialCanvas.transform.Find(imageName).GetComponent<Image>();
		SocialCanvas.transform.Find("MainPost").GetComponent<Image>().sprite = imageToLoad.sprite;
	}

	public void Social_previous_image()
	{
		if (SocialCanvas.GetComponent<Canvas>().enabled == false)
			return;
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
		if (PopupCanvas.GetComponent<Canvas>().enabled == false)
			TrafficServicesCanvas.GetComponent<Canvas>().enabled = true;
		NavBar.GetComponent<Canvas>().enabled = true;
	}

	public void from_traffic_to_all_services()
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

	void render_main_view()
	{
		camera.menu.enabled = true;
		camera.door_view.enabled = true;
		camera.through_door.enabled = true;
		camera.door_anim.SetBool("open", false);
	}

	public void flip_license()
	{
		if (license_idx == 0)
		{
			license_idx++;
			ProfileCanvas.transform.GetChild(16).transform.GetChild(0).GetComponent<Image>().sprite = license[license_idx];
			ProfileCanvas.transform.GetChild(16).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = false;
		}
		else
		{
			license_idx--;
			ProfileCanvas.transform.GetChild(16).transform.GetChild(0).GetComponent<Image>().sprite = license[license_idx];
			ProfileCanvas.transform.GetChild(16).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().enabled = true;
			ProfileCanvas.transform.GetChild(16).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = info[user].propic;
		}
	}

	public void flip_registration()
	{
		if (registration_idx == 0)
		{
			registration_idx++;
			ProfileCanvas.transform.GetChild(16).transform.GetChild(1).GetComponent<Image>().sprite = registration[registration_idx];
		}
		else
		{
			registration_idx--;
			ProfileCanvas.transform.GetChild(16).transform.GetChild(1).GetComponent<Image>().sprite = registration[registration_idx];
		}
	}
	public void open_digital_cards()
	{
		ProfileCanvas.transform.GetChild(16).gameObject.SetActive(true);
		NavBar.GetComponent<Canvas>().enabled = false;
	}
	public void back_to_personal_info()
	{
		ProfileCanvas.transform.GetChild(16).gameObject.SetActive(false);
		NavBar.GetComponent<Canvas>().enabled = true;
	}

	public void Traffic_open_popup()
	{
		TrafficServicesCanvas.GetComponent<Canvas>().enabled = false;
		PopupCanvas.GetComponent<Canvas>().enabled = true;
		if (user == 0)
		{
			PopupCanvas.transform.Find("finebox").gameObject.SetActive(true);
			PopupCanvas.transform.Find("nofinebox").gameObject.SetActive(false);
		}
		else
		{
			PopupCanvas.transform.Find("finebox").gameObject.SetActive(false);
			PopupCanvas.transform.Find("nofinebox").gameObject.SetActive(true);
		}
	}

	public void Traffic_close_popup()
	{
		TrafficServicesCanvas.GetComponent<Canvas>().enabled = true;
		PopupCanvas.GetComponent<Canvas>().enabled = false;
	}

	private void handleMessage(string message)
	{
		message = message.ToLower();
		if (message.Contains("home"))
		{
			navigate_home();
		}
		else if (message.Contains("profile"))
		{
			navigate_profile();
		}
		else if (message == "services")
		{
			navigate_services();
		}
		else if (message.Contains("social"))
		{
			navigate_social();
		}
		else if (message.Contains("sign out"))
		{
			sign_out();
		}
		else if (message.Contains("next"))
		{
			Social_next_image();
		}
		else if (message.Contains("previous"))
		{
			Social_previous_image();
		}
		else if (message.Contains("open post"))
		{
			Social_open_post();
		}
		else if (message.Contains("traffic services"))
		{
			traffic_services_start();
		}
		else if (message.Contains("back"))
		{
			from_traffic_to_all_services();
		}
		else if (message.Contains("license"))
		{
			flip_license();
		}
		else if (message.Contains("registration"))
		{
			flip_registration();
		}
		else if (message.Contains("flip"))
		{
			flip_license();
			flip_registration();
		}
		else if (message.Contains("digital cards"))
		{
			open_digital_cards();
		}
		else if (message.Contains("personal info"))
		{
			back_to_personal_info();
		}
		else if (message.Contains("traffic fines"))
		{
			traffic_services_start();
			Traffic_open_popup();
		}
		else if (message.Contains("close popup"))
		{
			Traffic_close_popup();
		}
		else if (message.Contains("points"))
		{
			navigate_store();
		}
	}

	public void Voice_take_order()
	{
		voiceManager.Ask();
		StartCoroutine("Voice_take_order_IE");
	}

	IEnumerator Voice_take_order_IE()
	{
		while (voiceManager.IsListening())
			yield return new WaitForSeconds(0.5f);
		handleMessage(voiceManager.GetMessage());
	}


	#region Color Change
	public void open_change_color()
	{
		all_false();
		NavBar.GetComponent<Canvas>().enabled = false;
		ColorChangeCanvas.GetComponent<Canvas>().enabled = true;
	}
	public void change_to_black()
	{
		car_mgr.to_black(user);
	}
	public void change_to_grey()
	{
		car_mgr.to_grey(user);
	}
	public void change_to_white()
	{
		car_mgr.to_white(user);
	}
	public void change_to_red()
	{
		car_mgr.to_red(user);
	}
	public void on_submit()
	{
		if (user == 0)
		{
			Debug.Log("show inspect popup");
			car_mgr.reset_color(user);
			ColorChangeCanvas.transform.GetChild(1).gameObject.SetActive(true);
			ColorChangeCanvas.transform.GetChild(2).gameObject.SetActive(false);
		}
		else
		{
			Debug.Log("show ok popup");
			ColorChangeCanvas.transform.GetChild(1).gameObject.SetActive(false);
			ColorChangeCanvas.transform.GetChild(2).gameObject.SetActive(true);
			//add score for user
			u_ctr.add_score(info[user], 300);
			//Debug.Log("the user score now is: " + info[user].score);
		}
		//back_to_traffic();
	}

	public void back_to_traffic()
	{
		ColorChangeCanvas.transform.GetChild(1).gameObject.SetActive(false);
		ColorChangeCanvas.transform.GetChild(2).gameObject.SetActive(false);
		ColorChangeCanvas.GetComponent<Canvas>().enabled = false;
		NavBar.GetComponent<Canvas>().enabled = true;
		TrafficServicesCanvas.GetComponent<Canvas>().enabled = true;
	}
	#endregion

	public void Home_pay_fines()
	{
		traffic_services_start();
		Traffic_open_popup();
	}

	public void navigate_store()
	{
		all_false();
		StoreCanvas.GetComponent<Canvas>().enabled = true;
		StoreCanvas.transform.Find("Points").GetComponent<TextMeshProUGUI>().text = info[user].score.ToString();
	}
	public void Start()
	{
		HomeCanvas.transform.Find("uid1").GetComponent<TextMeshProUGUI>().text = info[user].uid;
		HomeCanvas.transform.Find("profile_image").GetComponent<Image>().sprite = info[user].propic;
		HomeCanvas.transform.Find("user_name").GetComponent<TextMeshProUGUI>().text = info[user].user_name;
		HomeCanvas.transform.Find("Points").GetComponent<TextMeshProUGUI>().text = info[user].score.ToString();
		HomeCanvas.transform.Find("Fines").GetComponent<TextMeshProUGUI>().text = user == 0 ? "500" : "0";

	}
}
