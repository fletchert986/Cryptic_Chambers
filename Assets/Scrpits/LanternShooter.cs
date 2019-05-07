using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternShooter : MonoBehaviour {

    public LanternProjectile Projectile;
    public LanternProjectile Projectile2;
    public LanternProjectile Projectile3;
    public LanternProjectile Projectile4;
    public Transform projectileSpawn;
    public float projectileSpeed;
    public PauseMenu pausing;

    public Light lanternLight;
    public float depleteFuel;
    public float minRange = 1;
    public float fireRate = 1.0f;
    private float lastShot = 0.0f;
    private AudioSource audioSource;

    private void Start()
    {
        GameObject theMenu = GameObject.Find("PauseCanvas");
        pausing = theMenu.GetComponent<PauseMenu>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        // shooting the projectile
        float fire = Input.GetAxis("Fire2");

        if (Input.GetButtonDown("Fire1") || fire > 0 && pausing.pauseState == false)
        {
            if (Time.time > fireRate + lastShot)
            {
                LanternProjectile projectileInstance;
                audioSource.Play();

                if (lanternLight.color == Color.magenta)
                {
                    projectileInstance = Instantiate(Projectile2, projectileSpawn.position, projectileSpawn.rotation) as LanternProjectile;
                }
                else if (lanternLight.color == Color.green)
                {
                    projectileInstance = Instantiate(Projectile3, projectileSpawn.position, projectileSpawn.rotation) as LanternProjectile;
                }
                else if (lanternLight.color == Color.yellow)
                {
                    projectileInstance = Instantiate(Projectile4, projectileSpawn.position, projectileSpawn.rotation) as LanternProjectile;
                }
                else
                {
                    projectileInstance = Instantiate(Projectile, projectileSpawn.position, projectileSpawn.rotation) as LanternProjectile;
                }

                projectileInstance.speed = projectileSpeed;
                lastShot = Time.time;

                if (lanternLight.spotAngle - depleteFuel > minRange)
                {
                    lanternLight.spotAngle -= depleteFuel;
                }
            }

        }
    }
}
