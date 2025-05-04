using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VoidDamage : MonoBehaviour
{
    public Health health;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        health.TakeDamage(5);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        health.TakeDamage(5);

    }

}
