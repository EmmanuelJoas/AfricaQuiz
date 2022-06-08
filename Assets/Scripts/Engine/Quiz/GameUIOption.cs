//Name space to use the unity base function 
using UnityEngine;


//Name space to use the unity scene manager  function 
using UnityEngine.SceneManagement;

public class GameUIOption : MonoBehaviour//Classe use to the button of the game ui 
{
    #region My Private function


    /// <summary>
    /// Reference to the function who called for go to the subject scene 
    /// </summary>
    public void GoSceneSubject()
    {
        SceneManager.LoadScene("GameModeAndSubject");
    }


    #endregion
}
