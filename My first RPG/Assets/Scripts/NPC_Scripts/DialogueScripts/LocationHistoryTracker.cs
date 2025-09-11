using System.Collections.Generic;
using UnityEngine;

public class LocationHistoryTracker : MonoBehaviour
{    
    private readonly HashSet<LocationSO> LocationVisited = new HashSet<LocationSO>();
    
    public void RecordLocation(LocationSO locationSO)
    {
        if (LocationVisited.Add(locationSO))
        {
            Debug.Log("Just visited to " + locationSO.displayName);
        }
    }

    public bool HasVisited(LocationSO locationSO)
    {
        return LocationVisited.Contains(locationSO);
    }
}
