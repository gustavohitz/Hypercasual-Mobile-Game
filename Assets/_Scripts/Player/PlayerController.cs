using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ebac.Core.Singleton;
using DG.Tweening;

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

    [Header("Limits")]
    public float limit = 4f;
    
    
    [Header("Coin Collector")]
    public GameObject coinCollector;

    [Header("Animation")]
    public AnimatorManager animatorManager;

    [Header("Particle System")]
    public ParticleSystem vfxDeath;
    public ParticleSystem youWinParticles;

    [SerializeField] private BounceHelper _bounceHelper;

    private Vector3 _pos;
    private bool _canRun;
    private float _currentSpeed;
    private bool _invincible = false;
    private Vector3 _startPosition;
    private float _baseAnimationSpeed = 7f;

    void Start() {
        _startPosition = transform.position;
        ResetSpeed();
    }
   
    void Update() {
        if(!_canRun) {
            return;
        }

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if(_pos.x < -limit) {
            _pos.x = -limit;
        }
        else if(_pos.x > limit) {
            _pos.x = limit;
        }

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other) {
        if(other.transform.tag == tagToCheckEnemy) {
            if(!_invincible) {
                MoveForward(other.transform);
                EndGame(AnimatorManager.AnimationType.DEAD);
            }
            if(vfxDeath != null) {
                vfxDeath.Play();
            }   
        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.transform.tag == tagToCheckEndLine) {
            EndGame();
            YouWin();
        }
    }

    private void MoveForward(Transform t) {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    private void EndGame(AnimatorManager.AnimationType animationType = AnimatorManager.AnimationType.IDLE) {
        _canRun = false;
        endScreen.SetActive(true);
        animatorManager.Play(animationType);
    }
    public void StartRunning() {
        _canRun = true;
        animatorManager.Play(AnimatorManager.AnimationType.RUN, _currentSpeed / _baseAnimationSpeed);
    }

    public void YouWin() {
        if(youWinParticles != null) {
            youWinParticles.Play();
        }
    }

    public void Bounce() {
        if(_bounceHelper != null) {
            _bounceHelper.Bounce();
        }
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
    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease) {
    
        transform.DOMoveY(_startPosition.y + amount, animationDuration).SetEase(ease);
        Invoke(nameof(ResetHeight), duration);
    }
    public void ResetHeight() {

        transform.DOMoveY(_startPosition.y, .1f);
    }
    public void ChangeCoinCollectorSize(float amount) {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}
