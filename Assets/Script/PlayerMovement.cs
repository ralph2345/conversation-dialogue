using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public LayerMask interactableLayer;//layer for the NPC monster


    
    private void Update()
{
    if (!isMoving)
    {
        // Capture input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Check if there is any input
        if (input != Vector2.zero)
        {
            var targetPos = transform.position;
            targetPos.x += input.x;
            targetPos.y += input.y;

            if (IsWalkable(targetPos))
            {
                StartCoroutine(Move(targetPos));
            }
        }
        else
        {
            // Reset input to zero if no keys are pressed
            input = Vector2.zero;
        }
    }
}

    

    IEnumerator Move(Vector3 targetPos)
{
    isMoving = true;

    while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        yield return null;
    }

    transform.position = targetPos;
    isMoving = false;
}



    private bool IsWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, interactableLayer) != null)
        {
            return false;
        }

        return true;
    }


}
