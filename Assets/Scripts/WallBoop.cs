using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBoop : MonoBehaviour {
	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "player") 
		{
			audio.Play();
		}	
	}
}

 