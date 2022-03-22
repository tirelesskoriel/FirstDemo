using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScripts : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        
        Debug.Log("collision enter!!!!");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
