
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

    private int CurrentSubject;

    private GameObject _currentSubject;

    /// <summary>
    /// 
    /// </summary>
    public StartSubject CurrentTheme;

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

        Themes[indexSubject].SetActive(true);

        StartSubject();



    }

    /// <summary>
    /// 
    /// </summary>
    private void StartSubject()
    {
        /*CurrentSubject = Random.Range(0, Themes[indexSubject].transform.childCount);

        _currentSubject=Themes[indexSubject].transform.GetChild(CurrentSubject).gameObject;

        _currentSubject.SetActive(true);*/

       CurrentTheme = Themes[indexSubject].transform.GetChild(CurrentSubject).transform.GetComponent<StartSubject>();
    }
    #endregion
}
