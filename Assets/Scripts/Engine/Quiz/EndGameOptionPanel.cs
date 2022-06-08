//name space to use the unity base function 
using UnityEngine;

//Name space to use the unity scene manager function 
using UnityEngine.SceneManagement;

public class EndGameOptionPanel : MonoBehaviour//Class use to the option of the end game panel 
{
    #region My Private function 


    /// <summary>
    /// Reference to the function who called for reload the scene 
    /// </summary>
    public void RestartQuiz()
    {
        SceneManager.LoadScene("Quiz");
    }


    /// <summary>
    /// Reference to the function who called for go to the mode game 
    /// </summary>
    public void PrizeQuiz()
    {
        SceneManager.LoadScene("Prize");//Create the prize scene 
    }


    /// <summary>
    /// Reference to the function who called to go MainMenu game 
    /// </summary>
    public void MainMenuQuiz()
    {
        SceneManager.LoadScene("GameModeAndSubject");
    }


    #endregion
}
