using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    [SerializeField] private Transform _rotatePoint;
    [SerializeField] private SphereCollider _visionCollider;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;

    private Transform _player;

    [SerializeField] private GameObject _prefabBullet;
    [SerializeField] private Transform _shootPoint;



    void Start()
    {
        _visionCollider.radius = _distance;
    }

    void Update()
    {
        if (_player != null)
        {
            GameObject bullet = Instantiate(_prefabBullet, _shootPoint.position, _shootPoint.rotation);
            
            bullet.tag = "bullet";

            //_rotatePoint.LookAt(_player);

            Vector3 targetDir = _player.position - transform.position;
            Vector3 newDir = Vector3.RotateTowards(transform.position, targetDir, Time.deltaTime * 50f, 0f);

            transform.rotation = Quaternion.LookRotation(newDir);
        }
        else
            _rotatePoint.Rotate(Vector3.up * Time.deltaTime * 50f);

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
