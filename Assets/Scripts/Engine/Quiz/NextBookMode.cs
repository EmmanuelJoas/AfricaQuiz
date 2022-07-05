//Name space to use the unity base function 
using UnityEngine;

//Classe use to go the next for close the panel and to go next subject 
public class NextBookMode : MonoBehaviour
{

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
    #endregion
}
