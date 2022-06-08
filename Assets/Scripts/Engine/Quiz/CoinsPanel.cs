//Name space to use the unity base function 
using UnityEngine;


//Name space to use the unity UI function 
using UnityEngine.UI;

public class CoinsPanel : MonoBehaviour//Classe use to display the coins quantity in the game 
{
    #region Variables 


    /// <summary>
    /// Referenence to the coins count save 
    /// </summary>
    public int CoinsCountSave;


    /// <summary>
    /// Rference to the text display the coins count 
    /// </summary>
    public GameObject Text;


    #endregion


    #region Unity Function 

   
   /// <summary>
   ///  Start is called before the first frame update
   /// </summary>
    void Start()
    {
        CoinsCountSave = PlayerPrefs.GetInt("QuizCoins");//retrieve the quantity of coins save
        Text.GetComponent<Text>().text = CoinsCountSave.ToString();
    }


    #endregion
}
