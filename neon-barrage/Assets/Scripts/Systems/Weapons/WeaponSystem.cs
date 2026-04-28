using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private WeaponData[] weaponData;
    [SerializeField] private ParticleSystem muzzleFlashPS;

    private int weaponLevel;

    private WeaponData currentWeaponData;

    private ObjectPoolManager bulletPoolManager;
    private bool isReloading;
    private int bulletCount;
    private float reloadTriggerTime;
    private float lastShotTime;

    public Transform ContextTransform { get; protected set; }


    public void UpgradeWeapon()
    {
        weaponLevel++;
        if (weaponLevel >= weaponData.Length) weaponLevel = weaponData.Length - 1;
        currentWeaponData = weaponData[weaponLevel];
    }

    private void Awake()
    {
        ContextTransform = transform;
        currentWeaponData = weaponData[weaponLevel];
        bulletPoolManager = new(currentWeaponData.MagazineSize, currentWeaponData.BulletPrefab, ContextTransform);
        bulletCount = currentWeaponData.MagazineSize;
    }

    public void Shoot(Vector3 targetPoint)
    {
        if (!isReloading && bulletCount <= 0)
        {
            isReloading = true;
            reloadTriggerTime = Time.time;
            Debug.Log("Is reloading...");
        }

        if (isReloading && ((Time.time - reloadTriggerTime) >= currentWeaponData.ReloadTime))
        {
            isReloading = false;
            bulletCount = currentWeaponData.MagazineSize;
        }

        if (isReloading) return;

        if ((Time.time - lastShotTime) < currentWeaponData.TimeBetweenShots)
        {
            Debug.Log("Waiting for next shot");
            return;
        }

        lastShotTime = Time.time;

        if (!currentWeaponData.IsInfinite) bulletCount--;

        Debug.Log("Shot");

        if (muzzleFlashPS != null) muzzleFlashPS.Play();
        Ammo bullet = bulletPoolManager.Get() as Ammo;
        bullet.ContextTransform.SetParent(null);
        bullet.ContextTransform.position = firePoint.position;

        Vector3 direction = (targetPoint - firePoint.position).normalized;
        bullet.ContextTransform.forward = direction;

        bullet.Fire(direction);
        bullet.gameObject.SetActive(true);
    }

}
