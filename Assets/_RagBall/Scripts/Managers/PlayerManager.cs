﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure; // Required in C#




/*
 *                      ATTENTION!
 *                      
 *             ABBANDON ALL HOPE YE WHOMST ENTER!
 *             BEWARE, THIS BE THE DREADED...
 *                                                                                                        
                                                                                                                 
        GGGGGGGGGGGGG     OOOOOOOOO     DDDDDDDDDDDDD                                                            
     GGG::::::::::::G   OO:::::::::OO   D::::::::::::DDD                                                         
   GG:::::::::::::::G OO:::::::::::::OO D:::::::::::::::DD                                                       
  G:::::GGGGGGGG::::GO:::::::OOO:::::::ODDD:::::DDDDD:::::D                                                      
 G:::::G       GGGGGGO::::::O   O::::::O  D:::::D    D:::::D                                                     
G:::::G              O:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G              O:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G    GGGGGGGGGGO:::::O     O:::::O  D:::::D     D:::::D                                                    
------------------------------------------------------------------ god is dead                                              
G:::::G    GGGGG::::GO:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G        G::::GO:::::O     O:::::O  D:::::D     D:::::D                                                    
 G:::::G       G::::GO::::::O   O::::::O  D:::::D    D:::::D                                                     
  G:::::GGGGGGGG::::GO:::::::OOO:::::::ODDD:::::DDDDD:::::D                                                      
   GG:::::::::::::::G OO:::::::::::::OO D:::::::::::::::DD                                                       
     GGG::::::GGG:::G   OO:::::::::OO   D::::::::::::DDD                                                         
        GGGGGG   GGGG     OOOOOOOOO     DDDDDDDDDDDDD                                                            
                                                                                                                 
                                                                                                                 
                                                                        
                                                                                                                 
                                                                                                                 
   SSSSSSSSSSSSSSS         CCCCCCCCCCCCCRRRRRRRRRRRRRRRRR   IIIIIIIIIIPPPPPPPPPPPPPPPPP   TTTTTTTTTTTTTTTTTTTTTTT
 SS:::::::::::::::S     CCC::::::::::::CR::::::::::::::::R  I::::::::IP::::::::::::::::P  T:::::::::::::::::::::T
S:::::SSSSSS::::::S   CC:::::::::::::::CR::::::RRRRRR:::::R I::::::::IP::::::PPPPPP:::::P T:::::::::::::::::::::T
S:::::S     SSSSSSS  C:::::CCCCCCCC::::CRR:::::R     R:::::RII::::::IIPP:::::P     P:::::PT:::::TT:::::::TT:::::T
S:::::S             C:::::C       CCCCCC  R::::R     R:::::R  I::::I    P::::P     P:::::PTTTTTT  T:::::T  TTTTTT
S:::::S            C:::::C                R::::R     R:::::R  I::::I    P::::P     P:::::P        T:::::T        
 S::::SSSS         C:::::C                R::::RRRRRR:::::R   I::::I    P::::PPPPPP:::::P         T:::::T        
  SS::::::SSSSS    C:::::C                R:::::::::::::RR    I::::I    P:::::::::::::PP          T:::::T        
    SSS::::::::SS  C:::::C                R::::RRRRRR:::::R   I::::I    P::::PPPPPPPPP            T:::::T        
       SSSSSS::::S C:::::C                R::::R     R:::::R  I::::I    P::::P                    T:::::T        
            S:::::SC:::::C                R::::R     R:::::R  I::::I    P::::P                    T:::::T        
            S:::::S C:::::C       CCCCCC  R::::R     R:::::R  I::::I    P::::P                    T:::::T        
SSSSSSS     S:::::S  C:::::CCCCCCCC::::CRR:::::R     R:::::RII::::::IIPP::::::PP                TT:::::::TT      
S::::::SSSSSS:::::S   CC:::::::::::::::CR::::::R     R:::::RI::::::::IP::::::::P                T:::::::::T      
S:::::::::::::::SS      CCC::::::::::::CR::::::R     R:::::RI::::::::IP::::::::P                T:::::::::T      
 SSSSSSSSSSSSSSS           CCCCCCCCCCCCCRRRRRRRR     RRRRRRRIIIIIIIIIIPPPPPPPPPP                TTTTTTTTTTT      
                                                                                                                 
                                                                                           
 *               
 *             MUA HAHAHAHAHAHAHAHA HHAHAHAHA HAH HAH AHA HAH HAH 
 *                   AAAAAAAHAHAHHHHHH HA HAHAHA HAH AH HA HAHA HA HA
 *                          HHAHAH AH HAH HAH AH 
 *                                  HA HA HA HA H
 *                                      HAHA
 *                              
 *                                           HA 
 *                              
 *                                               ...
 *                              
 *                                                   HA..................
 * 
 */












//namespace LocalCoop {
/// <summary>
/// A manager that can be used to add players without having pre-assigned controlled ID's to the input
/// </summary>
public class PlayerManager : MonoBehaviour {

    // ControllerVariables
    PlayerIndex controllerID1;
    PlayerIndex controllerID2;
    PlayerIndex controllerID3;
    PlayerIndex controllerID4;
    GamePadState controller1state;
    GamePadState controller2state;
    GamePadState controller3state;
    GamePadState controller4state;

    // PlayerArrayVariables
    public GameObject[] players = new GameObject[4];
    GamePadState[] GamePadStates;
    public Animator[] Animators;
    public Transform[] RotatePlayers;
    public Transform[] Pivots;
    private PlayerIndex[] PlayerIndexes;
    public GameObject[,] PlayerHands;
    public GameObject[] PlayerHips;

    // Stagger Variables
    public Staggerable[] Staggers;              // Who is being staggered?
    public bool[] Staggered;                    // Can the player do anything?
    private bool SomeoneIsStaggered;            // WHAT THE FUCK IS THIS FRANK!?!?!?!?!?!?
    private bool SomeoneWasStaggered;           // TELL ME RIGHT NOW!!!!!! EERRRRRRGGGGGGGGG!!!!!
    public float StaggerThreshold = 20f;        // How strictly do we measure stagger cases? - this is in degrees of difference
    public float SuperDashTime = 0.5f;          // Time interal a player deals megadamage to another player - TARGET
    public float[] SuperDashTimer;              // Time interal a player deals megadamage to another player - TIMER
    public bool[] SuperDash;                    // Who is currently doing this
    public int SuperDashDamage = 100;           // How much to scale speed by on dash attack


    // Movement Variables
    public int[] Dashes;            // How many dashes player has (0 - 5) - Shared with Jump
    public float[] DashTimes;       // Time until next recovered dash (3 seconds)
    public int[] Staminas;          // How much stamina player has (0 - 100)
    public float[] StaminaTimes;    // Time until next recovered stamina point (0.3 seconds)
    public float StaminaTime = 0.3f;  // How long to wait to recover stamina
    public bool[] LeftFoot;         // is the leftfoot good to go? - jumping
    public bool[] RightFoot;        // Is the rightfoot good to go? - jumping
    private float[] movementForce;  // How much force you move with
    public int MaxStamina = 50;
    public int MinStamina = 10;
    public int RangeStamina = 5;

    // ButtonArrayVariables
    private bool[] AwasPressed;
    private bool[] BwasPressed;
    private bool[] YwasPressed;
    private bool[] YisRagdolling;
    private bool[] XwasPressed;
    private bool[] StartwasPressed;
    private bool[] RightwasPressed;
    private bool[] LeftwasPressed;
    private bool[] BackwasPressed;
    private bool LwasPressed = false;
    private bool MwasPressed = false;
    private bool[] motionEnabled;

    // RespawnObjectVariables
    public GameObject RedPlayer;
    public GameObject BluePlayer;
    public GameObject RespawnPoint;
    public GameObject AnimatorRespawnPoint;
    public ScoreManager scoremanager;
    public Dynamic_Cam DynamicCamera;
    public bool GameIsPaused;

    //PER PLAYER
    //public Animator animator1;
    //public Transform rotatePlayer1;
    //public Transform pivot1;
    //public Animator animator2;
    //public Transform rotatePlayer2;
    //public Transform pivot2;
    //public Animator animator3;
    //public Transform rotatePlayer3;
    //public Transform pivot3;
    public GameObject StaminaUI;

    // GrabbingStuffVariables
    GameObject theGrabbler;         // Who is Grabbling
    GameObject maHips;              // The Player's Hips
    Grabbable maGrabbable;          // The Player's Grabbable Component
    GameObject theirHips;           // The Enemy's Hips
    Grabbable theirGrabbable;       // The Enemy's Grabbable Component
    Transform yerMommy;             // The Player's Empty
    Staggerable theirStaggerable;   // Enemy staggerable
    bool theyAreGrabbable = false;  // Enemy grabbability boolean

    // XInputVariables
    public bool use_X_Input = true;
    public int connectedControllers = 0;   //if this variable changes, we need to call an update on the gamepads
    public static PlayerManager singleton = null;
    public bool KeysEnabled = false;

    // PauseControlVariables
    public Canvas PauseMenu;
    public Canvas ParameterCanvas;
    public Image[] Stamina_Heads;
    public Sprite[] StaminaPics;
    public GameObject AudioManager;
    public float dashForce = 10000f;
    public float PlayerSpeed = 3000f;
    public float jumpForce = 10000;
    public float throwSpeed = 13000f;

    void Awake() {
        //Check if instance already exists
        if (singleton == null) {
            //if not, set instance to this
            singleton = this;
        }

        //If instance already exists and it's not this:
        else if (singleton != this) {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        connectedControllers = CheckControllerAmount();
        Assign_X_Input_Controllers();

        GamePadStates = new GamePadState[] 
        {
            controller1state,
            controller2state,
            controller3state,
            controller4state,
        };

        PlayerIndexes = new PlayerIndex[] 
        {
            controllerID1,
            controllerID2,
            controllerID3,
            controllerID4,
        };

        //Player 1: [0 0] [0 1]
        //Player 2: [1 0] [1 1]
        //Player 3: [2 0] [2 1]
        //Player 4: [3 0] [3 1]
        PlayerHands = new GameObject[,]
        {
            { players[0].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[0].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
            { players[1].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[1].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
            { players[2].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[2].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
            { players[3].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[3].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
        };

        LeftFoot = new bool[]
        {
            false,
            false,
            false,
            false
        };

        SuperDash = new bool[]
        {
            false,
            false,
            false,
            false
        };

        RightFoot = new bool[]
        {
            false,
            false,
            false,
            false
        };

        SuperDashTimer = new float[]
{
            0.5f,
            0.5f,
            0.5f,
            0.5f,
};

        movementForce = new float[]
        {
            1000f,
            1000f,
            1000f,
            1000f,
        };

        motionEnabled = new bool[]
        {
            true,
            true,
            true,
            true,
        };

        PlayerHips = new GameObject[] 
        {
            players[0].transform.Find("Player/metarig/hips").gameObject,
            players[1].transform.Find("Player/metarig/hips").gameObject,
            players[2].transform.Find("Player/metarig/hips").gameObject,
            players[3].transform.Find("Player/metarig/hips").gameObject,
        };

        Dashes = new int[] 
        {
            5,
            5,
            5,
            5,
        };

        DashTimes = new float[]
        {
            3,
            3,
            3,
            3,
        };

        Staminas = new int[] 
        {
            MaxStamina,
            MaxStamina,
            MaxStamina,
            MaxStamina,
        };

        Staggers = new Staggerable[]
        {
            players[0].transform.Find("Player/metarig/hips").gameObject.GetComponent<Staggerable>(),
            players[1].transform.Find("Player/metarig/hips").gameObject.GetComponent<Staggerable>(),
            players[2].transform.Find("Player/metarig/hips").gameObject.GetComponent<Staggerable>(),
            players[3].transform.Find("Player/metarig/hips").gameObject.GetComponent<Staggerable>(),
        };

        Staggered = new bool[]
        {
            false,
            false,
            false,
            false,
        };

        StaminaTimes = new float[]
        {
            StaminaTime,
            StaminaTime,
            StaminaTime,
            StaminaTime,
        };

        AwasPressed = new bool[]
        {
            false,
            false,
            false,
            false,
        };

        BwasPressed = new bool[] 
        {
            false,
            false,
            false,
            false,
        };

        YwasPressed = new bool[] 
        {
            false,
            false,
            false,
            false,
        };

        YisRagdolling = new bool[]
        {
            false,
            false,
            false,
            false,
        };

        XwasPressed = new bool[]
        {
            false,
            false,
            false,
            false,
        };

        StartwasPressed = new bool[]
        {
            false,
            false,
            false,
            false,
        };


        RightwasPressed = new bool[]
        {
            false,
            false,
            false,
            false,
        };

        LeftwasPressed = new bool[]
        {
            false,
            false,
            false,
            false,
        };
        BackwasPressed = new bool[]
        {
            false,
            false,
            false,
            false,
        };

        SomeoneIsStaggered = false;
        SomeoneWasStaggered = false;
    }

    void Assign_X_Input_Controllers()
    {
        for (int i = 0; i < 4; ++i)
        {
            PlayerIndex controllerID = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(controllerID);
            if (testState.IsConnected)
            {
                switch (i)
                {
                    case 0:
                        controllerID1 = controllerID;
                        controller1state = testState;
                        break;
                    case 1:
                        controllerID2 = controllerID;
                        controller2state = testState;
                        break;
                    case 2:
                        controllerID3 = controllerID;
                        controller3state = testState;
                        break;
                    case 3:
                        controllerID4 = controllerID;
                        controller4state = testState;
                        break;
                    default:
                        break;
                }

                //Debug.Log(string.Format("GamePad found {0}", controllerID));
            }
        }
    }

    //Checks if the amount of controllers changed when connecting/unplugging new controllers
    int CheckControllerAmount()
    {
        int amount = 0;

        for (int i = 0; i < 4; ++i)
        {
            PlayerIndex controllerID = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(controllerID);
            if (testState.IsConnected)
            {
                amount++;
            }
        }

        return amount;
    }


    public void respawn(int pNumber)
    {
        GameObject newPlayer;

        //Spawn Blue Player
        if (pNumber % 2 == 1)
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //newPlayer = BluePlayer;
            newPlayer = Instantiate(BluePlayer, RespawnPoint.transform.position, Quaternion.identity);
            newPlayer.GetComponent<PlayerModel>().PlayerColor = "blue";
        }
        //Spawn Red Player
        else
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //newPlayer = RedPlayer;
            newPlayer = Instantiate(RedPlayer, RespawnPoint.transform.position, Quaternion.identity);
            newPlayer.GetComponent<PlayerModel>().PlayerColor = "red";
        }

        //Destroy old stuff
        DynamicCamera.targets.Remove(players[pNumber].transform.Find("Player/Pivot"));
        Destroy(players[pNumber]);

        // Assign new stuff
        newPlayer.transform.Find("MediumStaticAnimator").transform.position = AnimatorRespawnPoint.transform.position;
        //newPlayer.transform.position = RespawnPoint.transform.position;
        players[pNumber] = newPlayer;
        Animators[pNumber] = newPlayer.transform.Find("MediumStaticAnimator").GetComponent<Animator>();
        RotatePlayers[pNumber] = newPlayer.transform.Find("Player").transform;
        Pivots[pNumber] = newPlayer.transform.Find("Pivot");
        newPlayer.GetComponent<PlayerModel>().PlayerNumber = pNumber;
        newPlayer.transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(0, -2500, 0);
        newPlayer.GetComponent<PlayerModel>().playermanager = this;
        newPlayer.GetComponent<PlayerModel>().scoremanager = scoremanager;
        PlayerHands[pNumber, 0] = newPlayer.transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject;
        PlayerHands[pNumber, 1] = newPlayer.transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject;
        PlayerHips[pNumber] = newPlayer.transform.Find("Player/metarig/hips").gameObject;
        newPlayer.name = "Player" + (pNumber + 1).ToString();
        newPlayer.transform.Find("Player/metarig/hips/").gameObject.GetComponent<Grabbable>().myPlayer = pNumber;
        GameObject theHips = newPlayer.transform.Find("Player/metarig/hips/").gameObject;
        //Debug.Log("Player's Hips are: " + theHips.GetComponent<Grabbable>().myPlayer.ToString());

        // Update Camera
        DynamicCamera.targets.Add(newPlayer.transform.Find("Player/Pivot"));

        // Refresh Movement
        Dashes[pNumber] = 5;
        DashTimes[pNumber] = 3;
        LeftFoot[pNumber] = false;
        RightFoot[pNumber] = false;

        // Refresh Stagger
        Staggered[pNumber] = false;
        Staminas[pNumber] = MaxStamina;
        StaminaTimes[pNumber] = StaminaTime;

        // Refresh their staggerable
        Staggers[pNumber] = PlayerHips[pNumber].GetComponent<Staggerable>();
        Staggers[pNumber].ourSavior = this;
        Staggers[pNumber].myPlayer = pNumber;
        Staggers[pNumber].angleThreshold = StaggerThreshold;

        // Refresh their SuperDash
        SuperDash[pNumber] = false;
        SuperDashTimer[pNumber] = 0.5f;
    }

    public void Grab()
    {
        // theGrabbler - Who is trying to grab
        // maHips - How we reference who is trying to grab
        // maGrabbable - Who is being grabbed
        // theirHips - How we reference who is being grabbed
        // theirGrabbable - How we enable/disable the victim

        // https://answers.unity.com/questions/989146/how-to-attach-an-object-onto-another-object.html
        // https://answers.unity.com/questions/983433/how-to-freeze-z-axis-rotation-in-code.html
        // https://answers.unity.com/questions/1368164/cannot-get-rigidbody-constraint-to-unfreeze.html

        // Ok, now th players are inexplicably drifting
        // I think this is why:
        // https://answers.unity.com/questions/1128326/object-drifting-to-left-or-right-without-reason.html

        // The other cause could be:
        // https://docs.unity3d.com/ScriptReference/Rigidbody-isKinematic.html

        //Debug.Log("We really tryin grab here!");

        //Check if he can grab
        //if ((maHips.GetComponent<Grabbable>().iCanGrab == true) && (theirHips != null) && theyAreGrabbable)
        if ((maHips.GetComponent<Grabbable>().iCanGrab == true) && (theirHips != null))
            {
            // DEBUG
            Debug.Log("And here we go");

            // Move 'im up
            theirHips.transform.position = maHips.transform.position;
            Transform newTransform = maHips.transform;
            //theirHips.transform.Translate(0f, 1.5f, 0f);
            theirHips.transform.position = maHips.transform.position + maHips.transform.TransformDirection(0f,1.5f,0f);

            //Find da parent
            yerMommy = theirHips.transform.parent;

            // Lock 'im in, Yup!
            theirGrabbable.iCanGrab = false;
            theirHips.transform.parent = maHips.transform;
            theirHips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            //theirHips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            //theirHips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
            theirHips.GetComponent<Rigidbody>().isKinematic = true;

            //Fix the mode!
            maGrabbable.grabMode = "grabbing";
        }
        else
        {
            Debug.Log("OHHHHHHHHHHH NOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        // NOTES
        // Move object relative to another
        // https://answers.unity.com/questions/1125044/how-do-i-move-an-object-relative-to-another-object.html

    }


    public void Throw()
    {
        // GameObject theGrabbler - Who is trying to grab
        // GameObject maHips - How we reference who is trying to grab
        // Grabbable maGrabbable - Who is being grabbed
        // GameObject theirHips - How we reference who is being grabbed
        // Grabbable theirGrabbable - How we enable/disable the victim

        // Can we throw?
        if (maGrabbable.grabMode.Equals("grabbing"))
        {

            // Alert
            Debug.Log("THROW IT!!!!!");

            // Unkinemasicize thad guy
            theirHips.transform.parent = yerMommy;
            theirHips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            theirHips.GetComponent<Rigidbody>().isKinematic = false;

            // Applicaticize this here force on thad thar fella's pelvis
            theirHips.GetComponent<Rigidbody>().AddForce(maHips.transform.forward * throwSpeed);

            // Reset thar grabblerability
            theirGrabbable.iCanGrab = true;

            // Fix the mode!
            maGrabbable.grabMode = "free";
            maGrabbable.oldHips = null;

            // Play audio
            AudioManager.transform.Find("Throw_AudioSource").GetComponent<AudioSource>().Play();
            AudioManager.transform.Find("Dash_AudioSource").GetComponent<AudioSource>().Play();

            //Reset tha stuffs
            theGrabbler = null;
            maHips = null;
            maGrabbable = null;
            theirHips = null;
            theirGrabbable = null;
        }

    }

    public void ThrowArc()
    {
        // GameObject theGrabbler - Who is trying to grab
        // GameObject maHips - How we reference who is trying to grab
        // Grabbable maGrabbable - Who is being grabbed
        // GameObject theirHips - How we reference who is being grabbed
        // Grabbable theirGrabbable - How we enable/disable the victim

        if (maGrabbable.grabMode == "grabbing")
        {

            // Alert
            Debug.Log("THROW IT!!!!!");

            // Unkinemasicize thad guy
            theirHips.transform.parent = yerMommy;
            theirHips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            theirHips.GetComponent<Rigidbody>().isKinematic = false;

            // Applicaticize this here force on thad thar fella's pelvis
            theirHips.GetComponent<Rigidbody>().AddForce((maHips.transform.forward + maHips.transform.up) * (throwSpeed / 2));

            // Reset thar grabblerability
            theirGrabbable.iCanGrab = true;

            // Fix the mode!
            maGrabbable.grabMode = "free";
            maGrabbable.oldHips = null;

            // Play audio
            AudioManager.transform.Find("Throw_AudioSource").GetComponent<AudioSource>().Play();
            AudioManager.transform.Find("Dash_AudioSource").GetComponent<AudioSource>().Play();

            //Reset tha stuffs
            theGrabbler = null;
            maHips = null;
            maGrabbable = null;
            theirHips = null;
            theirGrabbable = null;
        }

    }


    public void Drop()
    {
        // GameObject theGrabbler - Who is trying to grab
        // GameObject maHips - How we reference who is trying to grab
        // Grabbable maGrabbable - Who is being grabbed
        // GameObject theirHips - How we reference who is being grabbed
        // Grabbable theirGrabbable - How we enable/disable the victim


        // Unkinemasticize thad guy
        theirHips.transform.parent = yerMommy;
        theirHips.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        theirHips.GetComponent<Rigidbody>().isKinematic = false;

        // Reset thar grabblerability
        theirGrabbable.iCanGrab = true;

        //Fix the mode!
        maGrabbable.grabMode = "free";
        maGrabbable.oldHips = null;
    }

    public void GrabDecide()
    {
        // GameObject theGrabbler - Who is trying to grab
        // GameObject maHips - How we reference who is trying to grab
        // Grabbable maGrabbable - Who is being grabbed
        // GameObject theirHips - How we reference who is being grabbed
        // Grabbable theirGrabbable - How we enable/disable the victim


        // Pick a poison
        if (maGrabbable.grabMode.Equals("free"))
        {
            Debug.Log("Imma try grabbin!");
            Grab();
            //Debug.Log("EEEERRRRRRAAAAAARRRRGGRGRGRGRGRG!GG!G!G!G!GG!G!G!!\n\n\n\n\n!!!!!!!!");
        }
        else if (maGrabbable.grabMode.Equals("grabbing"))
        {
            Debug.Log("Imma let go now!");
            Drop();
        }
        else
        {
            Debug.Log("What did you do??!?!!?\nThat mode of grabbing may not exist yet!");
        }

        //Reset tha stuffs
        theGrabbler = null;
        maHips = null;
        maGrabbable = null;
        theirHips = null;
        theirGrabbable = null;
    }

    /*
     * 
     * OK, so generics inside CSharp frickin suck.
     * Globals it is, fellas.
     * 
     * 
    public List<T> GrabInfo<T> (int Grabbler)
    {
        // Find Yer Stuff
        // I was copying this code a lot, so here is a method to provide parameters
        // https://learn.unity.com/tutorial/generics#5c8923c5edbc2a113b6bc335

        GameObject theGrabbler = players[Grabbler];
        GameObject maHips = theGrabbler.transform.Find("Player/metarig/hips/").gameObject;
        Grabbable maGrabbable = maHips.GetComponent<Grabbable>();
        GameObject theirHips = maGrabbable.theirHips;
        Grabbable theirGrabbable = theirHips.GetComponent<Grabbable>();
        return new List<T>() { theGrabbler, maHips, maGrabbable, theirHips, theirGrabbable };
    }
    */

    public void UpdateGrabInfo(int Grabbler)
    {
        Debug.Log("Trying to get sum stats!");

        //grabbler = player that is grabbing
        theGrabbler = players[Grabbler];
        //maHips = the grabbing player's hips
        maHips = theGrabbler.transform.Find("Player/metarig/hips/").gameObject;
        //maGrabbable = Grabbable script attached to grabbing player's hips
        maGrabbable = maHips.GetComponent<Grabbable>();
        try
        {
            theirHips = maGrabbable.tharHips;
            theirGrabbable = theirHips.GetComponent<Grabbable>();
            theirStaggerable = theirHips.GetComponent<Staggerable>();
            theyAreGrabbable = theirStaggerable.staggered;
        }
        catch
        {
            try
            { 
            theirHips = maGrabbable.oldHips;
            theirGrabbable = theirHips.GetComponent<Grabbable>();
            }
            catch
            {
                Debug.Log("Sorry charlie, youre just outa luck!");
            }
        }
        Debug.Log("And I sur' hope I can see this!");
    }


    public void DoStagger(int aPlayerNum, int daSpeed)
    {
        //Debug.Log("daSpeed: " + daSpeed);
        Staminas[aPlayerNum] -= daSpeed;
    }




    //TIME CHANGER
    //Updates any timers you want to use
    //dashes[i] corresponds to players[i] and is an integer array of remaining dashes (0 - None, 5 - Max)
    //staminas[i] corresponds to players[i] and is an float array of remaining balance (0 - None, 100 - Max)
    //dashtimes[i] corresponds to players[i] and is a float array of time until a dash is added
    //staminatimes[i] corresponds to players[i] and is a float array of time until balance is added
    private void UpdateTimers()
    {
        for (int i = 0; i < 4; i++)
        {
            // DASHING
            // Update Time
            DashTimes[i] -= Time.deltaTime;
            // Update Count
            if (DashTimes[i] <= 0 && Dashes[i] < 5)
            {
                Dashes[i] += 1;
                DashTimes[i] = 3;
            }
            else if (Dashes[i] == 5)
            {
                DashTimes[i] = 3;
            }
            // Update UI
            Stamina_Heads[i].sprite = StaminaPics[Dashes[i]];


            // SUPERDASHDAMAGE
            SuperDashTimer[i] -= Time.deltaTime;
            if (SuperDashTimer[i] <= 0f)
            {
                SuperDash[i] = false;       // Notify PlayerManager
                SuperDashTimer[i] = 0f;     // Reset the Timer
                PlayerHips[i].GetComponent<Staggerable>().DashDamage = false;       // Notify Staggerable component
            }



            // STAGGER RECOVERY
            // Stamina is recovered every two seconds
            // You need 5 stamina to stand up
            // Update Time
            StaminaTimes[i] -= Time.deltaTime;
            // Update Count (Time)r
            if ((StaminaTimes[i] <= 0) && (Staminas[i] < MaxStamina))
            {
                Staminas[i] += 1;
                StaminaTimes[i] = StaminaTime;
            }
            else if (Staminas[i] >= MaxStamina)
            {
                StaminaTimes[i] = StaminaTime;
            }
            // Debug
            //Debug.Log("Stamina: " + Staminas[i]);
            // Update Staggerness
            // https://docs.unity3d.com/ScriptReference/Collision-relativeVelocity.html

            // Update Is Staggered
            if ((Staminas[i] < MinStamina + 1) && (!Staggered[i]))
            {
                Staggers[i].Stagger();
                Staggered[i] = true;
            }
            else if ((Staminas[i] >= MinStamina) && (Staggered[i]))
            {
                Staggers[i].UnStagger();
                Staggered[i] = false;
            }
            if (Staminas[i] < (MinStamina - 2))
            {
                Staminas[i] = MinStamina;
            }
            //Debug.Log("Player 1 Staminas: " + Staminas[0]);
        }
    }



    public class MovementPair
    {
        public float H;
        public float V;
    }


    private MovementPair KeyboardControls(MovementPair movementPair)
    {
        // https://answers.unity.com/questions/514932/multiple-parameter.html


        // KeyboardMovement (for Player 3 [i=2])
        // (A/D) Horizontal
        if (Input.GetKeyDown("a") && !Input.GetKeyDown("d"))
        {
            movementPair.H = 1;
        }
        else if (!Input.GetKeyDown("a") && Input.GetKeyDown("d"))
        {
            movementPair.H = -1;
        }
        else
        {
            movementPair.H = 0;
        }
        // (W/S) Vertical
        if (Input.GetKeyDown("d") && !Input.GetKeyDown("a"))
        {
            movementPair.V = 1;
        }
        else if (Input.GetKeyDown("a") && !Input.GetKeyDown("d"))
        {
            movementPair.V = -1;
        }
        else
        {
            movementPair.V = 0;
        }
        /*
        // (E) Grab
        if (GamePadStates[i].Buttons.X == ButtonState.Pressed && !XwasPressed[i])
        {
            XwasPressed[i] = true;
            Debug.Log("X Button was pressed!");
            UpdateGrabInfo(i);
            GrabDecide();
        }
        else if (GamePadStates[i].Buttons.X == ButtonState.Released && XwasPressed[i])
        {
            XwasPressed[i] = false;
        }
        */
        // (Q) Throw
        // (P) Pause
        // (F) Jump
        // (Shift) Dash

        // Done
        return movementPair;
    }


    MovementPair movementPair = new MovementPair();


    // Update is called once per frame
    void Update() {

        // ControllerAssigner
        if (use_X_Input) {
            if (connectedControllers != CheckControllerAmount()) {
                connectedControllers = CheckControllerAmount();
                print("update controllers");
                Assign_X_Input_Controllers();
            }

            if (controller1state.IsConnected) {
                controller1state = GamePad.GetState(controllerID1);
                if (controller1state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 0 pressed start");
                    //you can call a function here to instantiate a player and then assign this ID to the player input's script to connect the player to the controller that pressed start for example
                    //you then also need to assign that player input script to one of the X input modules to connect it with unity's input system
                }
            }

            if (controller2state.IsConnected) {
                controller2state = GamePad.GetState(controllerID2);
                if (controller2state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 1 pressed start");
                }
            }

            if (controller3state.IsConnected) {
                controller3state = GamePad.GetState(controllerID3);
                if (controller3state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 2 pressed start");
                }
            }

            if (controller4state.IsConnected) {
                controller4state = GamePad.GetState(controllerID4);
                if (controller4state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 3 pressed start");
                }
            }

            //check if anyone is staggered and update booleans
            SomeoneIsStaggered = false;
            for (int i = 0; i < 4; i++)
            {
                if (Staggered[i])
                {
                    SomeoneIsStaggered = true;
                    break;
                }
            }


            //update staggered sounds according to booleans
            if (SomeoneIsStaggered && !SomeoneWasStaggered)
            {
                AudioManager.transform.Find("Staggered_AudioSource").GetComponent<AudioSource>().Play();
            }
            else if (SomeoneWasStaggered && !SomeoneIsStaggered)
            {
                AudioManager.transform.Find("Staggered_AudioSource").GetComponent<AudioSource>().Stop();
            }
            SomeoneWasStaggered = SomeoneIsStaggered;



            //vvv
            // ControllerMotionTranslator
            for (int i = 0; i < 4; i++)
            {
                /*
                Debug.Log("RUNNING: PlayerHips" + "\n" +
                            "Player 1: " + PlayerHips[0] + "\n" +
                            "Player 2: " + PlayerHips[1] + "\n" +
                            "Player 3: " + PlayerHips[2] + "\n" +
                            "Player 4: " + PlayerHips[3]);
                */

                // Update settings per player
                Staggers[i].angleThreshold = StaggerThreshold;




                if (motionEnabled[i])
                { 
                    movementPair.H = GamePadStates[i].ThumbSticks.Left.X + GamePadStates[i].ThumbSticks.Right.X;
                    movementPair.V = GamePadStates[i].ThumbSticks.Left.Y + GamePadStates[i].ThumbSticks.Right.Y;
                }
                //movement
                Vector3 Movement = new Vector3();


                if (KeysEnabled)
                { 
                    movementPair = KeyboardControls(movementPair);
                    Movement.Set(movementPair.H, 0f, movementPair.V);
                    Movement = Movement.normalized * 2 * Time.deltaTime;
                    PlayerHips[2].GetComponent<Rigidbody>().AddForce(Movement * movementForce[i]);
                }
                if(motionEnabled[i] && !Staggered[i])
                {
                    Movement.Set(movementPair.H, 0f, movementPair.V);
                    Movement = Movement.normalized * 2 * Time.deltaTime;
                    //players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(Movement * PlayerSpeed);
                    PlayerHips[i].GetComponent<Rigidbody>().AddForce(Movement * PlayerSpeed);
                    //RotatePlayers[i].transform.position = players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").transform.position;
                }




                //turning (also causes model to lean back a bit)
                if (Movement != Vector3.zero)
                {
                    PlayerHips[i].transform.forward = Movement;
                }

                //animations
                if (Movement.magnitude >= 0.03)
                {
                    Animators[i].Play("Walk");
                }
                else
                {
                    Animators[i].Play("Idle");
                }

                //buttons
                if (GamePadStates[i].IsConnected)
                {

                    // Load States
                    GamePadStates[i] = GamePad.GetState(PlayerIndexes[i]);


                    //A (jumping)
                    if ((GamePadStates[i].Buttons.A == ButtonState.Pressed) && !PauseMenu.enabled && !AwasPressed[i] && !Staggered[i] && (Dashes[i] > 0))
                    {
                        LeftFoot[i] = PlayerHips[i].transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
                        RightFoot[i] = PlayerHips[i].transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
                        if (LeftFoot[i] && RightFoot[i])
                        { 
                            Animators[i].Play("JumpHold");
                            AwasPressed[i] = true;
                        }
                        Debug.Log("A Button was pressed!");
                    }
                    else if (GamePadStates[i].Buttons.A == ButtonState.Released && AwasPressed[i] && !PauseMenu.enabled && Dashes[i] > 0 && !Staggered[i] && (Dashes[i] > 0))
                    {
                        print("Fuck you anyway");
                        AudioManager.transform.Find("Jump_AudioSource").GetComponent<AudioSource>().Play();
                        Vector3 boostDir = PlayerHips[i].transform.up;
                        PlayerHips[i].GetComponent<Rigidbody>().AddForce(boostDir * jumpForce);
                        Dashes[i] -= 1;
                        if (Dashes[i] < 0)
                        {
                            Dashes[i] = 0;
                        }
                        AwasPressed[i] = false;
                    }


                    //B (dashing)
                    if (GamePadStates[i].Buttons.B == ButtonState.Pressed && !BwasPressed[i] && !GameIsPaused && (Dashes[i] > 0) && !Staggered[i])
                    {
                        SuperDash[i] = true;                                                // Notify playermanager
                        SuperDashTimer[i] = SuperDashTime;                                  //Reset the timer
                        PlayerHips[i].GetComponent<Staggerable>().DashDamage = true;        // Notify Staggerable component
                        BwasPressed[i] = true;
                        Debug.Log("B Button was pressed!");
                        Vector3 boostDir = PlayerHips[i].transform.forward;
                        PlayerHips[i].GetComponent<Rigidbody>().AddForce(boostDir * dashForce);
                        Dashes[i] -= 1;
                        if (Dashes[i] < 0)
                        {
                            Dashes[i] = 0;
                        }
                        AudioManager.transform.Find("Dash_AudioSource").GetComponent<AudioSource>().Play();
                    }
                    else if (GamePadStates[i].Buttons.B == ButtonState.Pressed && GameIsPaused)
                    {
                        if (PauseMenu.transform.Find("ControlImage").GetComponent<RawImage>().enabled)
                        {
                            PauseMenu.transform.Find("ControlImage").GetComponent<RawImage>().enabled = false;
                            PauseMenu.GetComponent<CanvasGroup>().interactable = true;
                        }
                        else if (ParameterCanvas.enabled)
                        {
                            ParameterCanvas.enabled = false;
                            PauseMenu.enabled = true;
                            PauseMenu.transform.Find("Resume_Button").GetComponent<Button>().Select();
                            PauseMenu.GetComponent<CanvasGroup>().interactable = true;
                        }
                        else
                        {
                            if (GameIsPaused)
                            {
                                StartwasPressed[i] = true;
                                PauseMenu.enabled = false;
                                GameIsPaused = false;
                                PauseMenu.GetComponent<CanvasGroup>().interactable = false;
                                Time.timeScale = 1f;
                                BwasPressed[i] = true;
                            }
                        }
                        //else if (PauseMenu.enabled)
                        //{
                        //    PauseMenu.enabled = false;
                        //}
                    }
                    else if (GamePadStates[i].Buttons.B == ButtonState.Released && BwasPressed[i])
                    {
                        BwasPressed[i] = false;
                    }

                    //Back (respawning)
                    if (GamePadStates[i].Buttons.Back == ButtonState.Pressed && !BackwasPressed[i])
                    {
                        BackwasPressed[i] = true;
                        Debug.Log("Back Button was pressed!");
                        respawn(i);
                    }
                    else if (GamePadStates[i].Buttons.Back == ButtonState.Released && BackwasPressed[i])
                    {
                        BackwasPressed[i] = false;
                    }

                    //Y (ragdolling)
                    if (GamePadStates[i].Buttons.Y == ButtonState.Pressed && !YwasPressed[i] && !YisRagdolling[i])
                    {
                        YwasPressed[i] = true;
                        YisRagdolling[i] = true;
                        movementForce[i] = 10f;
                        motionEnabled[i] = false;
                        Debug.Log("Y Button was pressed!");
                        Staggers[i].Stagger();
                    }
                    else if (GamePadStates[i].Buttons.Y == ButtonState.Pressed && !YwasPressed[i] && YisRagdolling[i])
                    {
                        YwasPressed[i] = true;
                        YisRagdolling[i] = false;
                        movementForce[i] = 1000f;
                        motionEnabled[i] = true;
                        Debug.Log("Y Button was pressed!");
                        Staggers[i].UnStagger();
                    }
                    else if (GamePadStates[i].Buttons.Y == ButtonState.Released && YwasPressed[i])
                    {
                        YwasPressed[i] = false;
                        //Staggers[i].UnStagger();
                    }

                    //X (grabbing)
                    if (GamePadStates[i].Buttons.X == ButtonState.Pressed && !XwasPressed[i])
                    {
                        XwasPressed[i] = true;
                        Debug.Log("X Button was pressed! " + i);
                        UpdateGrabInfo(i);
                        GrabDecide();
                    }
                    else if (GamePadStates[i].Buttons.X == ButtonState.Released && XwasPressed[i])
                    {
                        XwasPressed[i] = false;
                    }
                    // L (Keyboard Controls)
                    if (Input.GetKeyDown("l") && !LwasPressed)
                    {
                        Debug.Log("Keys Enabled!");
                        KeysEnabled = true;
                        LwasPressed = true;
                    }
                    else if (Input.GetKeyDown("l") && LwasPressed)
                    {
                        Debug.Log("Keys Disabled!");
                        KeysEnabled = false;
                        LwasPressed = false;
                    }
                    // M (Stagger All)
                    if (Input.GetKeyDown("m") && !MwasPressed)
                    {
                        Debug.Log("Stagger Override All!");
                        Staggers[0].Stagger();
                        Staggers[1].Stagger();
                        Staggers[2].Stagger();
                        Staggers[3].Stagger();
                        MwasPressed = true;
                    }
                    else if (Input.GetKeyDown("m") && MwasPressed)
                    {
                        Debug.Log("Stagger Deactivate All!");
                        Staggers[0].UnStagger();
                        Staggers[1].UnStagger();
                        Staggers[2].UnStagger();
                        Staggers[3].UnStagger();
                        MwasPressed = false;
                    }

                    /*
                    //RT (throwing)
                    if (GamePadStates[i].Triggers.Right >= 0.6f && !RightwasPressed[i])
                    {
                        // Alert
                        Debug.Log("THROW IT!!!!!");

                        RightwasPressed[i] = true;
                        Debug.Log("R Trigger was pressed!");
                        UpdateGrabInfo(i);
                        Throw();
                    }
                    else if (GamePadStates[i].Triggers.Right <= 0.48f && RightwasPressed[i])
                    {
                        // Alert
                        Debug.Log("GET OVER IT!!!!!");

                        RightwasPressed[i] = false;
                    }
                    */
                    /*
                    //RT (throwing)
                    if (GamePadStates[i].Buttons.RightShoulder == ButtonState.Pressed && !RightwasPressed[i])
                    {
                        // Alert
                        Debug.Log("THROW IT!!!!!");

                        RightwasPressed[i] = true;
                        Debug.Log("R Trigger was pressed!");
                        UpdateGrabInfo(i);
                        Throw();
                    }
                    else if (GamePadStates[i].Buttons.RightShoulder == ButtonState.Pressed && RightwasPressed[i])
                    {
                        // Alert
                        Debug.Log("GET OVER IT!!!!!");

                        RightwasPressed[i] = false;
                    }
                    */

                    //RB (throwing)
                    if (GamePadStates[i].Buttons.RightShoulder == ButtonState.Pressed && !RightwasPressed[i])
                    {
                        // Alert
                        Debug.Log("THROW IT!!!!!");

                        Debug.Log("R Trigger was pressed!");
                        RightwasPressed[i] = true;
                        UpdateGrabInfo(i);
                        Throw();
                    }
                    else
                    {
                        RightwasPressed[i] = false;
                    }

                    //LB (arc throwing)
                    if (GamePadStates[i].Buttons.LeftShoulder == ButtonState.Pressed && !LeftwasPressed[i])
                    {
                        // Alert
                        Debug.Log("THROW IT!!!!!");

                        Debug.Log("R Trigger was pressed!");
                        LeftwasPressed[i] = true;
                        UpdateGrabInfo(i);
                        ThrowArc();
                    }
                    else
                    {
                        LeftwasPressed[i] = false;
                    }

                    //Start (pausing)
                    //if not paused then pause
                    if (GamePadStates[i].Buttons.Start == ButtonState.Pressed && !StartwasPressed[i] && !PauseMenu.enabled)
                    {
                        StartwasPressed[i] = true;
                        PauseMenu.enabled = true;
                        GameIsPaused = true;
                        PauseMenu.GetComponent<CanvasGroup>().interactable = true;
                        PauseMenu.transform.Find("Resume_Button").GetComponent<Button>().Select();
                        Time.timeScale = 0f;
                    }
                    //otherwise if paused then unpause
                    else if (GamePadStates[i].Buttons.Start == ButtonState.Pressed && !StartwasPressed[i] && PauseMenu.enabled)
                    {
                        if (ParameterCanvas.enabled == true)
                        {
                            ParameterCanvas.enabled = false;
                            
                        }
                        StartwasPressed[i] = true;
                        PauseMenu.enabled = false;
                        GameIsPaused = false;
                        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
                        Time.timeScale = 1f;
                    }
                    else if (GamePadStates[i].Buttons.Start == ButtonState.Released && StartwasPressed[i])
                    {
                        StartwasPressed[i] = false;
                    }

                    /*
                    //toggle stamina ui
                    if (GamePadStates[i].DPad.Up == ButtonState.Pressed)
                    {
                        StaminaUI.GetComponent<Canvas>().enabled = true;
                        for (int j = 0; j < 4; j++)
                        {
                            SpriteRenderer reference;
                            try
                            {
                                reference = players[j].transform.Find("Player/Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>();
                            }
                            catch
                            {
                                reference = players[j].transform.Find("Player/Pivot/Character_DirectionalCircle_Blue_01_0").GetComponent<SpriteRenderer>();
                            }
                            reference.enabled = true;
                        }      
                    }

                    if (GamePadStates[i].DPad.Down == ButtonState.Pressed)
                    {
                        StaminaUI.GetComponent<Canvas>().enabled = false;
                        for (int j = 0; j < 4; j++)
                        {
                            SpriteRenderer reference;
                            try
                            {
                                reference = players[j].transform.Find("Player/Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>();
                            }
                            catch
                            {
                                reference = players[j].transform.Find("Player/Pivot/Character_DirectionalCircle_Blue_01_0").GetComponent<SpriteRenderer>();
                            }
                            reference.enabled = false;
                        }
                    }
                    */


                    //Show stagger stars
                    //RotatePlayers[i].transform.Find("metarig/hips/spine/chest/neck/head/StaggerStars").transform.Rotate(0, 5, 0);
                    PlayerHips[i].transform.Find("spine/chest/neck/head/StaggerStars").transform.Rotate(0, 5, 0);
                    if (Staggered[i])
                    {
                        //RotatePlayers[i].transform.Find("metarig/hips/spine/chest/neck/head/StaggerStars").GetComponent<MeshRenderer>().enabled = true;
                        PlayerHips[i].transform.Find("spine/chest/neck/head/StaggerStars").GetComponent<MeshRenderer>().enabled = true;
                    }
                    else
                    {
                        //RotatePlayers[i].transform.Find("metarig/hips/spine/chest/neck/head/StaggerStars").GetComponent<MeshRenderer>().enabled = false;
                        PlayerHips[i].transform.Find("spine/chest/neck/head/StaggerStars").GetComponent<MeshRenderer>().enabled = false;
                    }
                }
            }


            //TIME CHANGER
            //Updates any timers you want to use
            //dashes[i] corresponds to players[i]
            //staminas[i] corresponds to players[i]
            UpdateTimers();


            //^^^

            /*
            //Some previous attempts at turning
            float horizontalSpeed = 1f;
            if (players[0].transform.forward.x < Movement.x)
            {
                rotatePlayer1.RotateAround(pivot1.position, Vector3.up, -H * horizontalSpeed / Time.deltaTime);
            }
            else
            {
                rotatePlayer1.RotateAround(pivot1.position, Vector3.up, H * horizontalSpeed / Time.deltaTime);
            }

            if (Movement.magnitude >= 0.03)
            {
                animator1.Play("Walk");
            }
            else
            {
                animator1.Play("Idle");
            }

            //float speed = 5f;
            //float step = speed * Time.deltaTime;
            //Vector3 newDir = Vector3.RotateTowards(players[0].transform.forward.normalized, Movement.normalized, step, 0.0f);
            //Debug.DrawRay(players[0].transform.position, newDir, Color.red);
            //players[0].transform.Find("Player").transform.rotation = Quaternion.LookRotation(newDir);


            //var lookat = Movement;
            //lookat.z = 0;
            //if (lookat.magnitude > 0)
            //{
            //    players[0].transform.Find("Player").transform.LookAt(players[0].transform.Find("Player").transform.position + lookat, players[0].transform.Find("Player").transform.forward);
            //}


            //if (players[0].transform.forward.x < Movement.x)
            //{
            //    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, Mathf.Abs(players[0].transform.forward.x - Movement.x) * horizontalSpeed / Time.deltaTime);
            //}
            //else
            //{
            //    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, -Mathf.Abs(players[0].transform.forward.x - Movement.x) * horizontalSpeed / Time.deltaTime);
            //}
            */

        }
        else {
            //join game
            if (Input.GetButtonDown("Start1")) {
                print("start1");
            }
            if (Input.GetButtonDown("Start2")) {
                print("Start2");
            }
            if (Input.GetButtonDown("Start3")) {
                print("Start3");
            }
            if (Input.GetButtonDown("Start4")) {
                print("Start4");
            }
        }
    }
    //Variables for sliders
    public void ChangePlayerSpeed(float speed)
    {
        PlayerSpeed = speed;
    }
    public void ChangePlayerJumpForce(float speed)
    {
        jumpForce = speed; //My name is barry allen and I am the fastest man alive (except for all the other speedsters who are faster than me"
    }
    public void ChangePlayerThrowSpeed(float speed)
    {
        throwSpeed = speed;
    }
}
//}