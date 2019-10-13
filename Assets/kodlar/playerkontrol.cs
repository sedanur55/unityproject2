using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerkontrol : MonoBehaviour
{
    Rigidbody fizik;
    Vector3 vec;
    public float karakterhız;
    float horizontal = 0;
    float vertical = 0;
    public float minX;
    public float maxX;
    public float maxZ;
    public float minZ;
    public float egim;
    float ateszamanı = 0;
    public float atesgecensure;
    public GameObject kursun;
    public Transform kursunneredencıksın;
    AudioSource audio;


    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        audio= GetComponent<AudioSource>();


    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>ateszamanı) 
        {
            ateszamanı = Time.time + atesgecensure;
            Instantiate(kursun, kursunneredencıksın.position, Quaternion.identity);
            audio.Play();

        }
    }



    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        vec = new Vector3(horizontal, 0, vertical) ;
        fizik.velocity = vec*karakterhız;

        fizik.position = new Vector3
            (

                   Mathf.Clamp(fizik.position.x, minX, maxX),
                0.0f,
                   Mathf.Clamp(fizik.position.z, minZ, maxZ)
            
            );
        fizik.rotation = Quaternion.Euler(0, 0, fizik.position.x*-egim);





    }
}
