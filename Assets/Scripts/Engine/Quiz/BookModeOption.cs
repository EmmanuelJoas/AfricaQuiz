//Name space to use the unity base function.
using UnityEngine;

//Name space to use the event systems function.
using UnityEngine.EventSystems;

//Classe use to go the next for close the panel and to go next subject.
public class BookModeOption : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{

    #region Unity function 


    /// <summary>
    /// Do this when the cursor enters the rect area of this selectable UI object.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartSubject.instance.StopAllCoroutines();
    }

    /// <summary>
    /// Do this when the cursor exit the rect area of this selectable UI object.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        StartSubject.instance.GeneratorQuestion();
        StartSubject.instance.NormalStateButton();
        StartSubject.instance.InitilizeSliderTime();
        StartSubject.instance.StartCoroutine("TimeOnGame");
        StartSubject.instance.DescriptionPanel.SetActive(false);
    }
    #endregion

}
