using UnityEngine;
using System.Collections;

public class BecameInvisible : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
