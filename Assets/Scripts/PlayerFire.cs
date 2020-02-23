using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class PlayerFire : NetworkBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public ParticleSystem gunFirePartical;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CmdFire();
        }
    }
    [Command]
    private void CmdFire()
    {
        RpcStartParticles();
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        bullet.GetComponent<BulletCollison>().FiredFrom = gameObject;
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }
    [ClientRpc]
    public void RpcStartParticles()
    {
        DoStartParticles();
    }

    public void DoStartParticles()
    {
        gunFirePartical.Play();
        if (gunFirePartical.isPlaying)
        {
            gunFirePartical.Stop();
            gunFirePartical.Play();
        }
    }
}
