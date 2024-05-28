using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        Debug.Log("taked damage");
    }
}
