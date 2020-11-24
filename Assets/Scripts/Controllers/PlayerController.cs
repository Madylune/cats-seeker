using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Cat")
        {
            Destroy(collision.gameObject);
            GameManager.MyInstance.UpdateCatCount();
            SoundManager.MyInstance.Play("Catch");
        }
    }
}
