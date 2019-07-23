using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/GruntAttack")]
public class GruntAttackAction : Action
{
    float random;
    string[] atkNames = new string[] {"GruntAttack", "GruntComboAttack2", "GruntComboAttack3", "Grunt360Attack", "GruntJumpAttack"};
    string jumpAttack = "GruntJumpAttack";
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    private void Attack(StateController controller)
    {

        controller.anim.SetBool("Walk", false);
        
        if (controller.fromCombat)
        {

            // NOT IMPLEMENTED YET


            //charge attack (increase speed till close to enemy or change to tracking state with increased speed and animation)
            controller.fromCombat = false; //after animation is complete
        }

        if (!controller.isAttacking)
        {
            //face the player and check if the AI can attack
            FaceTarget(controller);
            controller.gm.requestAttack(controller.gameObject);

            //if the player attacked, have a chance to dodge away
            if (controller.gm.playerAttacked)
            {
                controller.gm.playerAttacked = false;
                int rng = Random.Range(0, 10);
                if (rng >= 5)
                {
                    controller.dodge = true;
                }
                
            }

            //40% chance to attack when 2f timer is up
            //since attacking is set to true a timer will start in StateController.cs using the general timer function

            random = Random.Range(0f, 10.0f);
            if ((controller.generalTimer(1f) && random >= 4f && controller.canAttack && controller.allowDistance1) || (controller.canAttack && controller.firstAttack && random >= 5f))
            {
                controller.firstAttack = false;
                string rng = atkNames[Random.Range(0, atkNames.Length)];
                controller.anim.SetTrigger(rng);
                controller.playAnim = false;
                controller.canMove = false;
                controller.isAttacking = true;
            }
            
        }
        else
        {
            //if the AI is attacking
            FaceTarget(controller);

            //after a 2f timer for the attack animation, revert booleans and remove self from attacking array in game manager
            if (controller.generalTimer(2f))
            {
                controller.isAttacking = false;
                controller.canAttack = false;
                controller.canMove = true;
                controller.gm.onCancelAttack(controller.gameObject);
            }

        }
    }

    //get direction to target, get rotation to point to target, then update rotation
    void FaceTarget(StateController controller)
    {

        Vector3 direction = (controller.chaseTarget.position - controller.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
