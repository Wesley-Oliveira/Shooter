using UnityEngine;
using System.Collections;

public class onTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
