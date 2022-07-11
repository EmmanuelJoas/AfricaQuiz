//Name space to use the unity base function 
using UnityEngine;

//Name space to use the systeme collection function 
using System.Collections;

//Name space to use the unity ui function 
using UnityEngine.UI;

//Classe use to go the next for close the panel and to go next subject 
public class BookModeOption : MonoBehaviour
{
    #region Variables

    /// <summary>
    /// Reference is the panel is active 
    /// </summary>
    private bool isActive;

    /// <summary>
    /// Reference to the table of the image 
    /// </summary>
    public Sprite[] buttonImage;

    /// <summary>
    /// Reference to the actve button 
    /// </summary>
    public GameObject ActiveButton;

    /// <summary>
    /// Reference to the exit button 
    /// </summary>
    public GameObject ExitButton;

    #endregion

    #region Unity function 

    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        string state  =PlayerPrefs.GetString("PanelIsActive");

        if (state == "true")
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }

        Debug.Log(isActive);
    }

    /// <summary>
    /// Reference to the function who called on the start game 
    /// </summary>
    private void Start()
    {
        ActivePanel();
    }

    /// <summary>
    /// Reference to the function who called each frame 
    /// </summary>
    private void Update()
    {
         StartCoroutine(AutomaticChange());
    }

    #endregion

    #region My private function 

    /// <summary>
    /// Refernce to the function who called for close the panel and to go next subject 
    /// </summary>
    public void Next()
    {
        gameObject.SetActive(false);
        StartSubject.instance.GeneratorQuestion();
        StartSubject.instance.NormalStateButton();
    }

    /// <summary>
    /// Reference to the coroutine who called for change auto the panel 
    /// </summary>
    /// <returns></returns>
    IEnumerator AutomaticChange()
    {
        while (isActive != false)
        {
          yield return new WaitForSeconds(10f);
          gameObject.SetActive(false);
          StartSubject.instance.GeneratorQuestion();
          StartSubject.instance.NormalStateButton();
        }
        
    }

    /// <summary>
    /// Reference to the function who called for active or desable the panel 
    /// </summary>
    public void ActivePanel()
    {
        if (isActive == false)
        {
            ActiveButton.transform.GetComponent<Image>().sprite = buttonImage[0];
            ExitButton.SetActive(false);
            isActive = true;
            SaveOption("false");
        }
        else
        {
            ActiveButton.transform.GetComponent<Image>().sprite = buttonImage[1];
            ExitButton.SetActive(true);
            isActive = false;
            StopCoroutine(AutomaticChange());
            SaveOption("true");
        }
    }

    /// <summary>
    /// Reference to the function who called for save the option 
    /// </summary>
    private void SaveOption(string state)
    {
        PlayerPrefs.SetString("PanelIsActive", state);
    }
    #endregion
}
