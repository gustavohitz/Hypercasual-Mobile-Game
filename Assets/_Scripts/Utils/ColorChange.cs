using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour {

    private Color _correctColor;
    public MeshRenderer meshRenderer;
    public float duration = .2f;
    public Color startColor = Color.white;


    void OnValidate() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Start() {
        _correctColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            LerpColor();
        }
    }
    private void LerpColor() {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_correctColor, duration).SetDelay(.5f);
    }
   
}
