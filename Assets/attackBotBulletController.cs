using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBotBulletController : MonoBehaviour
{

    public Vector3 velocity;
    public int damageAmount = 50;
    public string tagToDamage;
    //public GameObject startingPoint;


    // Start is called before the first frame update
    void Start()
    {
        /*this.transform.position = startingPoint.transform.position;*/
    }                           

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(velocity * Time.deltaTime);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == tagToDamage)
        {
            // Damage object with relevant tag
            attackBotHealthManager healthManager = col.gameObject.GetComponent<attackBotHealthManager>();
            healthManager.ApplyDamage(damageAmount);

            // Destroy self
            Destroy(this.gameObject);
        }
    }

}
