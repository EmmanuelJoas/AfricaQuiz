using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetShop : MonoBehaviour
{
    public void ResetOption()
    {
        PlayerPrefs.DeleteKey("UnblockedSport");
        PlayerPrefs.DeleteKey("UnblockedMytho");
        PlayerPrefs.DeleteKey("UnblockedGeo");
        PlayerPrefs.DeleteKey("UnblockedAni");
        PlayerPrefs.DeleteKey("UnblockedStory");

        PlayerPrefs.SetInt("UnblockedSport", 0);
        PlayerPrefs.SetInt("UnblockedMytho", 0);
        PlayerPrefs.SetInt("UnblockedGeo", 0);
        PlayerPrefs.SetInt("UnblockedAni", 0);
        PlayerPrefs.SetInt("UnblockedStory", 0);

        PlayerPrefs.SetInt("QuizCoins", 100);
    }
}
