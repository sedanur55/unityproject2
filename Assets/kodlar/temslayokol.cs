using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temslayokol : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerexplosion;
    GameObject gamecontrol;
    gamecontrol control;

    void Start()
    {

        gamecontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        control = gamecontrol.GetComponent<gamecontrol>();
       

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag != "sinir")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            control.scorearttir(10);

        }

        if(col.tag=="Player")
        {
            Instantiate(playerexplosion, col.transform.position, col.transform.rotation);
            control.gameover();
        }

        
    }
    
 

}
