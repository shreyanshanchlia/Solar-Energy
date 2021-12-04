using System;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementTool : MonoBehaviour
{
    float? CalculateTotalEnergyOfGrid()
    {
        float resultantEnergy = 0f;
        
        List<PanelProperties> traversedPanelProperties = new List<PanelProperties>();
        Queue<PanelProperties> panelsToCalculate = new Queue<PanelProperties>();
        
        GameObject panelAtPos = SolarGrid.Instance.GetPanelAtPosition(transform.position);
        if (panelAtPos == null)
        {
            return null;
        }
        PanelProperties panelProperties = panelAtPos.GetComponent<PanelProperties>(); 
        
        panelsToCalculate.Enqueue(panelProperties);

        while (panelsToCalculate.Count > 0)
        {
            panelProperties = panelsToCalculate.Dequeue();
            traversedPanelProperties.Add(panelProperties);
            
            resultantEnergy += panelProperties.panelPropertiesData.GetOutputEnergy();
            
            foreach (Tuple<GameObject, GameObject> wireLink in SolarGrid.Instance.wiredLinks)
            {
                if (wireLink.Item1 == panelProperties.gameObject && wireLink.Item2.gameObject != null &&
                    !traversedPanelProperties.Contains(GetPanelProperties(wireLink.Item2)))
                {
                    panelsToCalculate.Enqueue(GetPanelProperties(wireLink.Item2));
                }
            }
        }
        return resultantEnergy;
    }

    public void CalculateEnergy()
    {
        Debug.Log($"Total connected energy = {CalculateTotalEnergyOfGrid()}");
    }

    PanelProperties GetPanelProperties(GameObject _panelGameObject) => _panelGameObject.GetComponent<PanelProperties>();
}
