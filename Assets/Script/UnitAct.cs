using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAct : MonoBehaviour {
    public enum State{
        Born,
        Move,
        Attack,
        Idle,
        HardContorl,
        Dead
    };

    public float speed = 0f;
    public float detectRadius = 10f;
    public float CDTime = 0f;
    public int atk = 1;
    public int HP = 10;
    public float attack_range = 0f;

    public State _curState;
    private float _colddownTime;
    private float _searchEnemyRange;

    public GameObject destination;
    public GameObject target;
    
    // Use this for initialization
    void Start ()
    {
        _searchEnemyRange = this.GetComponent<BoxCollider2D>().size.x;
        this._curState = State.Born;
    }

    // Update is called once per frame
    void Update () {
        switch (this._curState)
        {
            case State.Born:
                Born();
                break;

            case State.Idle:
                Idle();
                break;

            case State.Move:
                Move();
                break;
                
            case State.Attack:
                Attack();
                break;
                
            case State.Dead:
                Dead();
                break;
        }

        _colddownTime -= Time.deltaTime;

        if (HP <= 0)
            this._curState = State.Dead;
    }    

    void Born()
    {
        target = destination;
        this._curState = State.Idle;
    }

    void Idle()
    {
        if (IsActable())
        {
            if (IsEnemyBeside())
                this._curState = State.Attack;
            else if (IsMoveable())
                this._curState = State.Move;
        }
    }

    void Move()
    {
        if (IsEnemyBeside() || !IsActable())
        {
            this._curState = State.Idle;
            return;
        }

        Vector3 startPos = this.transform.position;
        Vector3 targetPos = SelectTarget();
        float journeyLength = Vector3.Distance(startPos, targetPos);
        float fracJourney = this.speed / journeyLength;
        this.transform.position = Vector3.Lerp(startPos, targetPos, fracJourney);
    }

    void Attack()
    {
        if (!IsEnemyBeside() || !IsActable() || IsColdDown())
        {
            this._curState = State.Idle;
            return;
        }

        print(this);
        target.SendMessage("OnDamage", GetAttackPower(), SendMessageOptions.DontRequireReceiver);
        
        _colddownTime = CDTime;
    }
    
    int GetActualDamage(int ap)
    {
        return ap;
    }

    void OnDamage(int ap)
    {
        int damage = GetActualDamage(ap);

        this.HP -= damage;

        //if(HP <= 0)
        //    this._curState = State.Dead;
    }

    int GetAttackPower()
    {
        return this.atk;
    }

    void Dead()
    {
        Destroy(this.gameObject);
    }

    Vector3 SelectTarget()
    {
        //Vector3 ret = new Vector3(0, 0, 0);

        if (!target)
            target = destination;

        Vector3 ret = target.transform.position;

        return ret;
    }

    bool IsEnemyBeside()
    {
        if (!target)
            return false;

        Vector3 startPos = this.transform.position;
        return attack_range >= Vector3.Distance(startPos, target.transform.position);
    }

    bool IsMoveable()
    {
        bool ret = true;

        return ret;
    }

    bool IsColdDown()
    {
        return _colddownTime > 0;
    }
    
    bool IsActable()
    {
        bool ret = true;

        return ret;
    }    

    void OnTriggerEnter2D(Collider2D collider)
    {
        target = collider.gameObject;
    }
}
