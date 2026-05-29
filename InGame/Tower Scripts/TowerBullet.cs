using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    public float moveSpeed = 3.00f;
    public float damage;
    public GameObject target;

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        if (target == null || !target.activeInHierarchy)
        {
            gameObject.SetActive(false);
            return;
        }

        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "Enemy")
        {
            BaseEnemyScript enemyScript = enemy.GetComponent<BaseEnemyScript>();
            enemyScript.health -= damage;
            enemyScript.CheckStatus();
            gameObject.SetActive(false);
        }
    }
}