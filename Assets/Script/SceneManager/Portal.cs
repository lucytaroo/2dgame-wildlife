using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string portalID;          
    public string targetScene;       

    public string targetPortalID;    
    public Transform exitPosition;   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            SceneTransitionManager.TransitionToScene(targetScene, targetPortalID);
            StartCoroutine(EnablePortalAfterDelay());
        }
    }
    private IEnumerator EnablePortalAfterDelay()
    {
        yield return new WaitForSeconds(1f); 
        SceneTransitionManager.EnablePortalUsage();
    }

}
