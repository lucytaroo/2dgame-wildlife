using System.Collections;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    Animator animator;
    private bool isHalted;


    public LayerMask SolidObject;
    public LayerMask PropCollider;
    public LayerMask InteractableLayer;
    public LayerMask FovLayer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (isHalted) return;

        if (!isMoving) // Check if the player is not already moving
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
                
            }

            
        }

        animator.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.F))
            {
            Interact();
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
    
    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.3f, SolidObject | InteractableLayer) != null)
        {
            return false;
        }
        
        if (Physics2D.OverlapCircle(targetPos, 0.1f, PropCollider) != null)
        {
            return false;
        }


        return true;
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

        Debug.DrawLine(transform.position, interactPos, Color.green, 0.5f);

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, InteractableLayer);
        if(collider != null)
        {
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    private void CheckIfInTrainersView()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.2f, FovLayer)!=null)
        {
            Debug.Log("In trainer view");
        }
    }

    private void OnMoveOver()
    {
        CheckIfInTrainersView();
    }

    public void HaltPlayer(bool halt)
    {
        isHalted = halt;
    }
}
 