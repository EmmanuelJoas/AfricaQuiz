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
    /// Reference to the level of the Akward 
    /// </summary>
    private int LvlAkward;

    /// <summary>
    /// Reference to the quiz manager 
    /// </summary>
    public QuizManager QuizManager;

    #endregion

    #region Unity Function 


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
        if(int.Parse(TextScore.text)>0 && int.Parse(TextScore.text) < 5)
        {
            LvlAkward = 0;
            Akward[LvlAkward].SetActive(true);
        }

        else if (int.Parse(TextScore.text) > 5 && int.Parse(TextScore.text) < 10)
        {
            LvlAkward = 1;
            Akward[LvlAkward].SetActive(true);
        }

        else if (int.Parse(TextScore.text) ==15)
        {
            LvlAkward = 2;
            Akward[LvlAkward].SetActive(true);
        }
    }

    /// <summary>
    /// Reference to the function who called to set the 
    /// </summary>
    void SetAkward()
    {
        if (QuizManager.IndexSubject == 0)
        {

        }
        else if (QuizManager.IndexSubject == 0)
        {

        }
        else if (QuizManager.IndexSubject == 0)
        {

        }
        else if (QuizManager.IndexSubject == 0)
        {

        }


    }
    #endregion
}
