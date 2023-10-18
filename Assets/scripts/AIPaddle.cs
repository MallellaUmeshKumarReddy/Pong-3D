using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] float speed;


    // Update is called once per frame
    void Update()
    {

        Vector3 direction = ball.transform.position - transform.position;
        direction.Normalize();
        Vector3 movement = direction * speed * Time.deltaTime;
        transform.position += new Vector3(movement.x, 0f, 0f);

    }

}
