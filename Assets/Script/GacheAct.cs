using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GacheAct : MonoBehaviour {
    public float coin = 0;

    public static int a_unit_cost = 10;
    public static int ten_unit_cost = 100;

    public static float[] prob = new float[] {63f, 25f, 10f, 1.9f, 0.9999f, 0.0001f};

    public float accProb = 0f;

    public GameObject[] units = new GameObject[6];

    public GameObject enemy;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.coin += Time.deltaTime;
        
        RollAUnit();

        accProb += Time.deltaTime;
    }

    void RollAUnit()
    {
        if (coin < a_unit_cost)
            return;

        int idx = 0;
        float p = Random.Range(0f, 100f);
        for(int i = prob.Length-1; i >=0; i--)
        {
            idx = i;

            if ((p -= (prob[i]* accProb/10)) <= 0f)
            {
                break;
            }
        }

        var unit = Instantiate(units[idx], this.transform);
        unit.tag = this.gameObject.tag;
        unit.GetComponent<UnitAct>().destination = enemy;

        coin -= a_unit_cost;
    }


    void RollTenUnit()
    {
        if (coin < ten_unit_cost)
            return;

        for (int cnt = 0; cnt < 11; cnt++)
        {
            int idx = 0;
            float p = Random.Range(0f, 100f);
            for (int i = prob.Length - 1; i >= 0; i--)
            {
                idx = i;

                if ((p -= (prob[i] * accProb / 10)) <= 0f)
                {
                    break;
                }
            }

            if (cnt == 10)
                idx = Mathf.Max(idx, 2);

            var unit = Instantiate(units[idx], this.transform);
            unit.tag = this.gameObject.tag;
            unit.GetComponent<UnitAct>().destination = enemy;
        }

        coin -= ten_unit_cost;
    }
}
