using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject ObjectBoss;
    public GameObject ObjectCyborg; 
    Animator _animator;
    CharacterController _controller;

    private float TimePoint0 = 0.0f;
    private float TimePoint1 = 5.0f;
    private float TimePoint2 = 10.0f;
    public float period = 10.0f;

    public float BossSpeed = 1.0f;
    private float distance = 0.0f;




    private Vector3 move = Vector3.zero;



    // Start is called before the first frame update
    void Start()
    {
        _controller = ObjectBoss.GetComponent<CharacterController>();
        _animator = ObjectBoss.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        distance = Vector3.Distance(ObjectBoss.transform.position,
             ObjectCyborg.transform.position);


        if (distance < 100.0f)
        {
            _animator.SetBool("Walking", false);
            _animator.SetBool("Standing", false);
            _animator.SetBool("RightAttack", true);
          
            Reset();
            print("distance smaller than 3");

        }
        else if (Time.time > TimePoint0 && Time.time < TimePoint1)
        {
            _animator.SetBool("Standing", false);
            _animator.SetBool("RightAttack", false);

            Running();
            print("time period one");
        }
        else if (Time.time > TimePoint1 && Time.time < TimePoint2)
        {
            _animator.SetBool("Walking", false);
            _animator.SetBool("Standing", true);
            Shooting();
            print("time period two");

        }
        else if(Time.time> TimePoint2)
        {
            _animator.SetBool("Standing", true);
            Reset();
            print("time period three");
        }
       
    }


    void Running()
    {
        _animator.SetBool("Walking", true);
        move = new Vector3(0, 0, BossSpeed*10);

        move = transform.TransformDirection(move);
        Vector3 LookAtPos = ObjectCyborg.transform.position;
        LookAtPos.y += 10.0f;
        _controller.transform.LookAt(LookAtPos);
        _controller.Move(move * Time.deltaTime);

    }

    void Reset()
    {

        TimePoint0 = Time.time;
        TimePoint1 = Time.time+5.0f;
        TimePoint2 = Time.time + 10.0f;
    }

    void Shooting()
    {
        //rotation += Input.GetAxis("Horizontal");
        //transform.eulerAngles = new Vector3 ()
        //print(ObjectCyborg.transform.position.z);
    }

}
