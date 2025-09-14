using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public List<IDamageable> Damageables { get; } = new();

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Damageables.Add(damageable);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null && !Damageables.Contains(damageable))
        {
            Damageables.Add(damageable);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null && Damageables.Contains(damageable))
        {
            Damageables.Remove(damageable);
        }
    }
}
