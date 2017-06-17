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

    public State _curState;
    public float speed = 0f;
    public float detectRadius = 10f;

    private float _startMoveTime;
    
    public GameObject target;
    
    // Use this for initialization
    void Start ()
    {
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
        }
    }

    void NextState() {

    }

    void Born()
    {
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
        Vector3 startPos = this.transform.position;
        Vector3 targetPos = SelectTarget();
        float journeyLength = Vector3.Distance(startPos, targetPos);
        float fracJourney = this.speed / journeyLength;
        this.transform.position = Vector3.Lerp(startPos, targetPos, fracJourney);
    }

    Vector3 SelectTarget()
    {
        //Vector3 ret = new Vector3(0, 0, 0);

        Vector3 ret = target.transform.position;

        return ret;
    }

    bool IsEnemyBeside()
    {
        bool ret = false;

        return ret;
    }

    bool IsMoveable()
    {
        bool ret = false;

        return ret;
    }

    bool IsActable()
    {
        bool ret = false;

        return ret;
    }
}
