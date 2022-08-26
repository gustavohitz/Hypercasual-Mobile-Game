using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class ItemManager : Singleton<ItemManager> {

    public SOInt coins;
    public SOInt satellites;
    public SOInt planets;

    void Start() {
        Reset();
    }

    private void Reset() {
        coins.value = 0;
        satellites.value = 0;
        planets.value = 0;
    }

    public void AddCoins(int amount = 1) {
        coins.value += amount;
    }

    public void AddSatellites(int amount = 1) {
        satellites.value += amount;
    }
    public void AddPlanets(int amount = 1) {
        planets.value += amount;
    }
   
}
