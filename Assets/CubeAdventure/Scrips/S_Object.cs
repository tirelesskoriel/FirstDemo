using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Object : MonoBehaviour
{
    [SerializeField] float hVelocity = 0.1f;
    [SerializeField] float vVelocity = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("game start!!");
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal") * hVelocity * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * vVelocity * Time.deltaTime;
        transform.Translate(xValue, 0, zValue);
    }
}
