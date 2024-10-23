using UnityEngine;

public static class AnimationHelper
{
    public static void StartPulse(GameObject target, Vector3 targetScale, float pulseSpeed)
    {
        // Cancel any existing tweens on this object first
        LeanTween.cancel(target);

        // Start new pulse animation
        LeanTween.scale(target, targetScale, pulseSpeed)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong();
    }

    public static void StopPulse(GameObject target)
    {
        // Cancel any tweens on this object
        LeanTween.cancel(target);
        target.transform.localScale = Vector3.one;
    }
}
