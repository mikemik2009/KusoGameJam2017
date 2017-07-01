using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaAI : MonoBehaviour {
    public GacheAct gache;


    public bool aggressive = true;

    private int enemy_gache_basic_child_cnt = 0;
    private int slef_gache_basic_child_cnt = 0;

    void Awake()
    {
        enemy_gache_basic_child_cnt = gache.enemy.transform.childCount;
        slef_gache_basic_child_cnt = gache.transform.childCount;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gache.coin >= GacheAct.ten_unit_cost)
        {
            gache.RollTenUnit();
            return;
        }

        if ((gache.enemy.transform.childCount - enemy_gache_basic_child_cnt) > (gache.transform.childCount - slef_gache_basic_child_cnt))
        {
            gache.RollAUnit();
            return;
        }

        if (aggressive && gache.enemy.transform.childCount < enemy_gache_basic_child_cnt+1 && gache.transform.childCount < slef_gache_basic_child_cnt+1)
        {
            gache.RollAUnit();
            return;
        }
    }
}
