using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorjectileController : MonoBehaviour
{
    public int damage;
    public Vector3 velocity;
    public float projectileSpeedFactor;
    public GameObject mainCharacter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotationY = mainCharacter.transform.rotation.y;

        this.velocity = new Vector3((float)Math.Asin(rotationY) * projectileSpeedFactor, 0, (float)(Math.Acos(rotationY) * projectileSpeedFactor));
        this.transform.Translate(this.velocity * Time.deltaTime);
    }
}
