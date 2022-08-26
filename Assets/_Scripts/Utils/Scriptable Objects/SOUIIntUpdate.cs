using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour {

    public SOInt soInt;
    public TextMeshProUGUI uiTextMeshValue;

    void Start() {
        uiTextMeshValue.text = soInt.value.ToString();
    }

    void Update() {
        uiTextMeshValue.text = soInt.value.ToString();
    }
    
}
