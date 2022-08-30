using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoin : PowerUpBase {

    [Header("Coin Collector")]
    public float sizeAmount = 7f;
    public float startSizeAmount = 1f;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(sizeAmount);
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.ChangeCoinCollectorSize(startSizeAmount);
    }
 
}
