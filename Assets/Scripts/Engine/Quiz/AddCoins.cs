//Name space t use the unity UI function 
using UnityEngine.UI;

// Name space to use the unity base functio 
using UnityEngine;

public class AddCoins : MonoBehaviour//Class use to the coins systeme 
{
    #region Variables 


    /// <summary>
    /// Reference to the text who display the coins count 
    /// </summary>
    private GameObject Text;


    /// <summary>
    /// Reference to the coins count pickup
    /// </summary>
    public int CoinsCount;


    /// <summary>
    /// Reference to the coins count pickup
    /// </summary>
    public int CoinsCountSave;



    #endregion



    #region Unity Function 


    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        Text = GameObject.FindGameObjectWithTag("TextCount");
       
    }


    /// <summary>
    /// Reference to the function who called when the game object collides is the player 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))//check is the collides is the player 
        {
            Add();
            SaveData();
        }

    }


    #endregion



    #region My private region 


    /// <summary>
    /// Reference to the function who called to add the coins 
    /// </summary>
    public void Add()
    {
        CoinsCount = int.Parse(Text.GetComponent<Text>().text) + 1;//Add increments the coin account 
        Text.GetComponent<Text>().text = CoinsCount + " ";//Display of the variable 
    }


    /// <summary>
    /// Reference to the function who called to save the coins account 
    /// </summary>
    public void SaveData()
    {
        PlayerPrefs.SetInt("QuizCoins", CoinsCountSave + int.Parse(Text.GetComponent<Text>().text));//Save the coins account
    }


    #endregion
}
