using Unity.Collections;
using UnityEngine;

public class PanelProperties : MonoBehaviour
{
    [ReadOnly, SerializeField] private PanelPropertiesData panelPropertiesData;

    bool isSelected;


    private void Start()
    {
        panelPropertiesData = new PanelPropertiesData(SolarGrid.Instance.GetPanelNumber());
    }

    public void PanelSelected()
    {
        isSelected = true;
        SolarPanelUIManager.Instance.SelectedPanel(panelPropertiesData);
    }
}
