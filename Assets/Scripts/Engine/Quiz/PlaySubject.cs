//Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity function scene manager 
using UnityEngine.SceneManagement;

//Name space to the systeme collection functions 
using System.Collections;

public class PlaySubject : MonoBehaviour//Class use to play 
{
    #region Variables 


    /// <summary>
    /// Reference to the index of subject
    /// </summary>
    public int SubjectIndex;


    /// <summary>
    /// Reference to the mode game panel 
    /// </summary>
    public GameObject ModeGamePanel;


    /// <summary>
    /// Reference to the name of mode game 
    /// </summary>
    public string GameMode;


    /// <summary>
    /// Reference to the Animator of the fade systeme 
    /// </summary>
    public Animator Animator;


    /// <summary>
    /// Reference is the fade systeme is active 
    /// </summary>
    public bool inFade;


    /// <summary>
    /// Reference to the fade systeme 
    /// </summary>
    public GameObject FadeSysteme;


    #endregion


    #region UNity function 


    /// <summary>
    /// Reference to the function who called for the start game 
    /// </summary>
    public void StartTest()
    {
        ModeGamePanel.SetActive(true);
    }


    #endregion



    #region My Private Function 


    /// <summary>
    /// Reference to the mode game function 
    /// </summary>
    public void EasyGameMode()
    {
        FadeSysteme.SetActive(true);
        inFade = true;
        PlayerPrefs.SetInt("SubjectIndex", SubjectIndex);
        PlayerPrefs.SetString("GameMode", GameMode);
        StartCoroutine(StartQuizGame());
    }


    /// <summary>
    /// Reference to the mode game function 
    /// </summary>
    public void HardGameMode()
    {
        FadeSysteme.SetActive(true);
        inFade = true;
        PlayerPrefs.SetInt("SubjectIndex", SubjectIndex);
        PlayerPrefs.SetString("GameMode", GameMode);
        StartCoroutine(StartQuizGame());
    }


    /// <summary>
    /// Reference to the mode game function 
    /// </summary>
    public void ExtremeGameMode()
    {
        FadeSysteme.SetActive(true);
        inFade = true;
        PlayerPrefs.SetInt("SubjectIndex", SubjectIndex);
        PlayerPrefs.SetString("GameMode", GameMode);
        StartCoroutine(StartQuizGame());
    }


    /// <summary>
    /// Reference to the mode game function 
    /// </summary>
    public void RandomGameMode()
    {
        FadeSysteme.SetActive(true);
        inFade = true;
        PlayerPrefs.SetString("GameMode", GameMode);
        StartCoroutine(StartQuizGame());
    }


    /// <summary>
    /// Rference to the courotine why start the game 
    /// </summary>
    /// <returns></returns>
    IEnumerator StartQuizGame()
    {
        Animator.SetBool("InFade", inFade);
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("Quiz");
    }


    #endregion
}
