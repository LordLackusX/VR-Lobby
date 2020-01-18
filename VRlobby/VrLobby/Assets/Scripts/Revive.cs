using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour {


    public Vector3 _revive;
    
    // Use this for initialization
	void Start () {

        _revive = transform.position;


	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < -10f)
        {

            transform.position = _revive;
        }

    }
}
