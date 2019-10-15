using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBotGunController : MonoBehaviour
{

    private float timer = 0.0f;
    private float waitTime = 5.0f;
    public GameObject attackBotBullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer > waitTime)
        {
            GameObject projectile = Instantiate<GameObject>(attackBotBullet);
            projectile.transform.position = this.gameObject.transform.position;
            timer = 0.0f;
        }
    }

}
