using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
	
	    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	
	void Update()
	{
		 if (Input.GetKeyUp("space"))
        {
            rb.AddForce(transform.up * thrust);
        }
	}
	
}
