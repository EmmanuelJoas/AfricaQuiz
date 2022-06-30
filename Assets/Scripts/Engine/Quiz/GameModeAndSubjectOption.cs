//Name space to use the unity function scene manager 
using UnityEngine.SceneManagement;


//Name space to use the unity base function 
using UnityEngine;


//Name space to use the unity Ui function 
using UnityEngine.UI;

public class GameModeAndSubjectOption : MonoBehaviour//Class use to he optin the GameModeAndSubject 
{
    #region Variables 


    /// <summary>
    /// Reference to the text display the coins count 
    /// </summary>
    public Text CoinsCounText;

  
    #endregion

    #region Unity Function 

    /// <summary>
    /// Reference to the function who called befor the start function 
    /// </summary>
    private void Awake()
    {
        CoinsCounText.text = PlayerPrefs.GetInt("QuizCoins") + "";

    }

    #endregion

    #region My Private Function 

    /// <summary>
    /// Reference to the function who called for return on the game start scene 
    /// </summary>
    public void ReturnButton() 
    {
        SceneManager.LoadScene("StartGame");
    }


    /// <summary>
    /// Reference to the function who called for return on the game start scene 
    /// </summary>
    public void PrizeButton()
    {
        SceneManager.LoadScene("Prize");
    }

    /// <summary>
    /// Reference to the function who called for return on the Game Mode AndSubject
    /// </summary>
    public void MenuButton()
    {
        SceneManager.LoadScene("GameModeAndSubject");
    }
    #endregion
}
