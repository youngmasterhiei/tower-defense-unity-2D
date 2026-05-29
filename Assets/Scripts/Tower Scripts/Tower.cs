using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    public int towerHealth;
    public float damage;
    public float attackSpeed;
    public float range = 6f;
    public bool hasTarget;

    public GameObject closestEnemy;
    public GameObject currentTarget;
    public GameObject bullet;
    public GameObject[] targets;
    public ObjectPooling bulletPool;

    void Start()
    {
        StartCoroutine(ShootLoop());
    }

    void Update()
    {
    }

    public GameObject FindClosestEnemy()
    {
        closestEnemy = null;
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Enemy");
        float previousTargetDistance = range + 1.00f;

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
        bullet.GetComponent<TowerBullet>().damage = damage;
        bullet.GetComponent<TowerBullet>().target = currentTarget;
        bullet.SetActive(true);
    }

    IEnumerator ShootLoop()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(attackSpeed);
        }
    }
}