using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour {

    public Rigidbody2D[] RBParts;
    public float explosionForce;
    public float partsSpin;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < RBParts.Length; i++)
        {
            RBParts[i].isKinematic = false;
            RBParts[i].AddTorque(partsSpin);
            RBParts[i].velocity = new Vector2(Random.Range(-explosionForce, explosionForce), Random.Range(-explosionForce, explosionForce));
        }


    }
	
	// Update is called once per frame
	void Update () {
        

    }
}
