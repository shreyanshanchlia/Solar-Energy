using System;
using System.Collections.Generic;
using UnityEngine;

public class SolarGrid : MonoBehaviour
{
    public static SolarGrid Instance;

    /// <summary> count of total panels - active and destroyed. </summary>
    private int panelsIssued;

    public List<GameObject> linkNodes;
    /// <summary> Reference to all the active panels.</summary>
    public List<GameObject> activePanels;
    /// <summary> Reference to all the inactive panels.</summary>
    public List<GameObject> inactivePanels;
    
    public List<Tuple<GameObject, GameObject>> wiredLinks;

    private void Awake()
    {
        Instance = this;
        activePanels = new List<GameObject>();
        inactivePanels = new List<GameObject>();
        linkNodes = new List<GameObject>();
        wiredLinks = new List<Tuple<GameObject, GameObject>>();
    }

    public int GetPanelNumber(GameObject _newPanel)
    {
        activePanels.Add(_newPanel);
        
        panelsIssued++;
        return panelsIssued;
    }

    /// <summary>
    /// Check if any panel is already at position.
    /// </summary>
    /// <param name="position">position to check for any existing panels.</param>
    /// <param name="toAvoid">GameObject to avoid check for.</param>
    /// <returns>true if any panel is already at position.</returns>
    public bool CheckForPanelAtPosition(Vector3 position, GameObject toAvoid)
    {
        foreach (GameObject panel in activePanels)
        {
            if(toAvoid == panel) continue;
            
            if (Mathf.Approximately(panel.transform.position.x, position.x) && 
                Mathf.Approximately(panel.transform.position.y, position.y))
            {
                return true;
            }
        }
        return false;
    }
    public GameObject GetPanelAtPosition(Vector3 position)
    {
        foreach (GameObject panel in activePanels)
        {
            if (Mathf.Approximately(panel.transform.position.x, position.x) && 
                Mathf.Approximately(panel.transform.position.y, position.y))
            {
                return panel;
            }
        }
        return null;
    }
    public bool CheckForOccupiedSpaceAtPosition(Vector3 position, GameObject toAvoid)
    {
        foreach (GameObject space in linkNodes)
        {
            if(toAvoid == space) continue;
            
            if (Mathf.Approximately(space.transform.position.x, position.x) && 
                Mathf.Approximately(space.transform.position.y, position.y))
            {
                return true;
            }
        }
        return false;
    }

    public void MoveToInactivePanel(GameObject panel)
    {
        if (activePanels.Contains(panel))
        {
            activePanels.Remove(panel);
            inactivePanels.Add(panel);
        }
        else
        {
            Debug.LogError("No panel to deactivate");
        }
    }

    public void AddLinkNode(GameObject extensionWire)
    {
        linkNodes.Add(extensionWire);
    }

    public void AddWiredLink(GameObject a, GameObject b)
    {
        wiredLinks.Add(new Tuple<GameObject, GameObject>(a, b));
    }
    

    public void ActivatePanel(GameObject panel)
    {
        if (inactivePanels.Contains(panel))
        {
            inactivePanels.Remove(panel);
            activePanels.Add(panel);
        }
        else
        {
            Debug.LogError("No panel to activate");
        }
    }
}
