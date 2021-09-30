using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLifting : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Robot>(out Robot robot))
        {
            Destroy(gameObject);
        }
    }
}
