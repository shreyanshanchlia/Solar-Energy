using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeasurementTool : MonoBehaviour
{
    [SerializeField] private GameObject measurementResult;
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
        float? totalEnergy = CalculateTotalEnergyOfGrid();
        if (totalEnergy == null) return;

        GameObject _measurementResult = Instantiate(measurementResult);
        _measurementResult.GetComponentInChildren<TextMeshProUGUI>().text =
            $"Total energy of the connected grid is <b>{totalEnergy:F3}W.";
        Destroy(_measurementResult, 8f);
    }

    PanelProperties GetPanelProperties(GameObject _panelGameObject) => _panelGameObject.GetComponent<PanelProperties>();
}
