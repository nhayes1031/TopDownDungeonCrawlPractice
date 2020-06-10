using System;
using UnityEngine;

public class AnimationImpactWatcher : MonoBehaviour
{
    public event Action OnImpact;

    private void Impact()
    {
        OnImpact?.Invoke();
    }
}
