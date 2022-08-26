using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";

    private Vector3 _pos;
    private bool _canRun;

    void Start() {
        _canRun = true;
    }
   
   
    void Update() {
        if(!_canRun) {
            return;
        }

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == tagToCheckEnemy) {
            _canRun = false;
        }
    }
}
