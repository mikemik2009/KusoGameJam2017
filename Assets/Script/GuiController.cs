using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiController : MonoBehaviour
{
    public GameObject gameover;
    public GameObject startgame;
    public GameObject gamelayer;

    public GameObject AllUnitParentObj;

    public GameObject gameoverText;

    public static GuiController singleton = null;

    void Awake()
    {
        //Check if instance already exists
        if (singleton == null)
        {
            //if not, set instance to this
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //If instance already exists and it's not this:
        else if (singleton != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }
}