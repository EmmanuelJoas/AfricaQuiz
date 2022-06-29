//Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity base function 
using UnityEngine.UI;

/// <summary>
/// Classe for gestion of the score 
/// </summary>
public class ScoreQuiz : MonoBehaviour
{
    #region Variables 

    /// <summary>
    /// Reference to the quiz manager 
    /// </summary>
    public string GameMode;

    /// <summary>
    /// Reference to the index of the subject 
    /// </summary>
    public int IndexSubject;

    /// <summary>
    /// Reference to the max score of the player 
    /// </summary>
    private int MaxScore;

    /// <summary>
    /// Reference to the graphique score 
    /// </summary>
    public GameObject[] Akwards;

    /// <summary>
    /// Reference to the text score who display the score of the player 
    /// </summary>
    public Text TextScore;

    #endregion

    #region Unity Function 

    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        if (IndexSubject == 0)
        {
            MaxScore = PlayerPrefs.GetInt("GeoHightScore");
        }
        else if (IndexSubject == 1)
        {
            MaxScore = PlayerPrefs.GetInt("StoryHightScore");
        }
        else if (IndexSubject == 2)
        {
            MaxScore = PlayerPrefs.GetInt("AnimalsHightScore");
        }
        else if (IndexSubject == 3)
        {
            MaxScore = PlayerPrefs.GetInt("SportHightScore");
        }
        else if (IndexSubject == 4)
        {
            MaxScore = PlayerPrefs.GetInt("MythoHightScore");
        }
        else if (GameMode == "Randome")
        {
            MaxScore = PlayerPrefs.GetInt("RandomeHightScore");
        }
        Debug.Log(IndexSubject);
    }

    #endregion

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        DisplayAward();
    }


    #region My Private Function 


    /// <summary>
    /// Reference to the function who called for display the akward
    /// </summary>
    void DisplayAward()
    {

      if (MaxScore > 0 && MaxScore <= 5)
      {
        Akwards[2].SetActive(true);
      }

       else if (MaxScore > 5 && MaxScore <= 10)
       {
          Akwards[1].SetActive(true);
       }

      else if (MaxScore >= 15)
      {
         Akwards[0].SetActive(true);
      }

        TextScore.text = MaxScore + "";
    }

    #endregion
}
