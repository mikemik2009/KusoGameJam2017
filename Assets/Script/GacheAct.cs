using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GacheAct : MonoBehaviour {
    public float coin = 0;

    public static int a_unit_cost = 10;
    public static int ten_unit_cost = 100;

    public GameObject[] units = new GameObject[6];

    public GameObject enemy;
    
    public GameObject spawner;
    public UI_ProgressBarC hp_bar;
    public GameObject damage_label;
    public UnityEngine.UI.Text money_label;

    public float HP = 100f;
    private UnityEngine.UI.Button _button;
    private bool _gamestart = false;

    // Use this for initialization
    void Start ()
    {
        _button = this.GetComponent<UnityEngine.UI.Button>();
    }

    void StartGame()
    {
        coin = 0f;
        HP = 100f;
        _gamestart = true;
    }

    void GameOver()
    {
        _gamestart = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if (!_gamestart)
            return;

        if (this.HP <= 0)
        {
            Manager.Instance.GameOver(this.tag);
            return;
        }

        if (this.hp_bar)
        {
            this.hp_bar.Value = (long)this.HP;
        }
        
        this.coin += Time.deltaTime * 10;
        if(money_label)
            money_label.text = Mathf.FloorToInt(this.coin).ToString();
    }

    public void RollAUnit()
    {
        if (this.HP <= 0)
            return;

        if (coin < a_unit_cost)
            return;

        int idx = 0;
        float p = Random.Range(0f, 100f);
        for(int i = Manager.Instance.getProb().Length-1; i >=0; i--)
        {
            idx = i;

            if ((p -= Manager.Instance.getProb()[i]) <= 0f)
            {
                break;
            }
        }

        var unit = Instantiate(units[idx], this.transform);
        unit.tag = this.gameObject.tag;
        unit.GetComponent<UnitAct>().destination = enemy;
        unit.transform.position = spawner.transform.position;

        _button.onClick.Invoke();
        coin -= a_unit_cost;
    }


    public void RollTenUnit()
    {
        if (this.HP <= 0)
            return;

        if (coin < ten_unit_cost)
            return;

        for (int cnt = 0; cnt < 11; cnt++)
        {
            int idx = 0;
            float p = Random.Range(0f, 100f);
            for (int i = Manager.Instance.getProb().Length - 1; i >= 0; i--)
            {
                idx = i;

                if ((p -= Manager.Instance.getProb()[i]) <= 0f)
                {
                    break;
                }
            }

            if (cnt == 10)
                idx = Mathf.Max(idx, 2);

            var unit = Instantiate(units[idx], this.transform);
            unit.tag = this.gameObject.tag;
            unit.GetComponent<UnitAct>().destination = enemy;
            unit.transform.position = spawner.transform.position;
        }

        _button.onClick.Invoke();
        coin -= ten_unit_cost;
    }


    void OnDamage(float damage)
    {
        this.HP -= damage;
        if (damage_label)
        {
            damage_label.GetComponent<UnityEngine.UI.Text>().text = "-" + damage;

            var label = Instantiate(damage_label, this.transform);

            label.transform.position = transform.TransformPoint(new Vector3(144.5f, 67.5f, 0));

            label.GetComponent<TypefaceAnimator>().onComplete.AddListener(() => {
                Destroy(label);
            });
        }
    }

    void addMoney(float money)
    {
        coin += money;
    }
}
