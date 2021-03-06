﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staggerable : MonoBehaviour
{
    // VARIABLES

    /*
    // Logic
    public bool iCanStagger;

    // Torso
    public CharacterJoint Spine_CJ;
    public CharacterJoint Head_CJ;

    // Left
    public ConfigurableJoint ThighL_CJ;
    public ConfigurableJoint ShinL_CJ;

    // Right
    public ConfigurableJoint ThighR_CJ;
    public ConfigurableJoint ShinR_CJ;
    */

    //private RigidbodyConstraints hipsRBC;
    private Rigidbody maHips;
    public PlayerManager ourSavior;
    public int myPlayer = -666;
    private int maSpeed;                        // Pretty Math/Print
    public string grabMode;
    public Animator maAnimator;
    public float angleThreshold = 90f;             // How strictly we want to compare force normals - ANGLES
    public float forceThreshold = 5f;             // How strictly we want to compare force normals - FORCES
    public bool staggered = false;                  // Are we staggered?
    private float daSpeed;                      // Raw Math/Print
    public bool DashDamage = false;             // Do we tell other Staggerable to die?
    String title = "";                          // Fore more useful debug messages


    private void Awake()
    {
        //Debug.Log("STAGGER: READY");
        //hipsRBC = this.gameObject.GetComponent<Rigidbody>().constraints;
        maHips = this.gameObject.GetComponent<Rigidbody>();
        myPlayer = this.gameObject.GetComponent<Grabbable>().myPlayer;
        grabMode = this.gameObject.GetComponent<Grabbable>().grabMode;
        maAnimator = this.gameObject.transform.parent.parent.parent.GetChild(1).GetComponent<animController>().anim;
    }

    public void Stagger()
    {
        //Debug.Log("STAGGER:\n!!!!!!!!!!!!!!!!!!!!!!!!!!!\n!!!!!!!!!!!!!!!!!!!!!");
        maHips.constraints = RigidbodyConstraints.None;
        grabMode = "stunned";
        maAnimator.enabled = false;
        //Debug.Log(hipsRBC);
        staggered = true;
    }

    public void UnStagger()
    {
        //Debug.Log("STAGGER:\n????????????????????????????\n?????????????????????");
        maHips.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //maHips.constraints = RigidbodyConstraints.FreezeRotationY;
        //maHips.constraints = RigidbodyConstraints.FreezeRotationZ;
        maAnimator.enabled = true;
        grabMode = "free";
        //Debug.Log(hipsRBC);
        staggered = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Force Direction: " + collision.contacts[0].normal);

        // Get total velocities of player
        // find overall direction (vector)
        // compare that vector with the collision vector
        // if the difference is less than the threshold
        // do damage
       

        // GET STUFF!
        daSpeed = collision.relativeVelocity.magnitude;
        Vector3 velocities = collision.relativeVelocity;
        ContactPoint contact = collision.contacts[0];
        //Debug.Log("DID THIS WORK?!???: " + contact.point + " X: " + contact.point.x + " Y: " + contact.point.y + " Z: " + contact.point.z);
        Vector3 surface = contact.point;
        float difference = Vector3.Angle(velocities, surface);



        // ANGLES ARE OK!
        if (difference < angleThreshold)
        {
            title = "!!! BIG !!!";

            // REPORT!
            if (daSpeed > 2)
                maSpeed = Convert.ToInt32(daSpeed);
                Debug.Log("\nI HIT SOMETHING OUCH! " + maSpeed + "\n" + "Direction: " + collision.contacts[0].normal);

            // DAMAGE!
            if (maSpeed > forceThreshold)
            {
                ourSavior.DoStagger(myPlayer, maSpeed);
                ourSavior.AudioManager.transform.Find("collision_AudioSource").GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            // else, ignore it, not significant enough
            title = "... small ...";
        }

        // DEBUG
        Debug.Log(  title + "\n" +
                    "Veolcity Vector: " + velocities + "\n" +
                    "Surface Vector: " + surface + "\n" +
                    "Difference: " + difference);

        // Special case, its another player
        if (collision.gameObject.layer == 15)
        {
            /*
            // SEND DASH DAMAGE
            if (DashDamage)
            {

            }

            // GET DASH DAMAGE
            */

            // REPORT!
            if (daSpeed > 2)
                maSpeed = Convert.ToInt32(daSpeed);
            Debug.Log("\nI HIT SOMETHING OUCH! " + maSpeed + "\n" + "Direction: " + collision.contacts[0].normal);

            // DAMAGE!
            if (maSpeed > forceThreshold)
            {
                ourSavior.DoStagger(myPlayer, maSpeed);
                ourSavior.AudioManager.transform.Find("collision_AudioSource").GetComponent<AudioSource>().Play();
            }
        }

    }

    // NOTES
    // Joints
    // https://forum.unity.com/threads/enable-disable-a-joint.24525/
    // https://forum.unity.com/threads/configurable-joints-in-depth-documentation-tutorial-for-dummies.389152/
    // https://docs.unity3d.com/Manual/class-ConfigurableJoint.html
    // https://docs.unity3d.com/Manual/class-CharacterJoint.html
    // https://answers.unity.com/questions/11460/how-do-i-lock-out-a-axis.html
    // Scripts
    // https://answers.unity.com/questions/1412772/how-to-stop-animation-from-playing-in-c.html
    // https://docs.unity3d.com/ScriptReference/Transform.GetChild.html
    // Constraints
    // https://docs.unity3d.com/ScriptReference/Rigidbody-constraints.html
    // Surface Normals
    // https://docs.unity3d.com/ScriptReference/ContactPoint-normal.html
    // https://docs.unity3d.com/ScriptReference/Vector3.html
    // https://docs.unity3d.com/ScriptReference/RaycastHit-normal.html
    // Forces
    // https://answers.unity.com/questions/486771/get-force-applied-on-a-gameobject.html
    // Comparing Angles
    // https://docs.unity3d.com/ScriptReference/Mathf.DeltaAngle.html
    // https://answers.unity.com/questions/1193206/calculate-difference-between-two-3d-angles.html
    // https://docs.unity3d.com/ScriptReference/Vector3.Angle.html
    // Velocities
    // 
}
