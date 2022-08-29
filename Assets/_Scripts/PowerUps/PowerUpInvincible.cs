using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : PowerUpBase {

    protected override void StartPowerUp() {
        base.StartPowerUp();
        PlayerController.Instance.SetPowerUpText("Invincible");
        PlayerController.Instance.SetInvincibility();
    }

    protected override void EndPowerUp() {
        base.EndPowerUp();
        PlayerController.Instance.SetInvincibility(false);
        PlayerController.Instance.SetPowerUpText("");
    }

}
