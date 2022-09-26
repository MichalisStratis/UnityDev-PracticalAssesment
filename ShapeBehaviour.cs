using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeBehaviour : MonoBehaviour
{
    public Rigidbody ShapeRB; //The sheep rigidbody

    void Start()
    {
        ShapeRB = GetComponent<Rigidbody>();
        ShapeRB.isKinematic = false; //Turns off the Kinematic 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ShapeRB.isKinematic = true; //Turns off the Kinematic 
        }
        else if (collision.gameObject.tag == "Player")
        {
            ShapeRB.isKinematic = false; //Turns off the Kinematic 
        }
        else if ((collision.gameObject.tag == "Player") && (collision.gameObject.tag == "Ground"))
        {
            ShapeRB.isKinematic = false; //Turns off the Kinematic 
        }
    }
   
}
