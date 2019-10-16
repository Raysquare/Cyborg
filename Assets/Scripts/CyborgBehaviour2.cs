using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgBehaviour2 : MonoBehaviour
{

    //public GameObject projectilePrefab;

    public float speed;
    public float jumpForce;
    public float rotationSpeed;
    private float rotation;
    public float gravity;
    public GameObject cyborg;
    Vector3 moveDirection = Vector3.zero;

    private float yaw;
    private int forwardNum;
    private int leftRightNum;


    public Rigidbody projectilePrefab;
    private Transform firePoint;

    CharacterController _controller;
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _controller = cyborg.GetComponent<CharacterController>();
        _animator = cyborg.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);


        if (_controller.isGrounded)
        {

            forwardNum = 0;
            leftRightNum = 0;
            if (Input.GetKey(KeyCode.W))
            {
                forwardNum = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                forwardNum = -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                leftRightNum = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                leftRightNum = 1;
            }

            if (forwardNum != 0 || leftRightNum != 0)
            {
                changeDirection(forwardNum, leftRightNum);
            }


            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jumpForce;
                _animator.SetInteger("Condition", 4);
                _animator.SetBool("Jumping", true);

            }
            if (Input.GetMouseButtonDown(0))
            {
                Attack2();
            }



        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _animator.SetBool("Jumping", false);
            _animator.SetInteger("Condition", 0);

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _animator.SetBool("Walking", false);
            _animator.SetBool("Jumping", false);
            moveDirection = new Vector3(0, 0, 0);
            _animator.SetInteger("Condition", 0);
        }
        yaw += rotationSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;

        _controller.Move(moveDirection * Time.deltaTime);
        //this.rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, yaw, 0);


    }



    public void changeDirection(int z, int x)
    {
        moveDirection = new Vector3(x, 0, z);
        moveDirection = moveDirection * speed;
        moveDirection = transform.TransformDirection(moveDirection);
        _animator.SetInteger("Condition", 1);
    }



    //public void Attack()
    //{
    //    _animator.SetBool("Attacking", true);
    //    _animator.SetInteger("Condition", 3);

    //    GameObject projectile = Instantiate<GameObject>(projectilePrefab);
    //    projectile.transform.position = this.gameObject.transform.position + new Vector3(0, 50, 0);
    //}

    public void Attack2()
    {
        _animator.SetBool("Attacking", true);
        _animator.SetInteger("Condition", 3);
        this.firePoint = this.gameObject.transform;
        Rigidbody projectileInstance = Instantiate(projectilePrefab, firePoint.position + new Vector3(0, 50, 0), firePoint.rotation);


    }
}