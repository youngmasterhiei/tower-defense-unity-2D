using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    [Header("Upgrade Data Connection")]
    public UpgradeData upgradeData;

    [Header("Live Gameplay Stats")]
    public int towerHealth;
    public float damage;
    public float attackSpeed;
    public float range;

    [Header("Stats From upgrade data")]
    public Dictionary<string, float> stats = new Dictionary<string, float>();

    [Header("Targeting & Projectiles")]
    public bool hasTarget;
    public GameObject closestEnemy;
    public GameObject currentTarget;
    public GameObject bullet;
    public GameObject[] targets;
    public ObjectPooling bulletPool;

    void Start()
    {
        // Debug.Log("TEST LOG START");
        // Debug.Log("Upgrade Data JSON: " + JsonUtility.ToJson(upgradeData, true));
        // Debug.Log("TEST LOG END");

        AddStatsToTowerFromUpgradeData();
        Debug.Log(stats["Damage"]);
        Debug.Log(stats["Attack Speed"]);
        Debug.Log(stats["Range"]);

        StartCoroutine(ShootLoop());



    }


    private void AddStatsToTowerFromUpgradeData()
    {
        stats.Clear();

        foreach (UpgradeCategoryGroup category in upgradeData.categories)
        {
            foreach (UpgradeEntry upgrade in category.upgrades)
            {
                if (!upgrade.isUnlocked)
                    continue;

                stats[upgrade.upgradeName] = upgrade.statValue;
            }
        }

        foreach (var stat in stats)
        {
            Debug.Log("KEY = " + stat.Key + " VALUE = " + stat.Value);
        }
    }


    public GameObject FindClosestEnemy()
    {
        closestEnemy = null;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        float previousTargetDistance = stats["Range"] + 1.00f;

        foreach (GameObject target in targets)
        {
            float currentTargetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (previousTargetDistance > currentTargetDistance)
            {
                closestEnemy = target;
                previousTargetDistance = currentTargetDistance;
            }
        }
        hasTarget = closestEnemy != null;
        return closestEnemy;
    }

    void Shoot()
    {
        currentTarget = FindClosestEnemy();
        if (!hasTarget) return;

        bullet = bulletPool.GetPooledObject();
        bullet.transform.position = transform.position;

        bullet.GetComponent<TowerBullet>().damage = stats["Damage"];
        bullet.GetComponent<TowerBullet>().target = currentTarget;
        bullet.SetActive(true);
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(stats["Attack Speed"]);
        }
    }
}
