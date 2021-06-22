using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        Debug.LogWarning("Warning");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError("Error");
    }
}
