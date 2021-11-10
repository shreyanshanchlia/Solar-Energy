using System.Collections.Generic;
using UnityEngine;

public class SolarGrid : MonoBehaviour
{
    public static SolarGrid Instance;

    /// <summary>
    /// count of total panels - active and destroyed.
    /// </summary>
    private int panelsIssued;

    /// <summary>
    /// Reference to all the active panels.
    /// </summary>
    public List<GameObject> activePanels;

    /// <summary>
    /// Reference to all the inactive panels.
    /// </summary>
    public List<GameObject> inactivePanels;

    private void Awake()
    {
        Instance = this;
        activePanels = new List<GameObject>();
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
