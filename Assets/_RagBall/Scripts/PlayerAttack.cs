

//Description
/* PlayerAttack uses PlayerHealth to interact with other players.
 * The player does not necessarily attack, no damage is dealt.
 * Instead, messages are passed and the physics system takes over.
 * This script needs a player, target, and health scripts for the player and target.
 */


//Declarations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PlayerAttack Class
public class PlayerAttack : MonoBehaviour
{


    //Temporary Variables
    private float AttackTimer;
    public float AttackSpeed = 0.5f;
    public Transform AttackDirection;
    bool ThingInRange;


    //Messaging Variables
    GameObject Target;
    Rigidbody TargetRigidbody;
    PlayerHealth ThisPlayerHealth;
    PlayerMove ThisPlayerMove;


    //Stats Variables
    private float ThrowForce = 4000f;
    private float ArcHeight = 2f;
    private float HoldTime;
    private float HoldTimer;



    private GameObject collidedObject = null;

    //Awake
    void Awake ()
    {
        //TEMP: Reset AttackTimer
        AttackTimer = 0f;

        //Reset HoldTimer
        HoldTimer = 0f;

        //Find Stats
        ThisPlayerHealth = GetComponent<PlayerHealth>();

    }


    //Update
    void Update ()
    {
        //Check for what player wants to do

        //Player wants to grab and is in range
        //Sorry Peter :(
        /*
        if (Input.GetMouseButtonDown(1) && ThingInRange)
        {
            Grab ();
        }
        */

        //Throw with arc
        if (Input.GetMouseButtonDown(1))
        {
            Arc();
        }

        //Player wants to throw
        else if (Input.GetMouseButtonDown(0))
        {
            Throw ();
        }

        collidedObject = Target;
        if (collidedObject != null)
        {
            Grab();
            Vector3 offset = new Vector3(0, 15, 0);
            collidedObject.transform.position = gameObject.transform.position + offset;
            collidedObject.GetComponent<Rigidbody>().freezeRotation = true;
        }
    }


    //Grab
    void Grab ()
    {
        TargetRigidbody = Target.GetComponent<Rigidbody>();
    }


    //Throw
    public void Throw ()
    {
        if (TargetRigidbody != null)
        {
            TargetRigidbody.AddForce(transform.forward * ThrowForce);
            GameObject.Find("ScreamAudio").GetComponent<AudioSource>().Play();
            collidedObject.GetComponent<Rigidbody>().freezeRotation = false;
            collidedObject = null;
            Target = null;
            TargetRigidbody = null;
        }
    }

    public void Arc()
    {
        if (TargetRigidbody != null)
        {
            Vector3 v = transform.forward;
            v.y = ArcHeight;
            TargetRigidbody.AddForce(v * 500);
            GameObject.Find("ScreamAudio").GetComponent<AudioSource>().Play();
            collidedObject.GetComponent<Rigidbody>().freezeRotation = false;
            collidedObject = null;
            Target = null;
            TargetRigidbody = null;
        }
    }


    //ONTRIGGERENTER
    //Checks if something in range is the player
    void OnTriggerEnter(Collider Other)
    {
        if (Other.GetComponent<Collider>().gameObject.layer == 8 || Other.GetComponent<Collider>().gameObject.layer == 9)
        { 
            ThingInRange = true;
            Target = Other.GetComponent<Collider>().gameObject;
            Debug.Log("Hit something");
        }
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.GetComponent<Rigidbody>().gameObject.layer == 8 || Other.gameObject.GetComponent<Rigidbody>().gameObject.layer == 9)
        {
            ThingInRange = true;
            Target = Other.gameObject.GetComponent<Rigidbody>().gameObject;
            Debug.Log("Hit something (CollisionEnter)");
        }
    }

    public void AdjustThrowForce(float f)
    {
        ThrowForce = f;
    }

    public void AdjustArcHeight(float h)
    {
        ArcHeight = h;
    }

}

