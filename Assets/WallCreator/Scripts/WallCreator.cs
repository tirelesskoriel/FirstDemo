using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class WallCreator : MonoBehaviour
{
    public GameObject block;
    public int width = 10;
    public int height = 4;


    private void Awake()
    {
        Log("Awake !!!");
    }

    private void OnEnable()
    {
        Log("OnEnable !!!");
    }

    void Start()
    {
        Log("Start !!!");
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                GameObject wall = Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
                wall.GetComponent<MeshRenderer>().material.color = RandomColor();
            }
        }
    }

    private Color RandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }

    private void Log([CanBeNull] string msg)
    {
        Debug.Log(msg ?? "null");
    }

    public void EventBusFuc(string msg)
    {
        Debug.Log("!!!!!  Wall Creator " + msg);
    }

    // Update is called once per frame
    void Update()
    {
    }
}