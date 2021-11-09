using System.Collections.Generic;
using UnityEngine;

public class SolarGrid : MonoBehaviour
{
    public static SolarGrid Instance;

    private int panelsIssued;
    
    private void Awake()
    {
        Instance = this;
    }

    public int GetPanelNumber()
    {
        panelsIssued++;
        return panelsIssued;
    }
}
