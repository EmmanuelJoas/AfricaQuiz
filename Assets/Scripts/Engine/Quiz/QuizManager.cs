
//Name space to use the unity base function 
using UnityEngine;

public class QuizManager : MonoBehaviour//Class use to the gestion of the Quiz Game
{
    #region Variables

    /// <summary>
    /// Reference to the all subject 
    /// </summary>
    public GameObject[] Themes;

    /// <summary>
    /// Reference to the index subject 
    /// </summary>
    private int indexSubject;

    /// <summary>
    /// 
    /// </summary>
    public GameObject CurrentTheme;

    /// <summary>
    /// 
    /// </summary>
    public static QuizManager intance;

    #endregion

    #region Unity function

    /// <summary>
    /// 
    /// </summary>
    private void Awake()
    {
        indexSubject= PlayerPrefs.GetInt("SubjectIndex");

        intance = this;
    }

    /// <summary>
    /// 
    /// </summary>
    private void Start()
    {
        Themes[indexSubject].SetActive(true);
        CurrentTheme = Themes[indexSubject];
    }

 
    #endregion
}
