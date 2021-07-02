using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLog : MonoBehaviour
{
    [SerializeField] private ParentDeleter parentDeleter;

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "1")
        {
            parentDeleter.DeleteChild();
        }
    }
}

internal class ParentDeleter : MonoBehaviour
{
    public void DeleteChild()
    {
        int count = transform.childCount;
        for (int i = count - 1; i < 0; i--)
        {
            Destroy(transform.GetChild(i));
        }
        Destroy(gameObject);
    }

}