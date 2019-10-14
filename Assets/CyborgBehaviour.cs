using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgBehaviour : MonoBehaviour
{

    public GameObject projectilePrefab;

    public float speed;
    public float jumpForce;
    public float rotationSpeed;
    private float rotation;
    public float gravity;
    public GameObject cyborg;
    Vector3 moveDirection = Vector3.zero;

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

        Movement();
        GetInput();


    }

    public void Movement()
    {
        moveDirection.y -= gravity * Time.deltaTime * 5;
        _controller.Move(moveDirection * Time.deltaTime);


        if (_controller.isGrounded)
        {

            if (Input.GetKey(KeyCode.W))
            {
                changeDirection(1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                changeDirection(-1);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y += jumpForce;
                _animator.SetInteger("Condition", 4);
                _animator.SetBool("Jumping", true);
            }


            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            {
                _animator.SetBool("Running", false);
                moveDirection = new Vector3(0, 0, 0);
                _animator.SetInteger("Condition", 0);
            }
        }

        _controller.Move(moveDirection * Time.deltaTime * 5);
        this.rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, this.rotation, 0);

    }

    public void changeDirection(int x)
    {
        _animator.SetBool("Running", true);
        moveDirection = new Vector3(0, 0, x);
        moveDirection = moveDirection * speed;
        moveDirection = transform.TransformDirection(moveDirection);
        _animator.SetInteger("Condition", 1);
    }

    public void GetInput()
    {
        if (_controller.isGrounded)
        {
            if (Input.GetMouseButton(0))
            {
                if (_animator.GetBool("Running") == true)
                {
                    _animator.SetBool("Running", false);
                    _animator.SetInteger("Condition", 0);
                }
                else if (_animator.GetBool("Running") == false)
                {
                    Attack();
                }

            }


        }
        

    }

    public void Attack()
    {
        _animator.SetBool("Attacking", true);
        _animator.SetInteger("Condition", 3);
        GameObject projectile = Instantiate<GameObject>(projectilePrefab);
        projectile.transform.position = this.gameObject.transform.position;
    }

    public IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(1);
    }
}
