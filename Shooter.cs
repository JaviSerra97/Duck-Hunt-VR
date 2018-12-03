using UnityEngine;

public class Shooter : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;
    public GameObject bullet;
    public GameObject bulletPosition;
    private bool canShoot = true;
    public float shootRate = 1f;
    private float nextShoot = 0f;
    private Audio_Manager audioManager;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        audioManager = Audio_Manager.instance;
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Update()
    {
        if (Controller.GetHairTriggerDown() && Time.time > nextShoot)
        {
            Shoot();
            canShoot = false;
            nextShoot = Time.time + shootRate;
        }

        if (Controller.GetHairTriggerUp())
        {
            canShoot = true;
        }
    }

    private void Shoot()
    {
        audioManager.PlaySound("Shoot");
        Instantiate(bullet, bulletPosition.transform.position, transform.rotation);
    }
}
