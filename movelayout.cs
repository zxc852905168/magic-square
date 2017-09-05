using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movelayout : MonoBehaviour {
    public Transform centre;
    private bool isxuan;
    private GameObject[] cube;
    private float sign;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        
        if (isxuan) {
            cube[1] = other.gameObject.GetComponent<GameObject>();
        }
    }
   // public void fuck(int i) {
     //   print("ss");
   // }
    }
