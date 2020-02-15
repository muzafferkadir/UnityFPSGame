using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollison : MonoBehaviour
{
    public GameObject FiredFrom;
    void Start()
    {
        transform.Rotate(-90f, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (FiredFrom == collision.gameObject) return;//player can't kill ourself
        Destroy(gameObject);
        string log = collision.gameObject.GetInstanceID() + " - " + FiredFrom.GetInstanceID();
        Debug.Log(log);
        Debug.Log(collision.gameObject.name);
    }
}
