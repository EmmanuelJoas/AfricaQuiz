
//Name space to use the unity base function 
using UnityEngine;

public class QuizManager : MonoBehaviour//Class use to the gestion of the Quiz Game
{
    #region Variables

    /// <summary>
    /// Reference to the all subject 
    /// </summary>
    public GameObject[] Subject;

    /// <summary>
    /// Reference to the index subject 
    /// </summary>
    private int indexSubject;

    public GameObject CurrentSubject;

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
        Subject[indexSubject].SetActive(true);
        CurrentSubject = Subject[indexSubject];
    }

 
    #endregion
}
