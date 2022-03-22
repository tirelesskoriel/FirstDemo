using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class EventBus : UnityEvent<string>
{
    
}
public class CoroutineFunc : MonoBehaviour
{

    public EventBus EventBusFunc;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            if (EventBusFunc != null)   
            {
                EventBusFunc.Invoke("lalalalal");
            }
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        Color color = GetComponent<MeshRenderer>().material.color;
        Debug.Log("fade ===================" + color);
        for (float red = color.r; red >= 0f; red -= 0.01f)
        {
            color.r = red;
            GetComponent<MeshRenderer>().material.color = color;
            yield return null;
        }
    }
}
