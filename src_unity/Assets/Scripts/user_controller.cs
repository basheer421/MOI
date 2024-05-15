using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_controller : MonoBehaviour
{
    public void add_score(user_info user, int score)
    {
        user.score += score;
    }
}
