//Name space to use the unity base function 
using UnityEngine;


//Name space to use the unity scene manager function 
using UnityEngine.SceneManagement;

public class MainMenuOptions : MonoBehaviour//class use to the action of th button of the game start scene  
{
    #region My Private Function


    /// <summary>
    /// Reference to the function who called for start the game and go to the Game Mode And Subject
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("GameModeAndSubject");
    }


    /// <summary>
    /// Reference to the function who called for go to the prize scene 
    /// </summary>
    public void PrizeGame()
    {
        SceneManager.LoadScene("Prize");
    }


    /// <summary>
    /// Reference to the function who called for close the application 
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }


    #endregion
}
