using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    [SerializeField] private SphereCollider _visionCollider;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;

    [SerializeField] private Transform _player;

    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _shootPoint;



    void Start()
    {
        _visionCollider.radius = _distance;
    }

    public float angle;
    public float speed;

    private bool readyShoot = true;
    GameObject go;
    Vector3 targetDir;
    Vector3 newDir;


    void Update()
    {
        if (_player == null)
            return;

        angle = Vector3.Angle(transform.parent.forward, _player.position);

        if (angle <= 10)
        {
            targetDir = _player.position - transform.position;
            newDir = Vector3.RotateTowards(transform.forward, targetDir, speed * Time.deltaTime, 0.0F);

            transform.rotation = Quaternion.LookRotation(new Vector3(newDir.x, 0, newDir.z));
            if (readyShoot)
            {
                readyShoot = false;
                go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.transform.position = transform.GetChild(0).position;
                go.transform.localScale = Vector3.one * 0.2f;
                go.transform.LookAt(_player.position);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _player = null;
        }
    }
}
