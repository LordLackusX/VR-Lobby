using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

    public Vector3 _SpawnPoint;


	// Use this for initialization
	void Start () {

        _SpawnPoint = transform.position;



	}
	
    

	// Update is called once per frame
	void Update () {


        if(transform.position.y  < -10f)
        {

            transform.position = _SpawnPoint;
        }
	}
}
