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
    public AudioSource GameSong;

    /// <summary>
    /// Reference to the Game object audio manager 
    /// </summary>
    public AudioSource GoodAnswerSong;

    /// <summary>
    /// Reference to the Game object audio manager 
    /// </summary>
    public AudioSource WrongAnswerSong;

    /// <summary>
    /// Reference to the audio button 
    /// </summary>
    public Button AudioButton;


    #endregion

    #region Unity Function 

    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
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

    /// <summary>
    /// Referenec to the function who called on the start application 
    /// </summary>
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
            GameSong.GetComponent<AudioSource>().volume=0f;
            GoodAnswerSong.GetComponent<AudioSource>().volume = 0f;
            WrongAnswerSong.GetComponent<AudioSource>().volume = 0f;
            AudioButton.GetComponent<Image>().sprite = SoundsImage[0];
            SoudIsActive = false;
            SaveOption("Active");
        }
        else
        {
            GameSong.GetComponent<AudioSource>().volume = 0.5f;
            GoodAnswerSong.GetComponent<AudioSource>().volume = 0.5f;
            WrongAnswerSong.GetComponent<AudioSource>().volume = 0.5f;
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
