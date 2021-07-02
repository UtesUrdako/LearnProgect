using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform target;
    public float angle;
    public float speed;

    private bool readyShoot = true;
    GameObject go;
    Vector3 targetDir;
    Vector3 newDir;


    void Update()
    {
        angle = Vector3.Angle(transform.parent.forward, target.position);

        if (angle <= 40)
        {
            targetDir = target.position - transform.position;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0F);

            transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.z));
            if (readyShoot)
            {
                readyShoot = false;
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.transform.position = transform.GetChild(0).position;
                go.transform.localScale = Vector3.one * 0.2f;
                go.transform.LookAt(target.position);
                go.GetComponent<Collider>().isTrigger = true;
                go.AddComponent<Rigidbody>().useGravity = false;
                go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 20, ForceMode.Impulse);
                StartCoroutine(TimeShoot());
                Destroy(go, 2);
            }
        }
        else
        {
            targetDir = transform.parent.forward - transform.position;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * 2 * Time.deltaTime, 0.0F);

            transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.z));
        }
    }

    IEnumerator TimeShoot()
    {
        yield return new WaitForSeconds(1.5f);
        readyShoot = true;
    }
}
