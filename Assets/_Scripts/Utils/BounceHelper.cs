using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceHelper : MonoBehaviour {

    [Header("Animation")]
    public float scaleDuration = .05f;
    public float scaleBounce = 1.2f;
    public float finalScale = 1;
    public float sizeScaleDuration = 1.5f;
    public Ease ease = Ease.Linear;

    void Start() {
        SizeBounce();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Bounce();
        }
    }

    public void Bounce() {
        transform.DOScale(scaleBounce, scaleDuration).SetEase(ease).SetLoops(2, LoopType.Yoyo);
    }

    public void SizeBounce() {
        transform.DOScale(finalScale, sizeScaleDuration).SetEase(ease);
    }
}
