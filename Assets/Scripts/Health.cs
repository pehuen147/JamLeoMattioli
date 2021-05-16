using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public abstract void TakeDamage(float damage, int colorIndex);
    public abstract void Death();
}
