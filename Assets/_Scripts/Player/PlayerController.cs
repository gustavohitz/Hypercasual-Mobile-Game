using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;

public class PlayerController : Singleton<PlayerController> {

    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;
    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";
    public GameObject endScreen;
    [Header("Text")]
    public TextMeshPro uiTextPowerUp;

    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private bool _invincible = false;

    void Start() {
        ResetSpeed();
    }
   
    void Update() {
        if(!_canRun) {
            return;
        }

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == tagToCheckEnemy) {
            if(!_invincible) {
                EndGame();
            }    
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == tagToCheckEndLine) {
            EndGame();
        }
    }

    private void EndGame() {
        _canRun = false;
        endScreen.SetActive(true);
    }
    public void StartRunning() {
        _canRun = true;
    }

    #region POWERUPS
    public void SetPowerUpText(string s) {
        uiTextPowerUp.text = s;
    }
    public void PowerUpSpeedUp(float f) {
        _currentSpeed = f;
    }

    public void ResetSpeed() {
        _currentSpeed = speed;
    }

    public void SetInvincibility(bool b = true) {
        _invincible = b;
    }
    #endregion
}
