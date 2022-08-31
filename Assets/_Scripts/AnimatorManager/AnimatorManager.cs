using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour {
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;

    public enum AnimationType {
        IDLE,
        RUN,
        DEAD
    }
    public void Play(AnimationType type) {
        foreach(var animation in animatorSetups) {
            if(animation.type == type) {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }
}
[System.Serializable]
public class AnimatorSetup {
    public AnimatorManager.AnimationType type;
    public string trigger;
}
