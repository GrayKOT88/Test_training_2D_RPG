using System.Collections.Generic;
using UnityEngine;

public class DialogueHistoryTrecker : MonoBehaviour
{    
    private readonly HashSet<ActorSO> spokenNPCs = new HashSet<ActorSO>();
       
    public void RecordNPC (ActorSO actorSO)
    {
        spokenNPCs.Add(actorSO);
        Debug.Log("Just spoke to " +  actorSO.actorName);
    }

    public bool HasSpokenWith(ActorSO actorSO)
    {
        return spokenNPCs.Contains(actorSO);
    }
}
