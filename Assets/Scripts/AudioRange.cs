using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRange : MonoBehaviour
{
    [SerializeField] private float range;

    private void Update()
    {
        if (DetectPlayerInRange())
        {
            SoundManager.MyInstance.Play("Help");
        }
        else
        {
            SoundManager.MyInstance.Stop("Help");
        }
    }

    private bool DetectPlayerInRange()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, range);
        foreach (Collider hit in hits)
        {
            if (hit.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
