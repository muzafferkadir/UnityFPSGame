using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollison : MonoBehaviour
{
    public GameObject FiredFrom;
    private bool isColliding;
    void Start()
    {
        transform.Rotate(-90f, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isColliding) return;//this is for collision work one time
        isColliding = true;

        if (FiredFrom == collision.gameObject) return; //player can't kill ourself
        Destroy(gameObject);
        PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(30);
            Debug.Log(health.currentHealth);
            if (health.currentHealth <= 0)
            {
                Debug.Log("ÖLDÜ");
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
        //string log = collision.gameObject.GetInstanceID() + " - " + FiredFrom.GetInstanceID();
    }
    private void Update()
    {
        isColliding = false;
    }
}
