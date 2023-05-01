using UnityEngine;

public class Boss_Chase : StateMachineBehaviour
{
    //creates a box to store our players position
    Transform player;
    //create a box to store our bosses rigidbody
    Rigidbody2D rb;
    //create a storage location that will hold our boss behavoir script 
    BossBehavior bossBehavior;// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //sets the reference for player
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //set the reference for our bosses rb
        rb = animator.GetComponent<Rigidbody2D>();
        //set our reference so we can call our functions
        bossBehavior = animator.GetComponent<BossBehavior>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossBehavior.LookAtPlayer();
        //declaring and setting the player to the target for our boss, locking the y axis 
        Vector2 target = new Vector2(player.position.x, rb.position.y);
        //Sets a new position for our boss to move towards
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, bossBehavior.speed * Time.deltaTime);
        //tell our rb to move to the new Pos
        rb.MovePosition(newPos);

        //find the distance between the boss and player
        float distance = Vector2.Distance(player.position, rb.position);
        //phase 1
        if(distance < bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3  && !bossBehavior.isDead)
        {
            animator.SetTrigger("MeleeAttack");
        }
        //phase 2
        else if (distance < bossBehavior.attackRange && bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase2Attack");
        }

        //phase 3
        else if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase3Attack");
        }
        //boss defeated
        else if (bossBehavior.isDead)
        {
            animator.SetTrigger("Death");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
