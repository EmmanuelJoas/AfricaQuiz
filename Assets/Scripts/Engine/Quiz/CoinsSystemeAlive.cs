//Name space to use the unity base function  
using UnityEngine;

public class CoinsSystemeAlive : MonoBehaviour//Class to use for alive the coin 
{
    #region Variables 


    /// <summary>
    /// Reference to the game object player 
    /// </summary>
    private GameObject CoinsAlive;


    /// <summary>
    /// Reference to the speed for move of the coins 
    /// </summary>
    private int Multipline;


    /// <summary>
    /// Reference is the coin is magneted
    /// </summary>
    public bool isMagnet = false;


    /// <summary>
    /// Reference if the game object is alive 
    /// </summary>
    public bool alive = true;


    #endregion


    #region Unity Function 


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        CoinsAlive = GameObject.FindGameObjectWithTag("Player");
        isMagnet = true;
    }


    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void FixedUpdate()
    {
        if (isMagnet)
        {
            Multipline += 1;
            gameObject.transform.position += Multipline * Time.deltaTime * (CoinsAlive.transform.position - gameObject.transform.position);

            if (gameObject.transform.position == CoinsAlive.transform.position)
            {
                isMagnet = false;
                Destroy(gameObject);
            }
        }
        if (alive == false)
        {
            Destroy(gameObject);
        }
    }


    #endregion 
}
