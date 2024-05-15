using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_Mngr : MonoBehaviour
{
    public List<Material> car_matt;
    public List<GameObject> car;

    public  void enable_car(int user)
    {
        for(int i = 0; i < 2; i++)
        {
            if (i == 0)
            {
                for (int j = 0; j < 12; j++)
                {
                    car[i].transform.GetChild(j).GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
                car[i].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
        if (user == 0)
        {        
            for (int j = 0; j < 12; j++)
            {
                car[user].transform.GetChild(j).GetComponent<MeshRenderer>().enabled = true;
            }  
        }
        else
            car[user].transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
    }
    public void to_white(int user)
    {
        Color customColor = new Color(0.9f, 0.9f, 0.9f, 1.0f);
        car_matt[user].SetColor("_Color", customColor);
    }
    public void to_black(int user)
    {
        Color customColor = new Color(0.1f, 0.1f, 0.1f, 1.0f);
        car_matt[user].SetColor("_Color", customColor);
    }
    public void to_red(int user)
    {
        Color customColor = new Color(.9f, 0.2f, 0f, 1.0f);
        car_matt[user].SetColor("_Color", customColor);
    }
    public void to_grey(int user)
    {
        Color customColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        car_matt[user].SetColor("_Color", customColor);
    }
}

