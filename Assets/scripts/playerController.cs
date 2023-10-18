using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    [SerializeField] float paddleSpeed = 10; //speed of the paddle
    float positiveX = 2.5f; // for setting the bound
    float negetiveX = -2.5f;
    float Verticalinput; // using for the roatation of child object
    

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    //making the paddle move using players input
    void playerMovement()
    {
        Verticalinput = Input.GetAxis("Vertical");


        //moving the paddle left and right in bounds
        if (transform.position.x >= negetiveX)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                transform.Translate(new Vector3(-1, 0, 0) * paddleSpeed * Time.deltaTime);
            }
        }
        if (transform.position.x <= positiveX)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.Translate(new Vector3(1, 0, 0) * paddleSpeed * Time.deltaTime);
            }
        }

        // rotating the paddle

        Transform childTransform = transform.GetChild(0);

        if (childTransform != null)
        {
            childTransform.Rotate(Vector3.up * Verticalinput * Time.deltaTime * 75);
        }

    }
}
