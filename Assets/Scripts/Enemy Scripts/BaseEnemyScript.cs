using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{

    public float health = 80;
    public string color = "blue";
    public float attackDmg = 1;
    public float attackSpd = 1.1f;
    public float moveSpeed = 0.25f;


    //movement variables. stop distance is for ranged enemies
    public Vector2 targetPosition = new Vector2(0f, 1.5f);
    public float stopDistance = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemies();

    }

    void MoveEnemies()
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);




    }

    public void CheckStatus()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
