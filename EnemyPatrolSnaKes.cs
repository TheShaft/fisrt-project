
using UnityEngine;

public class EnemyPatrolSnaKes : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;


    private Transform target;
    private int destPoint = 0;


    void Start()
    {
        target = waypoints[0];
    }

  
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);


        // si l'ennemi est quastiment arrivé à destination
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            HealthPoint playerHealth = collision.transform.GetComponent<HealthPoint>();
            playerHealth.TakeDamage(1);
        }
    }
}
