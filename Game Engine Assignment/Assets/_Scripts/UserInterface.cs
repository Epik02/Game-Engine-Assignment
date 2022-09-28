using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public ScoreManager sc;
    public Text plzwork;
    string scoreString;

    // Update is called once per frame
    void Update()
    {
        scoreString = sc.score.ToString();
        plzwork.text = "Coins Collected: " + scoreString;
    }
}
