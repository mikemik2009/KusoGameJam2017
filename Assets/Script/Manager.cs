using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Manager : MonoBehaviour{

    private static Manager s_Instance;
    public float[] prob = new float[] { 65f, 13f, 12f, 7f, 2.9f, 0.1f};

    public float accProb = 1.0f;

    public static Manager Instance
    {
        get
        {
            if (s_Instance == null)
            {
                GameObject go = new GameObject("Manager");
                s_Instance = go.AddComponent<Manager>();
                //s_Instance = new Manager();
            }

            return s_Instance;
        }
    }

    // Use this for initialization
    void Start ()
    {
        if (Instance != this) Destroy(this);

        GuiController.singleton.gameover.SetActive(false);
        GuiController.singleton.gamelayer.SetActive(false);
        GuiController.singleton.startgame.SetActive(true);

        GuiController.singleton.AllUnitParentObj.BroadcastMessage("GameOver", SendMessageOptions.DontRequireReceiver);
    }
	
	// Update is called once per frame
	void Update ()
    {
        accProb += Time.deltaTime/10;
    }

    public float[] getProb()
    {
        float[] ret = new float[prob.Length];

        for (int i = 0; i < prob.Length; i++)
            ret[i] = prob[i] * accProb;

        return ret;
    }

    public void GameOver(string tag)
    {
        GuiController.singleton.gameover.SetActive(true);
        if (tag == "player")
            GuiController.singleton.gameoverText.GetComponent<UnityEngine.UI.Text>().text = "You Lose..";
        else
            GuiController.singleton.gameoverText.GetComponent<UnityEngine.UI.Text>().text = "You Win!";

        GuiController.singleton.AllUnitParentObj.BroadcastMessage("GameOver", SendMessageOptions.DontRequireReceiver);
    }

    public void StartGame()
    {
        accProb = 1.0f;
        GuiController.singleton.startgame.SetActive(false);
        GuiController.singleton.gamelayer.SetActive(true);
        GuiController.singleton.AllUnitParentObj.BroadcastMessage("StartGame", SendMessageOptions.DontRequireReceiver);
    }

    public void RestartGame()
    {
        accProb = 1.0f;

        GuiController.singleton.gameover.SetActive(false);
        GuiController.singleton.gamelayer.SetActive(true);

        GuiController.singleton.AllUnitParentObj.BroadcastMessage("StartGame", SendMessageOptions.DontRequireReceiver);
    }
}