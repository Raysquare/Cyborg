using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController _controller;
    public float Speed;
    public float Gravity;
    public Vector3 _velocity;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        //if (Input.GetButtonDown("Jump") && )
    }

    void gravityCalculation()
    {
        this._velocity.y += this.Gravity * Time.deltaTime;
        this._controller.Move(_velocity * Time.deltaTime);
    }
}
