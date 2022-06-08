//Name space to use the systeme generic collection function 
using System.Collections.Generic;

[System.Serializable]
public class SubjectList //Class use to list the elemets of the subject 
{
    #region Variables 


    /// <summary>
    /// Reference to the subject name 
    /// </summary>
    public string Subject;


    /// <summary>
    /// Reference to the liste that contains the questions and answers 
    /// </summary>
    public List<AnswerAndQuestion> AnsAndQues;


    #endregion
}
