using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Victoria Garcia and Lyndsey Narvaez
//Enemy AI that chases the player when they enter a the enemy's radius and deals damage when hit
public class EnemyBehavior : MonoBehaviour
{
    BehaviourTree tree;

    [SerializeField] private float speed;
    [SerializeField] private float attackDamage;
    [SerializeField] private float attackSpeed;
    private float canAttack;
    bool seesPlayer;
    bool attacksPlayer;
    private Transform target;


    public enum ActionState {IDLE, WORKING};
    //ActionState state = ActionState.IDLE;

    Node.Status treeStatus = Node.Status.RUNNING;

    void Start()
    {
        //Looks for the target
        target = this.GetComponent<Transform>();

        //The behaviorTree
        tree = new BehaviourTree();
        Sequence attack = new Sequence("Attack");
        Leaf seePlayer = new Leaf("Sees Player", SeePlayer);
        Leaf attackPlayer = new Leaf("Attack Player", AttackPlayer);

        attack.AddChild(seePlayer);
        attack.AddChild(attackPlayer);
        tree.AddChild(attack);

        //tree.PrintTree();
    }

    public Node.Status SeePlayer()
    {
        if (seesPlayer == false)
            return Node.Status.FAILURE;
        return Node.Status.SUCCESS;
    }

    

    public Node.Status AttackPlayer()
    {
        if (attacksPlayer == false)
            return Node.Status.FAILURE;
        return Node.Status.SUCCESS;
    }

    //Enemy attacks the player and deals damage to them
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            if (attackSpeed <= canAttack)
            {
                other.gameObject.GetComponent<SpPlayerTest>().LoseHealth(attackDamage);
                canAttack = 0f;
                attacksPlayer = true;

            }
            else
            {
                canAttack += Time.deltaTime;
                attacksPlayer = false;
            }
        }
    }

    //Checks if the player is in the radius
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            target = other.transform;
            //seesPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
        {
            target = null;
            //seesPlayer = false;
        }
    }


    //Enemy chases the player once they enter the target
    //Stops chasing the player when not in the target
    void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            seesPlayer = false;
        }
        seesPlayer = true;

        if (treeStatus != Node.Status.SUCCESS)
            treeStatus = tree.Process();
    }
}
