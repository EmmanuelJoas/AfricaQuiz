//Name space to the function generic of the systeme 
using System.Collections.Generic;

//Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity UI function 
using UnityEngine.UI;

//Name space to use the unity base function 
using System.Collections;



public class QuizManager : MonoBehaviour//Class use to the gestion of the Quiz Game
{
    #region Variables 


    /// <summary>
    /// Reference to the subject 
    /// </summary>
    public List<SubjectList> AllSubject ;


    /// <summary>
    /// Reference to the all answers of the game 
    /// </summary>
    public GameObject[] answers;


    /// <summary>
    /// Reference to the current answers 
    /// </summary>
    private int currentQuestion;


    /// <summary>
    /// Reference to the text display the questions 
    /// </summary>
    public Text QuestionText;


    /// <summary>
    /// Reference to the End Game ui
    /// </summary>
    public GameObject EndGameUI;


    /// <summary>
    /// Reference to the game ui 
    /// </summary>
    public GameObject GameUI;


    /// <summary>
    /// reference to the all answers game 
    /// </summary>
    public GameObject AnswersGame;


    /// <summary>
    /// Reference to the all questions 
    /// </summary>
    public GameObject Questions;


    /// <summary>
    /// Reference of the text display the number of Answers
    /// </summary>
    public Text CurrentQuestionText;


    /// <summary>
    /// Reference of the text display the number max of questions 
    /// </summary>
    public Text MaxQuestions;


    /// <summary>
    /// Reference to the number of Answers 
    /// </summary>
    private int CurrentNumberQuestion;


    /// <summary>
    /// Reference to the slider time 
    /// </summary>
    public Slider SliderTimer;


    /// <summary>
    /// Reference to the time game 
    /// </summary>
    private float Time ;


    /// <summary>
    /// Reference to the new time of the timer 
    /// </summary>
    private float NewTime = 20;


    /// <summary>
    /// Refernce to the index of the subject 
    /// </summary>
    public int IndexSubject;


    /// <summary>
    /// Reference to the text indice
    /// </summary>
    public Text IndiceText;


    /// <summary>
    /// Reference to the indice panel
    /// </summary>
    public GameObject IndicePanel;


    /// <summary>
    /// Reference to the game mode 
    /// </summary>
    private string GameMode;


    /// <summary>
    /// Reference to the Answer script
    /// </summary>
    public AnswerScript AnswerScript;

    /// <summary>
    /// Reference to the bonus panel 
    /// </summary>
    public GameObject BonusPanel;

    /// <summary>
    /// Reference to the Wrong answer panel 
    /// </summary>
    public GameObject WrongAnswerPanel;


    /// <summary>
    /// Reference to the number for question of the test 
    /// </summary>
    public int QuestionsNumber;


    /// <summary>
    /// Reference to the animator for the button of Answers 
    /// </summary>
    public Animator Animator;


    /// <summary>
    /// Reference to the NumberQuestionsPanel
    /// </summary>
    public GameObject NumberQuestionsPanel;


    #endregion

    #region Unity function 


    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        IndexSubject = PlayerPrefs.GetInt("SubjectIndex");

        GameMode = PlayerPrefs.GetString("GameMode");
    }


    /// <summary>
    /// Referenec to the function who called on the start application 
    /// </summary>
    private void Start()
    {
        InitilizeSliderTime();

        StartCoroutine(TimeOnGame());

        GeneratorQuestion();

        MaxQuestions.text = " / " + (QuestionsNumber+1) + "";

        CurrentQuestionText.text = CurrentNumberQuestion.ToString();
  
    }


    #endregion

    #region My Private function 

    /// <summary>
    /// Reference to the function who called when giving correct an answers 
    /// </summary>
    public void Correct()
    {
       AnswerScript.GoodAnswer();

       StartCoroutine(LoadNewQuestion());

       for (int i = 0; i < answers.Length; i++)
       {

         if (AllSubject[IndexSubject].AnsAndQues[currentQuestion].GreatAnswer == i)
         {
           answers[i].transform.GetComponent<Image>().color = Color.green;

           answers[i].transform.GetComponent<Animator>().SetBool("IsActive", true);

         }

         else
         {
           answers[i].transform.GetComponent<Image>().color=Color.red;
         }
            answers[i].transform.GetComponent<Button>().interactable = false;
       }
   
        AllSubject[IndexSubject].AnsAndQues.RemoveAt(currentQuestion);//Remove the component of the list


        if (QuestionsNumber == 0)
        {
            EndGame();
        }
    }
       

    /// <summary>
    /// Reference to the function who called when giving correct an answers 
    /// </summary>
    public void Wrong()
    {
       AnswerScript.WrongAnswers();   
        
       StartCoroutine(LoadNewQuestion());

       for (int i = 0; i < answers.Length; i++)
       {

          if (AllSubject[IndexSubject].AnsAndQues[currentQuestion].GreatAnswer != i)
          {
             answers[i].transform.GetComponent<Image>().color = Color.red; ;
          }

          else
          {
             answers[i].transform.GetComponent<Image>().color = Color.green;

             answers[i].transform.GetComponent<Animator>().SetBool("IsActive", true);
          }

            answers[i].transform.GetComponent<Button>().interactable = false;
       }
       
        AllSubject[IndexSubject].AnsAndQues.RemoveAt(currentQuestion);//Remove the component of the list
        
       if (QuestionsNumber ==0)
       {
            EndGame();
       }
      
    }


    /// <summary>
    /// Reference to the function who called for desable the wrong answer 
    /// </summary>
    public void DesableWrongAnswers()
    {
        int Answers = answers.Length;

        for (int i = 0; i < Answers - 1; i++)
        {

            if (AllSubject[IndexSubject].AnsAndQues[currentQuestion].GreatAnswer != i)
            {
                answers[i].SetActive(false);
            }
        }
    }


    /// <summary>
    /// Reference to the function who called for active the weong answer 
    /// </summary>
    public void ActiveWrongAnswers()
    {
        if (AllSubject[IndexSubject].AnsAndQues.Count > 0)
        {
            for (int i = 0; i < answers.Length; i++)
            {

               answers[i].SetActive(true);
                
            }
        }
    }


    /// <summary>
    /// Reference to the function who called to set the answers 
    /// </summary>
    void SetAnswers()
    {
        
       for (int i = 0; i < answers.Length; i++)
       { 
           answers[i].GetComponent<AnswerScript>().isCorrect = false;

             answers[i].transform.GetChild(0).GetComponent<Text>().text = AllSubject[IndexSubject].AnsAndQues[currentQuestion].Answers[i];

          if (AllSubject[IndexSubject].AnsAndQues[currentQuestion].GreatAnswer == i)
          {
            answers[i].GetComponent<AnswerScript>().isCorrect = true;
          }
       }
        
    }


    /// <summary>
    /// Reference to the function who called for generate the question 
    /// </summary>
    void GeneratorQuestion()
    { 

        if (GameMode == "Easy")
        {

            QuestionsNumber = AllSubject[IndexSubject].AnsAndQues.Count - 10;


            if (QuestionsNumber > 0)
            {

                currentQuestion = Random.Range(0, 5);

                QuestionText.text = AllSubject[IndexSubject].AnsAndQues[currentQuestion].Question;

                SetAnswers();

                GiveIndice();

                AddAndDisplay();

                QuestionsNumber--;
            }
        }

        else if (GameMode == "Hard")
        {
            QuestionsNumber = AllSubject[IndexSubject].AnsAndQues.Count-10;

            if (QuestionsNumber > 0)
            {
                currentQuestion = Random.Range(6, 10);

                QuestionText.text = AllSubject[IndexSubject].AnsAndQues[currentQuestion].Question;

                SetAnswers();

                GiveIndice();

                AddAndDisplay();

                QuestionsNumber--;

            }
        }

        else if (GameMode == "Extreme")
        {
            QuestionsNumber = AllSubject[IndexSubject].AnsAndQues.Count;

            if (QuestionsNumber > 0)
            {
                currentQuestion = Random.Range(0, AllSubject[IndexSubject].AnsAndQues.Count);

                QuestionText.text = AllSubject[IndexSubject].AnsAndQues[currentQuestion].Question;

                SetAnswers();

                GiveIndice();

                AddAndDisplay();

                QuestionsNumber--;

            } 
            
          
        }

         else if (GameMode == "Randome")
         {
            NumberQuestionsPanel.SetActive(false);

            IndexSubject = Random.Range(0, 3);

            QuestionsNumber = AllSubject[IndexSubject].AnsAndQues.Count-1;

            if (QuestionsNumber > 0)
            {

                currentQuestion = QuestionsNumber-1;
                
                QuestionText.text = AllSubject[IndexSubject].AnsAndQues[currentQuestion].Question;

                SetAnswers();

                GiveIndice();

                AddAndDisplay();

                QuestionsNumber--;
            }

         }
        

    }


    /// <summary>
    /// Referenec to the function who called when the end game 
    /// </summary>
    void EndGame()
    {
        EndGameUI.SetActive(true);

        GameUI.SetActive(false);

        AnswersGame.SetActive(false);

        Questions.SetActive(false);

        BonusPanel.SetActive(false);

        WrongAnswerPanel.SetActive(false);

        StopCoroutine(TimeOnGame());
        
    }


    /// <summary>
    /// Reference to the function who called for add and display the number of question 
    /// </summary>
    public void AddAndDisplay()
    {
        CurrentNumberQuestion++;

        CurrentQuestionText.text = CurrentNumberQuestion.ToString();
    }


    /// <summary>
    /// Reference to the function who called for initialize the timer 
    /// </summary>
   public  void InitilizeSliderTime()
   {
        Time = NewTime;

        SliderTimer.maxValue = Time;

        SliderTimer.value = Time;
   }


    /// <summary>
    /// Reference to the courotine who called after for the game time
    /// </summary>
    /// <returns></returns>
     IEnumerator TimeOnGame()
     {
       
            while (Time > 0)
            {
                Time--;

                SliderTimer.value = Time;

                yield return new WaitForSeconds(1.5f);
            }

            InitilizeSliderTime();

             if (QuestionsNumber > 0)
             {
                 AllSubject[IndexSubject].AnsAndQues.RemoveAt(currentQuestion);//Remove the component of the list

             }
           
            GeneratorQuestion();

            StartCoroutine(TimeOnGame());

            IndicePanel.SetActive(false);

            if (QuestionsNumber == 0)
            {
                EndGame();

            }
           
        
      
     }


    /// <summary>
    /// Reference to the functon who called for give the indice 
    /// </summary>
    void GiveIndice()
    {
        IndiceText.text = AllSubject[IndexSubject].AnsAndQues[currentQuestion].Indice;
    }
        
    
    /// <summary>
    /// Reference to the courotine who called for load the new question of the test 
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadNewQuestion()
    {
  
        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < answers.Length; i++)
        {   
            answers[i].transform.GetComponent<Animator>().SetBool("IsActive", false);

            answers[i].transform.GetComponent<Image>().color = Color.white;

            answers[i].transform.GetComponent<Button>().interactable = true;
        }

        InitilizeSliderTime();

        GeneratorQuestion();

        IndicePanel.SetActive(false);

        ActiveWrongAnswers();

    }


    #endregion
}
