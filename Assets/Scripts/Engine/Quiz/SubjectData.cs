//Name space to use the systeme generic collection function 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Subject", menuName = " Subject / new subject")]
public class SubjectData:ScriptableObject //Class use to list the elemets of the subject 
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

    /// <summary>
    /// Reference to the image reference 
    /// </summary>
    public List<Sprite> RefImage;

    #endregion
}
