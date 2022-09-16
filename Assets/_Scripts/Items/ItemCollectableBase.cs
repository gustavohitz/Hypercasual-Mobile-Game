using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour {

    public string compareTag = "Player";
    public ItemManager itemManager;
    //public HUDBase hudBase;
    public ParticleSystem particleSystem;
    public GameObject graphicItem;
    public float delayToDestroy = 2f;

    [Header("Sounds")]
    public AudioSource audioSource;

    void Awake() {
        if(particleSystem != null) {
            //particleSystem.transform.SetParent(null);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag(compareTag)) {
            Collect();
            //hudBase.UIUpdate();
        }
    }
    protected virtual void HideItems() {
        if(graphicItem != null) {
            graphicItem.SetActive(false);
        }
    }
    protected virtual void Collect() {
        Destroy(particleSystem.gameObject, delayToDestroy);

        HideItems();
        OnCollect();
    }

    protected virtual void OnCollect() {
        if(particleSystem != null) {
            particleSystem.transform.SetParent(null);
            particleSystem.Play();
        }

        if(audioSource != null) {
            audioSource.Play();
        }
    }
    
}
