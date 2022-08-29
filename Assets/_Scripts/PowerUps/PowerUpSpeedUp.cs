using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase {

    [Header("Power Up Speed Up")]
    public float amountToSpeedUp;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeedUp);
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
    }
    
    
}
