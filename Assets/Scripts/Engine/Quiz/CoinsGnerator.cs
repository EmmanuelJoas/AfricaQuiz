//Name space to use the function of the collection systeme 
using System.Collections;


//Name space to use the base function of unity 
using UnityEngine;


//Name space to use the UI function of unity 
using UnityEngine.UI;

public class CoinsGnerator : MonoBehaviour//Class use to generate the coins 
{
    #region Variables 


    /// <summary>
    /// Reference to the current score text 
    /// </summary>
    public Text CurrentScoreText;


    /// <summary>
    /// Reference to the current score 
    /// </summary>
    private int CurrentScore;


    /// <summary>
    /// Reference to the game object to generate 
    /// </summary>
    public GameObject CoinsSysteme;


    /// <summary>
    /// Reference to the game object end game option 
    /// </summary>
    public GameObject EndGameOption;


    #endregion

    #region Unity function 


    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        CurrentScore = int.Parse(CurrentScoreText.text);
    }


    /// <summary>
    ///  Start is called before the first frame update
    /// </summary>
    void Start()
    {
       StartCoroutine(Generator());
    }


    #endregion

    #region My Private function 


   /// <summary>
   /// Reference to the courotine who called for generate the game object 
   /// </summary>
   /// <returns></returns>
    IEnumerator Generator()
    {
        while (CurrentScore > 0)
        {
            Instantiate(CoinsSysteme,new Vector3(transform.position.x,transform.position.y,-10),transform.rotation,gameObject.transform);
            CurrentScore--;
            yield return new WaitForSeconds(0.5f); 
        }
        EndGameOption.SetActive(true);
    }


    #endregion
}
