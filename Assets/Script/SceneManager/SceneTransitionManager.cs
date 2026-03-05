using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static string lastPortalUsed; // Stores the last portal ID used by the player
    public static bool canUsePortal = true;

    void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
    public static void TransitionToScene(string targetScene, string portalID)
    {
        lastPortalUsed = portalID; // Store the portal ID
        SceneManager.LoadScene(targetScene); // Load the target scene
        canUsePortal = false;
    }

    public static void EnablePortalUsage()
    {
        canUsePortal = true;
    }
}


