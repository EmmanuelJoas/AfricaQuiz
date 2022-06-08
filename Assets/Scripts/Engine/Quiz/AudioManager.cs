//Name space to use the unity base function 
using UnityEngine;


//Name space to use the unity function of the UI 
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    #region Variable


    /// <summary>
    /// Referenece to the image of the button audio 
    /// </summary>
    public Sprite[] SoundsImage;


    /// <summary>
    /// Reference if the sound is actice 
    /// </summary>
    private  bool SoudIsActive;


    /// <summary>
    /// Reference to the Game object audio manager 
    /// </summary>
    public GameObject AudioManagerObject;


    /// <summary>
    /// Reference to the audio button 
    /// </summary>
    public Button AudioButton;


    #endregion

    #region Unity Function 
    private void Awake()
    {
        if (PlayerPrefs.GetString("SoudIsActive")=="Active")
        {
            SoudIsActive = true;
        }
        else if (PlayerPrefs.GetString("SoudIsActive") == "Desable")
        {
            SoudIsActive = false;
        }
    }

    private void Start()
    {
        SetSounds();
    }

    #endregion


    #region My Private Function 


    /// <summary>
    /// Reference to the function who called for desable the sound or active the sound 
    /// </summary>
    public void SetSounds()
    {
        if (SoudIsActive)
        {
            AudioManagerObject.SetActive(false);
            AudioButton.GetComponent<Image>().sprite = SoundsImage[0];
            SoudIsActive = false;
            SaveOption("Active");
        }
        else
        {
            AudioManagerObject.SetActive(true);
            AudioButton.GetComponent<Image>().sprite = SoundsImage[1];
            SoudIsActive = true;
            SaveOption("Desable");
        }
       
        
    }


    /// <summary>
    /// Reference to the function who called for save the option of the sound 
    /// </summary>
    void SaveOption(string state)
    {
        PlayerPrefs.SetString("SoudIsActive",state);
    }


    #endregion
}
