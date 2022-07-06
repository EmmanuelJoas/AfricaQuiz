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
    /// 
    /// </summary>
    public string GameMode;

    /// <summary>
    /// Reference to the index of the subject 
    /// </summary>
    public int IndexSubjectScore;

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
        GetScoreGeo();

        GetScoreStory();

        GetScoreAnimals();

        GetScoreSport();

        GetScoreMytho();

    }

    #endregion

    #region My Private Function 


    /// <summary>
    /// Reference to the function who called for display the akward
    /// </summary>
    void DisplayAward()
    {

      if ( MaxScore >= 5 && MaxScore <=10)
      {
        Akwards[2].SetActive(true);
      }

       else if (MaxScore >= 10 && MaxScore <= 15)
       {
          Akwards[1].SetActive(true);
       }

      else if (MaxScore >= 15)
      {
         Akwards[0].SetActive(true);
      }

        TextScore.text = MaxScore + "";
    }

    /// <summary>
    /// Reference to the function who called for get the score 
    /// </summary>
    void GetScoreGeo()
    {
        if (IndexSubjectScore == 0 && GameMode == "None")
        {
            MaxScore = PlayerPrefs.GetInt("GeoHightScore");
        }

        DisplayAward();
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreStory()
    {
        if (IndexSubjectScore == 1 && GameMode == "None")
        {
            MaxScore = PlayerPrefs.GetInt("StoryHightScore");
        }

        DisplayAward();
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreAnimals()
    {
        if (IndexSubjectScore == 2 && GameMode == "None")
        {
            MaxScore = PlayerPrefs.GetInt("AnimalsHightScore");
        }

        DisplayAward();
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreSport()
    {
        if (IndexSubjectScore == 3 && GameMode == "None")
        {
            MaxScore = PlayerPrefs.GetInt("SportHightScore");
        }

        DisplayAward();
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreMytho()
    {
        if (IndexSubjectScore == 4 && GameMode == "None")
        {
            MaxScore = PlayerPrefs.GetInt("MythoHightScore");
        }

        DisplayAward();
    }


    #endregion
}
