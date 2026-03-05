using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    [SerializeField] GameObject quizCanvas;
    [SerializeField] GameObject panel;


    [SerializeField] float moveSpeed = 2f;
    
    private bool isInteracting = false;

    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }


    public void StartInteraction()
    {

        if (isInteracting) return;
        isInteracting = true;

        var playerScript = player.GetComponent<PlayerMovement2>();
        if (playerScript != null)
        {
            playerScript.HaltPlayer(true);
        }

        StartCoroutine(MoveToPlayer());
    }


    private IEnumerator MoveToPlayer()
    {
        Vector3 targetPos = CalculateTargetPosition();


        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        
        Interact();

        var playerScript = player.GetComponent<PlayerMovement2>();
        if (playerScript != null)
        {
            playerScript.HaltPlayer(false);
        }
        isInteracting = false;
    }

    private Vector3 CalculateTargetPosition()
    {
        Vector3 direction = player.position - transform.position;

       
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            float targetX = player.position.x + (direction.x > 0 ? -1 : 1); 
            return new Vector3(targetX, transform.position.y, transform.position.z);
        }
        else 
        {
            float targetY = player.position.y + (direction.y > 0 ? -1 : 1); 
            return new Vector3(transform.position.x, targetY, transform.position.z);
        }
    }

    

    public void Interact()
    {
        DialogManager.Instance.SetCurrentQuizCanvas(quizCanvas,panel);
        
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

    
}
