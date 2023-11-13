using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedPlayer : MonoBehaviour
{
    NetworkedObject _networkedObject;
    NetworkedObject networkedObject
    {
        get
        {
            if (_networkedObject == null)
            {
                _networkedObject = GetComponent<NetworkedObject>();
            }
            if (_networkedObject == null)
            {
                Debug.LogError("There is no NetworkedObject attached to game object " + gameObject.name);
            }

            return _networkedObject;
        }
    }

    public int _PlayerID;

    public int PlayerID
    {
        get
        {
            return networkedObject.OwnerID;
        }
        /*
        set
        {
            networkedObject.OwnerID = value;
        }*/
    }

    public int UnitCount
    {
        get
        {
            int count = 0;
            Unit[] allUnits = FindObjectsOfType<Unit>();

            for (int i = 0; i < allUnits.Length; i++)
            {
                if (allUnits[i].GetComponent<NetworkedObject>().OwnerID == PlayerID)
                {
                    count++;
                }
            }
            return count;
        }
    }

    private void Update()
    {
        _PlayerID = PlayerID;
    }
}