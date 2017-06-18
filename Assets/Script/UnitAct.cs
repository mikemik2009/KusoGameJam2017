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
    public float atk = 1;
    public float HP = 10;
    public float attack_range = 1f;

    public State _curState;
    private float _colddownTime;
    private float _searchEnemyRange;
    private Animator _anim;

    public GameObject destination;
    public GameObject target;



    // Use this for initialization
    void Start ()
    {
        attack_range += this.GetComponent<BoxCollider2D>().bounds.size.x;   
        _searchEnemyRange = this.GetComponent<BoxCollider2D>().bounds.size.x;
        _anim = this.GetComponent<Animator>();
        this._curState = State.Born;

        if (this.tag == "enemy")
            this.transform.localScale = new Vector3(this.transform.localScale.x * - 1, this.transform.localScale.y, this.transform.localScale.z);
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
                StartCoroutine(Dead());
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
        targetPos.y = startPos.y;
        float journeyLength = Vector3.Distance(startPos, targetPos);
        float fracJourney = this.speed / journeyLength;
        this.transform.position = Vector3.Lerp(startPos, targetPos, fracJourney);
    }

    void Attack()
    {
        if (!IsEnemyBeside() || !IsActable() || IsColdDown())
        {
            print(this.tag + !IsEnemyBeside() + IsColdDown());
            this._curState = State.Idle;
            return;
        }
        
        target.SendMessage("OnDamage", GetAttackPower(), SendMessageOptions.DontRequireReceiver);
        
        _colddownTime = CDTime;
    }

    float GetActualDamage(float ap)
    {
        return ap;
    }

    void OnDamage(float ap)
    {
        float damage = GetActualDamage(ap);
        
        this.HP -= damage;

        _anim.Play("Unit_N_Hurt");
        //if (HP <= 0)
        //    this._curState = State.Dead;
    }

    float GetAttackPower()
    {
        return this.atk;
    }

    IEnumerator Dead()
    {
        _anim.Play("Unit_N_Death");
        var time = _anim.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        
        yield return new WaitForSeconds(time);

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
        if(collider.tag != this.tag)
            target = collider.gameObject;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag != this.tag)
        {
            target = coll.gameObject;
        }
    }
}
