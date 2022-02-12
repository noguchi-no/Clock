using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RealTime : MonoBehaviour
{
     //dt;
    static public string realTimeString;
    // Start is called before the first frame update
    void Start()
    {
        GetRealTime();
    }
    public void GetRealTime()
    {
        
        Debug.Log(realTimeString);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
