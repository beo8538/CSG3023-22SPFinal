/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: Betzaida Ortiz Rivas
 * Last Edited: 4/28/2022
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //import for the UI elements


public class Ball : MonoBehaviour
{
    [Header("General Settings")]
    public Text ballTxt; //reference ball textbox from HUD
    public Text scoreTxt; //reference the score from HUD
    public int numberOfBalls; //number of balls player has. This is our lives

    [Header("Ball Settings")]
    public float speed; //speed in which the ball is moving

    [Space (10)]
    
    public int score; //score of points player earns
    public Vector3 initialForce; //force that moves ball in the y axis. ONLY Y

    //do something about the paddle here
    GameObject paddle;

    public bool isInPlay; //see if ball is in play or not

    Rigidbody rb; //reference to RigidBody
    AudioSource audioSource; //reference to AudioSource


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        Rigidbody rb = GetComponent<Rigidbody>(); //reference the Rigidbody
        AudioSource audioSource = GetComponent<AudioSource>(); //reference the AudioSource

    }//end Awake()


    // Start is called before the first frame update
    void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()


    // Update is called once per frame
    void Update()
    {
        ballTxt.text = "Balls: " + numberOfBalls; //update player balls/lives
        scoreTxt.text = "Score: " + score; //update score

        if (isInPlay == false)
        {
            //transform.Translate(); //move ball to paddle position
        }

        /**See if player pressed Space Bar to Start game**/
       if(Input.GetKeyDown(KeyCode.Space) && isInPlay == false)
        {
            isInPlay = true; //changes the play to true
            Move(); //calls on the move method
        }
    }//end Update()



    private void LateUpdate()
    {
        if(isInPlay == true)
        {
          rb.velocity *= speed; //need to fix
        }
    }//end LateUpdate()

    void Move()
    {
        rb.AddForce(initialForce); //need to fix
    }

    private void OnCollisionEnter(Collision collision)
    {
        //audioSource.PlayOneShot(, 1f);
        if(CompareTag("Brick"))
        {
            score += 100;
            Destroy(gameObject);
        }//end if
    }//end OnCollisionEnter

    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("OutBounds"))
        {
            numberOfBalls -= 1; //subtract number of balls if player drops ball out of bounds
        }
        if(numberOfBalls > 0) //check to see if player has any balls left
        {
            Invoke("SetStartingPos()", 2f); //restart ball position
        }
    }


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddle
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()






}
