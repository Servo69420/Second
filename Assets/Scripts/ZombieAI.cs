using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    

   
    public bool isProvoked = false;

    // Damage zombie deals
    public float attackDamage = 20f;
    // Distance within which zombie attacks
    public float attackRange = 1.5f;

    void Awake()
    {
        player = GameObject.Find("player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check distance to player
        float distance = Vector3.Distance(player.position, transform.position);

        // If the player is within attacking range and the zombie is provoked
        if (isProvoked && distance <= attackRange)
        {
            // Attack the player
            AttackPlayer();
        }
        else if (isProvoked)
        {
            // Chase the player
            ChasePlayer();
        }
    }

    private void AttackPlayer()
    {
        // Ensure zombie isn't moving while attacking
        agent.SetDestination(transform.position);

        // Rotate zombie to face the player
        transform.LookAt(player);

        // Get player ZombieHealth script
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();

        // Damage the player
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    
}
