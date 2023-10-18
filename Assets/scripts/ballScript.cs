using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ballScript : MonoBehaviour
{
    Rigidbody rb; //rigid body
    [SerializeField] int ballForce = 5; 
    [SerializeField] GameObject Player;

    float ang = 50;
    Vector3 angle;
    GameObject base1;
    Vector3 initialPosition; // to get stating position of ball

    [SerializeField] AudioClip bouncesound,deathclip;
    AudioSource audioPlayer;



    //calling a constructor for points added event
    PointsAddedEvent PlayerpointsaddedEvent = new PointsAddedEvent();
    PointsAddedEvent EnemypointsAddedEvent = new PointsAddedEvent();

   

    // Start is called before the first frame update
    void Start()
    {
        ang = Random.Range(75, 80);
        rb = GetComponent<Rigidbody>();

        angle = new Vector3(Mathf.Cos(ang), 0, Mathf.Sin(ang));
       

        //getting audiosource to play the clip
        audioPlayer = GetComponent<AudioSource>();

        initialPosition = transform.position;

        //getting base object
        base1 = GameObject.FindGameObjectWithTag("Base");
    }

    // Update is called once per frame
    void Update()
    {
        // moving the ball in random direction
        ang = Random.Range(45, 93);
        transform.position += angle * ballForce * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // to reflect ball after bolliding, giving real world bounce
        Vector3 normal = collision.contacts[0].normal;
        angle = Vector3.Reflect(angle, normal);

        //adding audio on collision
        audioPlayer.clip = bouncesound;
        audioPlayer.Play();

        #region Collision with bases
        if (collision.gameObject == base1)
        {
            //adding new clip
            audioPlayer.clip = deathclip;
            audioPlayer.Play();

            ballForce += 3;
            PlayerpointsaddedEvent.Invoke(-5);
            StartCoroutine(onBaseHitDelay());

           
            

        }
        if (collision.gameObject.CompareTag("Base2"))
        {
            //adding new clip
            audioPlayer.clip = deathclip;
            audioPlayer.Play();

            ballForce += 5;
            EnemypointsAddedEvent.Invoke(-5);
            StartCoroutine(onBaseHitDelay());

             
        }
        #endregion
    }



    #region Adding listners for the events
    public void addpointsAddedEventListner(UnityAction<int> player)
    {
        PlayerpointsaddedEvent.AddListener(player);
    }
    public void addpointsAddedEventListnerEnemy(UnityAction<int> Enemy)
    {
        EnemypointsAddedEvent.AddListener(Enemy);
    }
    #endregion
   
    //delay on base hit

    IEnumerator onBaseHitDelay()
    {
        // generating random angle for the ball

        ballForce = 0;

      

        //getting to start position
        transform.position = initialPosition;
        
        //stopping tthe ball by maing its speed to zero
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        yield return new WaitForSeconds(2);
        Vector3 angle = new Vector3(Mathf.Cos(ang), 0,Mathf.Sin(ang));
        ballForce += 5;
  
    }
  
    
}
