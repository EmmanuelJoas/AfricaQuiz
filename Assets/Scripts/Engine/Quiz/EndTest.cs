//Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity base function 
using UnityEngine.UI;


public class EndTest : MonoBehaviour//Class reference the action of the end game 
{
    #region Variables

    /// <summary>
    /// Reference to the game object score panel
    /// </summary>
    public GameObject ScorePanel;

    /// <summary>
    /// Reference to the game object score panel Gui
    /// </summary>
    public GameObject ScorePanelGameUI;

    /// <summary>
    /// Reference to the class generator 
    /// </summary>
    public CoinsGnerator CoinsGnerator;

    /// <summary>
    /// Reference to the text score 
    /// </summary>
    public Text TextScore;

    /// <summary>
    /// Reference to the akward 
    /// </summary>
    public GameObject[] Akward;

    /// <summary>
    /// Reference to the quiz manager 
    /// </summary>
    public string GameMode;

    /// <summary>
    /// Reference to the index of the subject 
    /// </summary>
    private int IndexSubject;

    /// <summary>
    /// Reference to the max score of the player 
    /// </summary>
    private int MaxScore;


    #endregion

    #region Unity Function 

    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        GameMode = PlayerPrefs.GetString("GameMode");

        IndexSubject = PlayerPrefs.GetInt("SubjectIndex");

        GetScoreAnimals();

        GetScoreGeo();

        GetScoreMytho();

        GetScoreSport();

        GetScoreStory();
       
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        ScorePanelGameUI.transform.position = ScorePanel.transform.position;
        DisplayAward();
    }


    #endregion

    #region My Private Function 


    /// <summary>
    /// Reference to the function who called for display the akward
    /// </summary>
    void DisplayAward()
    {

        if (GameMode == "Extreme")
        {

            if (int.Parse(TextScore.text)>=5 && int.Parse(TextScore.text) <=10)
            {
                Akward[0].SetActive(true);
            }

            else if (int.Parse(TextScore.text) >= 10 && int.Parse(TextScore.text) <= 15)
            {
                Akward[1].SetActive(true);
            }

            else if (int.Parse(TextScore.text) >= 15)
            {
                Akward[2].SetActive(true);
            }

        }

        SetScoreGeo();

        SetScoreAnimal();

        SetScoreMytho();

        SetScoreSport();

        SetScoreStory();
    }

    /// <summary>
    /// Reference to the function who called for set the score 
    /// </summary>
    void SetScoreGeo()
    {
        if (IndexSubject == 0 && GameMode == "Extreme")
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("GeoHightScore", int.Parse(TextScore.text));
            }

        }
    }

    /// <summary>
    /// Reference to the function who called for set the score 
    /// </summary>
    void SetScoreStory()
    {
        if (IndexSubject == 1 && GameMode == "Extreme")
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("StoryHightScore", int.Parse(TextScore.text));
            }
        }    
    }

    /// <summary>
    /// Reference to the function who called for set the score 
    /// </summary>
    void SetScoreAnimal()
    {
        if (IndexSubject == 2 && GameMode == "Extreme")
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("AnimalsHightScore", int.Parse(TextScore.text));
            }

        }
    }

    /// <summary>
    /// Reference to the function who called for set the score 
    /// </summary>
    void SetScoreSport()
    {
        if (IndexSubject == 3 && GameMode == "Extreme")
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("SportHightScore", int.Parse(TextScore.text));
            }

        }
    }

    /// <summary>
    /// Reference to the function who called for set the score 
    /// </summary>
    void SetScoreMytho()
    {
        if (IndexSubject == 4 && GameMode == "Extreme")
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("MythoHightScore", int.Parse(TextScore.text));
            }

        }
    }

    /// <summary>
    /// Reference to the function who called for get the score 
    /// </summary>
    void GetScoreGeo()
    {
        if (IndexSubject == 0 && GameMode == "Extreme")
        {
            MaxScore = PlayerPrefs.GetInt("GeoHightScore");
        }

       
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreStory()
    {
        if (IndexSubject == 1 && GameMode == "Extreme")
        {
            MaxScore = PlayerPrefs.GetInt("StoryHightScore");
        }
      
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreAnimals()
    {
        if (IndexSubject == 2 && GameMode == "Extreme")
        {
            MaxScore = PlayerPrefs.GetInt("AnimalsHightScore");
        }
      
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreSport()
    {
        if (IndexSubject == 3 && GameMode == "Extreme")
        {
            MaxScore = PlayerPrefs.GetInt("SportHightScore");
        }
 
    }

    /// <summary>
    ///  Reference to the function who called for get the score 
    /// </summary>
    void GetScoreMytho()
    {
        if (IndexSubject == 4 && GameMode == "Extreme")
        {
            MaxScore = PlayerPrefs.GetInt("MythoHightScore");
        }
      
    }

    #endregion
}
