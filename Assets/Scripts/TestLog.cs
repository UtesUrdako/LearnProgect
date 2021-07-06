using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLog : MonoBehaviour
{
    [SerializeField] private ParentDeleter parentDeleter;
    public bool isLog = false;
    private IEnumerator _coroutine1;
    private IEnumerator _coroutine2;

    private void Awake()
    {
        
    }

    void Start()
    {
        //InvokeRepeating("D", 0f, 3f);
        //CancelInvoke("D");

        _coroutine1 = D(3);
        _coroutine2 = D(6);

        StartCoroutine(_coroutine1);
        StartCoroutine(_coroutine2);

        StopCoroutine(_coroutine1);
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private IEnumerator D(float time)
    {
        yield return new WaitForSeconds(time);
        //yield return new WaitUntil(ReturnBool);
        yield return ReturnBool();
        Debug.Log($"Coroutine time: {time}");
    }

    private IEnumerator ReturnBool()
    {
        //Вычисления
        yield return true;
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