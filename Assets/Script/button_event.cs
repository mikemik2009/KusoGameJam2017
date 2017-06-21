using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_event : MonoBehaviour {

	// Use this for initialization
	void Awake() {
        Manager m = Manager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void start_clicked()
    {
        Manager.Instance.StartGame();
    }

    public void restart_clicked()
    {
        Manager.Instance.RestartGame();
    }
}
