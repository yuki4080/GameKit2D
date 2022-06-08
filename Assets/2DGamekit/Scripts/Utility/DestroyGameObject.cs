using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_STANDALONE
        Destroy(gameObject);
#endif
    }
}
