//Name space to the function generic of the systeme 
using System.Collections.Generic;

//Name space to use the unity base function 
using UnityEngine;

//Name space to use the unity UI function 
using UnityEngine.UI;

//Name space to use the unity base function 
using System.Collections;

public class StartSubject : MonoBehaviour
{
    #region Variables 


    /// <summary>
    /// Reference to the subject 
    /// </summary>
    public SubjectData Subject;

    /// <summary>
    /// Reference to the clone of the subject 
    /// </summary>
    private SubjectData _Subject;

    /// <summary>
    /// Reference to the all answers of the game 
    /// </summary>
    public GameObject[] answers;

    /// <summary>
    /// Reference to the image for ref the question 
    /// </summary>
    public Image RefImage;

    /// <summary>
    /// Reference to the current answers 
    /// </summary>
    private int currentQuestion;

    /// <summary>
    /// Reference to the text display the questions 
    /// </summary>
    public Text QuestionText;

    /// <summary>
    /// Reference to the text display the ref in the book mode 
    /// </summary>
    public Text TextRefBookMode;

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
    private float GameTime;

    /// <summary>
    /// Reference to the new time of the timer 
    /// </summary>
    private float NewTime = 20;

    /// <summary>
    /// Refernce to the index of the subject 
    /// </summary>
    private int  IndexSubject;

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

    /// <summary>
    /// Reference to the instance of the class 
    /// </summary>
    public static StartSubject instance;

    /// <summary>
    /// Reference to the description panel 
    /// </summary>
    public GameObject DescriptionPanel;


    IEnumerator myCoroutine;
    #endregion

    #region Unity function 


    /// <summary>
    /// Reference to the function who called before the start function 
    /// </summary>
    private void Awake()
    {
        _Subject = Instantiate(Subject);
        GameMode = PlayerPrefs.GetString("GameMode");
        instance = this;
        myCoroutine = TimeOnGame();
    }

    /// <summary>
    /// Referenec to the function who called on the start application 
    /// </summary>
    private void Start()
    {
       
        InitilizeSliderTime();

        StartCoroutine(TimeOnGame());
      
        GeneratorQuestion();

        MaxQuestions.text = " / " + (QuestionsNumber + 1) + "";

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

            if (_Subject.AnsAndQues[currentQuestion].GreatAnswer == i)
            {
                answers[i].transform.GetComponent<Image>().color = Color.green;

                answers[i].transform.GetComponent<Animator>().SetBool("IsActive", true);

            }

            else
            {
                answers[i].transform.GetComponent<Image>().color = Color.red;
            }
            answers[i].transform.GetComponent<Button>().interactable = false;
        }

        _Subject.AnsAndQues.RemoveAt(currentQuestion);//Remove the component of the list


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

            if (_Subject.AnsAndQues[currentQuestion].GreatAnswer != i)
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

        _Subject.AnsAndQues.RemoveAt(currentQuestion);//Remove the component of the list

        if (QuestionsNumber == 0)
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

            if (_Subject.AnsAndQues[currentQuestion].GreatAnswer != i)
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
        if (_Subject.AnsAndQues.Count > 0)
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

            answers[i].transform.GetChild(0).GetComponent<Text>().text = _Subject.AnsAndQues[currentQuestion].Answers[i];

            if (_Subject.AnsAndQues[currentQuestion].GreatAnswer == i)
            {
                answers[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

    }


    /// <summary>
    /// Reference to the function who called for generate the question 
    /// </summary>
    public void GeneratorQuestion()
    {

        if (GameMode == "Easy")
        {

            QuestionsNumber = _Subject.AnsAndQues.Count - 10;


            if (QuestionsNumber > 0)
            {

                currentQuestion = Random.Range(0, 5);

                QuestionText.text = _Subject.AnsAndQues[currentQuestion].Question;

                BookModeDisplay();

                SetAnswers();

                GiveIndice();

                AddAndDisplay();

                QuestionsNumber--;
            }
        }

        else if (GameMode == "Extreme")
        {
            QuestionsNumber = _Subject.AnsAndQues.Count;

            if (QuestionsNumber > 0)
            {
                currentQuestion = Random.Range(0, _Subject.AnsAndQues.Count);

                QuestionText.text = _Subject.AnsAndQues[currentQuestion].Question;

                BookModeDisplay();

                SetAnswers();

                GiveIndice();

                AddAndDisplay();

                QuestionsNumber--;

            }


        }

        DescriptionPanel.SetActive(false);
    }

    /// <summary>
    /// Reference to the function who called for display the ref of the book mode
    /// </summary>
    void BookModeDisplay()
    {
        TextRefBookMode.text = _Subject.AnsAndQues[currentQuestion].RefDescription;
        RefImage.sprite = _Subject.RefImage[currentQuestion];
        _Subject.RefImage.RemoveAt(currentQuestion);//Remove the component of the list
    }

    /// <summary>
    /// Referenec to the function who called when the end game 
    /// </summary>
    public void EndGame()
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
    public void InitilizeSliderTime()
    {
        GameTime = NewTime;

        SliderTimer.maxValue = GameTime;

        SliderTimer.value = GameTime;
    }


    /// <summary>
    /// Reference to the courotine who called after for the game time
    /// </summary>
    /// <returns></returns>
    IEnumerator TimeOnGame()
    {

        while (GameTime > 0)
        {
            GameTime--;

            SliderTimer.value = GameTime;

            yield return new WaitForSeconds(1.5f);
        }

        InitilizeSliderTime();

        if (QuestionsNumber > 0)
        {
            _Subject.AnsAndQues.RemoveAt(currentQuestion);//Remove the component of the list

        }

        GeneratorQuestion();

        StartCoroutine(TimeOnGame());

        IndicePanel.SetActive(false);

        DescriptionPanel.SetActive(false);

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
        IndiceText.text = _Subject.AnsAndQues[currentQuestion].Indice;
    }

    public void NormalStateButton()
    {
        for (int i = 0; i < answers.Length; i++)
        {
            answers[i].transform.GetComponent<Animator>().SetBool("IsActive", false);

            answers[i].transform.GetComponent<Image>().color = Color.white;

            answers[i].transform.GetComponent<Button>().interactable = true;
        }
    }

    /// <summary>
    /// Reference to the courotine who called for load the new question of the test 
    /// </summary>
    /// <returns></returns>
     IEnumerator LoadNewQuestion()
     {

        yield return new WaitForSeconds(3f);

        NormalStateButton();

        InitilizeSliderTime();

        GeneratorQuestion();
    
        IndicePanel.SetActive(false);

        ActiveWrongAnswers();

        DescriptionPanel.SetActive(false);

     }


    #endregion
}
