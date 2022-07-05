//Name space to use the unity base function 
using UnityEngine;


//Name space to use the unity UI function 
using UnityEngine.UI;

public class BonusPanel : MonoBehaviour
{
    #region Variables 

    /// <summary>
    /// Reference to the indice panel
    /// </summary>
    public GameObject IndicePanel;


    /// <summary>
    /// Reference to the number of indices 
    /// </summary>
    public Text IndiceText;


    /// <summary>
    /// Reference to the game mode 
    /// </summary>
    private string GameMode;


    /// <summary>
    /// Reference to the indice button
    /// </summary>
    public GameObject indiceButton;


    /// <summary>
    /// Reference to the indice button
    /// </summary>
    public GameObject fiftyFiftyButton;


    #endregion


    #region Unity Function 


    /// <summary>
    /// Reference to the function who called in the first frame 
    /// </summary>
    private void Start()
    {
        GameMode = PlayerPrefs.GetString("GameMode");
        if (GameMode == "Extreme")
        {
            indiceButton.SetActive(false);
        }
    }


    #endregion


    #region My private funtion 


    /// <summary>
    /// Reference to the function who called for display the indice panel 
    /// </summary>
    public void IndiceButton()
    {
        if (int.Parse(IndiceText.text) > 0)
        {
            IndicePanel.SetActive(true);
            IndiceText.text = (int.Parse(IndiceText.text) - 1) + "";
        }
    }


    /// <summary>
    /// Reference to the function who 
    /// called for exit the indice panel 
    /// </summary>
    public void QuitteIndicePanel()
    {
        IndicePanel.SetActive(false);
    }


    /// <summary>
    /// 
    /// </summary>
    public void FiftyFiftyButton()
    {

        QuizManager.intance.CurrentSubject.GetComponent<StartSubject>().DesableWrongAnswers();
        fiftyFiftyButton.SetActive(false);

    }


    #endregion
}
