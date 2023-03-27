using UnityEngine;
using Random = UnityEngine.Random;
using System;

public class Shoot : MonoBehaviour
{
    public float coolDown = 0.1f;
    float lastFireTime = 0;
    public int defaultAmmo = 120;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;
    public Camera camera;
    public int range;
    [Header("Gun Damage On Hit")]
    public int damage;
    public GameObject bloodPrefab;
    public GameObject decalPrefab;
    float minAngle = -1;
    float maxAngle = 1;
    public ParticleSystem muzzleParticle;
    void Start()
    {
        currentAmmo = defaultAmmo - magSize;
        currentMagAmmo = magSize;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        if (Input.GetMouseButton(0))
        {
            if (CanFire())
            {
                Fire();
            }

        }
    }

    private void Reload()
    {
        if (currentAmmo == 0 || currentMagAmmo == magSize)
        {
            return;
        }

        if (currentAmmo < magSize)
        {
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentAmmo = 0;
        }
        else
        {
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
        }
    }

    private bool CanFire()
    {

        if (currentMagAmmo > 0 && lastFireTime + coolDown < Time.time)

        {
            lastFireTime = Time.time + coolDown;
            return true;
        }
        return false;
    }

    private void Fire()
    {
        muzzleParticle.Emit(5);
        currentMagAmmo -= 1;
        Debug.Log("Kalan Mermi: " + currentMagAmmo);
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 10))
        {
            if (hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHealth>().Hit(damage);
                GenerateBloddEffect(hit);
            }
            else
            {
                GenerateHitEffect(hit);

            }
        }
        transform.localEulerAngles = new Vector3(Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle), Random.Range(minAngle, maxAngle));


    }

    private void GenerateHitEffect(RaycastHit hit)
    {
        // TODO:mermi izi olustur
        GameObject hitObject = Instantiate(decalPrefab, hit.point, Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward * -1, hit.normal);
    }

    private void GenerateBloddEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
    }
}
