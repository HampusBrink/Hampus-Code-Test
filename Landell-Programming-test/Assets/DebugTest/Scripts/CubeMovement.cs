using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CubeMovement : MonoBehaviour
{
    private Rigidbody RB;
    private void Update()
    {
        if (RB == null)
        {
            RB = GetComponent<Rigidbody>();
        }
        
        RB.AddForce(new Vector3(new Random().Next(-5,5),new Random().Next(-5,5),new Random().Next(-5,5)));

        RaycastHit hitinfo;
        Physics.SphereCast(new Ray(transform.position, Vector3.forward),5, out hitinfo);

        if (!hitinfo.transform.CompareTag(this.tag))
        {
            Destroy(this);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(new Vector3(0,100,0));
        }
        
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position+ Vector3.forward * 5, 5);
    }
    
}
