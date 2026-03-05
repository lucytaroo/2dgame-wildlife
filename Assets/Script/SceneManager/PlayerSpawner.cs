using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    //public Transform player;
    void Start()
    {
        var entryPortal = FindObjectsOfType<Portal>().FirstOrDefault(p => p.portalID == SceneTransitionManager.lastPortalUsed);
        if (entryPortal != null)
        {
            transform.position = entryPortal.exitPosition.position; // Set player position
        }
    }
}
