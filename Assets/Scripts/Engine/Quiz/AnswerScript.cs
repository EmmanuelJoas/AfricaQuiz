// Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity ui function 
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour//Class use when the user give the answer 
{
    #region Variables 

    /// <summary>
    /// Reference if the answer is correct 
    /// </summary>
    public bool isCorrect = false;

    /// <summary>
    /// Reference to the audios good answer 
    /// </summary>
    public AudioSource GoodAnswerSound;


    /// <summary>
    /// Reference to the audios Wrong answer
    /// </summary>
    public AudioSource WrongAnswerSound;


    /// <summary>
    /// Reference the number of Answer 
    /// </summary>
   public  int GoodAnswerPoints;

    /// <summary>
    /// Reference the number of Answer 
    /// </summary>
    public int WrongAnswerPoints;


    #endregion

    #region My private Function 


    /// <summary>
    /// Reference to the function who called when the user give a answer 
    /// </summary>
    public void Answer()
    {
        if (isCorrect)
        {
            QuizManager.intance.CurrentTheme.Correct();

            GoodAnswerSound.Play();

            QuizManager.intance.CurrentTheme.DescriptionPanel.SetActive(true);


        }
        else
        {

            QuizManager.intance.CurrentTheme.Wrong();

            WrongAnswerSound.Play();

            QuizManager.intance.CurrentTheme.DescriptionPanel.SetActive(true);

        }
      
    }



    /// <summary>
    /// Reference to the function who called for add and display the number of Answers
    /// </summary>
    public void WrongAnswers()
    {
        WrongAnswerPoints++;
    }


    /// <summary>
    /// Reference to the function who called for add and display the number of Answers
    /// </summary>
    public void GoodAnswer()
    {
        GoodAnswerPoints++;
    }


    #endregion
}
