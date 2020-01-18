using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour {

    public AudioSource _source;
    
    // Use this for initialization
	void Start () {

        _source = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
		
        

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Target")
        {
            _source.Play();

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _source.Play();


        }
    }



}
