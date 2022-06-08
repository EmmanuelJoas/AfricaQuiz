//Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity UI function 
using UnityEngine.UI;

public class UnblockedAnimals : MonoBehaviour//Class use to undeblocked the subject animaux 
{

    #region Variables 


    /// <summary>
    /// Reference to the text quantity buy of upgrade 
    /// </summary>
    public Text Prix;


    /// <summary>
    /// Reference to the coins 
    /// </summary>
    private int Coins;


    /// <summary>
    /// Reference to the coins text
    /// </summary>
    public Text CoinsText;


    /// <summary>
    /// Reference to the locked panel 
    /// </summary>
    public GameObject LockedPanel;


    /// <summary>
    /// Reference if the subject is unblocked
    /// </summary>
    public int isUnblocked;


    #endregion



    #region Unity function 


    /// <summary>
    /// Reference to the function who called to the start game 
    /// </summary>
    private void Start()
    {
        Coins = PlayerPrefs.GetInt("QuizCoins");
        isUnblocked = PlayerPrefs.GetInt("UnblockedAni");
        if (isUnblocked == 1)
        {
            LockedPanel.SetActive(false);
        }
    }



    #endregion



    #region My Private Function 


    /// <summary>
    /// Reference to the function who called for the action of the button buy
    /// </summary>
    public void ButtonBuy()
    {
        Coins = PlayerPrefs.GetInt("QuizCoins");
        if (Coins > int.Parse(Prix.text) && (Coins - int.Parse(Prix.text)) > 0)
        {
            Buy();
            SaveBuy();
        }
    }


    /// <summary>
    /// Reference to the function who called for the buy action 
    /// </summary>
    private void Buy()
    {
        Coins -= int.Parse(Prix.text);
        LockedPanel.SetActive(false);
        CoinsText.text = Coins + "";
        isUnblocked = 1;
    }


    /// <summary>
    /// Reference to the function who called for save the buy action 
    /// </summary>
    private void SaveBuy()
    {
        PlayerPrefs.SetInt("QuizCoins", Coins);
        PlayerPrefs.SetInt("UnblockedAni", isUnblocked);
    }


    #endregion
}
