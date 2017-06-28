using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class probUI : MonoBehaviour
{
    string[] probs = new string[] { "<color=grey>N:</color> ",
                                    "<color=silver>R:</color> ",
                                    "<color=#2C5F8EFF>S:</color> ",
                                    "<color=red>SR:</color> ",
                                    "<color=orange>SSR:</color> ",
                                    "<color=red>S</color><color=orange>S</color><color=yellow>S</color><color=green>S</color><color=blue>S</color><color=cyan>S</color><color=purple>R:</color> " };
    private float time = 0f;
    public float updatetime = 0f;

    void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {

            float aa = 0;
            float tol = 0;
            string sss = "";

            for (int i = Manager.Instance.getProb().Length-1; i >= 0; i--)
            {
                if (tol >= 100)
                {
                    sss += probs[i] + string.Format("{0,6:F2}%  ", 0);
                }
                else
                {
                    aa = Manager.Instance.getProb()[i];

                    aa = tol + aa >= 100 ? 100 - tol : aa;

                    sss += probs[i] + string.Format("{0,6:F2}%  ", Mathf.Min(100, aa));

                    tol += Manager.Instance.getProb()[i];
                }
            }
            this.GetComponent<UnityEngine.UI.Text>().text = sss;

            //this.GetComponent<UnityEngine.UI.Text>().text = string.Format("<color=grey>N:</color> {0,6:F2}%  "
            //                                                            + "<color=silver>R:</color> {1,6:F2}%  "
            //                                                            + "<color=#2C5F8EFF>S:</color> {2,6:F2}%  "
            //                                                            + "<color=red>SR:</color>  {3,6:F2}%  "
            //                                                            + "<color=orange>SSR:</color>  {4,6:F2}%  "
            //                                                            + "<color=red>S</color><color=orange>S</color><color=yellow>S</color><color=green>S</color><color=blue>S</color><color=cyan>S</color><color=purple>R:</color>  {5,6:F2}%  "
            //                                                            , Manager.Instance.getProb()[0]
            //                                                            , Manager.Instance.getProb()[1]
            //                                                            , Manager.Instance.getProb()[2]
            //                                                            , Manager.Instance.getProb()[3]
            //                                                            , Manager.Instance.getProb()[4]
            //                                                            , Manager.Instance.getProb()[5]);
            
            time = updatetime;
        }
    }
}
