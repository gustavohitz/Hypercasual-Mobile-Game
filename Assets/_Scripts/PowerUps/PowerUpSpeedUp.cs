using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase {

    [Header("Power Up Speed Up")]
    public float amountToSpeedUp;

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.PowerUpSpeedUp(amountToSpeedUp);
        PlayerController.Instance.SetPowerUpText("Speed Up");
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }
    
    
}
