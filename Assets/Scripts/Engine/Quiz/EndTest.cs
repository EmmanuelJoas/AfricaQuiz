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

        if (IndexSubject == 0)
        {
            MaxScore=PlayerPrefs.GetInt("GeoHightScore");
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
        else if (GameMode=="Randome")
        {
            MaxScore = PlayerPrefs.GetInt("RandomeHightScore");
        }
        Debug.Log(IndexSubject);
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

        if (GameMode == "Extreme" || GameMode == "Randome")
        {

            if (int.Parse(TextScore.text)>0 && int.Parse(TextScore.text) <= 5)
            {
                Akward[0].SetActive(true);
            }

            else if (int.Parse(TextScore.text) > 5 && int.Parse(TextScore.text) <= 10)
            {
                Akward[1].SetActive(true);
            }

            else if (int.Parse(TextScore.text) >= 15)
            {
                Akward[2].SetActive(true);
            }

        }

        SetScore();
    }

    /// <summary>
    /// Reference to the function who called for set the score 
    /// </summary>
    void SetScore()
    {
        if (IndexSubject == 0)
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("GeoHightScore", int.Parse(TextScore.text));
            }
            Debug.Log(PlayerPrefs.GetInt("GeoHightScore"));
        }
        else if (IndexSubject == 1)
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                 PlayerPrefs.SetInt("StoryHightScore", int.Parse(TextScore.text));
            }
            Debug.Log(PlayerPrefs.GetInt("StoryHightScore"));
        }
        else if (IndexSubject == 2)
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("AnimalsHightScore", int.Parse(TextScore.text));
            }
            Debug.Log(PlayerPrefs.GetInt("AnimalsHightScore"));
        }
        else if (IndexSubject == 3)
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("SportHightScore", int.Parse(TextScore.text));
            }
            Debug.Log(PlayerPrefs.GetInt("SportHightScore"));  
        }
        else if (IndexSubject == 4)
        {
            if (MaxScore < int.Parse(TextScore.text))
            { 
                PlayerPrefs.SetInt("MythoHightScore", int.Parse(TextScore.text));
            }
            Debug.Log(PlayerPrefs.GetInt("MythoHightScore")) ;
        }
        else if (GameMode == "Randome")
        {
            if (MaxScore < int.Parse(TextScore.text))
            {
                PlayerPrefs.SetInt("RandomeHightScore", int.Parse(TextScore.text));
            }
            
        }

    }

    #endregion
}
