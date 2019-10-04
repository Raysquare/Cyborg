using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgBehaviour : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
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
        
        if (Input.GetKey(KeyCode.W))
        {
            moveDirection = new Vector3(0,0,1);
            moveDirection = moveDirection * speed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime);
    }
}
