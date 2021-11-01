using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float pedalValue  = 20f;
    [SerializeField] float pedalBoost = 30f;
    [SerializeField] float pedalSlow = 15f;

    float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = pedalValue;
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Customer"))
        {
            moveSpeed = pedalValue;
        }
        else if (other.CompareTag("Package"))
        {
            moveSpeed = pedalBoost;
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        moveSpeed = pedalSlow;   
    }
}
