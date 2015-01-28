using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class _VictorRoomPoints : MonoBehaviour {

    List<GameObject> listBlocksGivenPoints = new List<GameObject>();
    public Text pointsText;
    int points = 0;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerExit(Collider other)
    {

        if (!listBlocksGivenPoints.Contains(other.gameObject))
        {
            listBlocksGivenPoints.Add(other.gameObject);
            Debug.Log(other.gameObject.name);
            other.gameObject.name = "CUBE_IS_STOOPID";
            points++;
            if (pointsText != null)
            {
               pointsText.text = "Points: " + points;
            }
        }

        
    }

}
