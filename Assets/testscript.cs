using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    public void ResetDataBase()
    {
        PlayerPrefs.SetInt("GeoHightScore",0);
        PlayerPrefs.SetInt("StoryHightScore",0);
        PlayerPrefs.SetInt("AnimalsHightScore",0);
        PlayerPrefs.SetInt("SportHightScore",0);
        PlayerPrefs.SetInt("MythoHightScore",0);
        PlayerPrefs.SetInt("RandomeHightScore",0);
    }
}
