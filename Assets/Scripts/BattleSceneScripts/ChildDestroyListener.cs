using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildDestroyListener : MonoBehaviour
{
    public event System.Action OnChildDestroyed;

    private void OnDestroy()
    {
        OnChildDestroyed?.Invoke();
    }
}
