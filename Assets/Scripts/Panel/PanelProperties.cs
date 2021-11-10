using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class PanelProperties : MonoBehaviour
{
    [ReadOnly, SerializeField] private PanelPropertiesData panelPropertiesData;

    bool isSelected;


    private void Start()
    {
        panelPropertiesData = new PanelPropertiesData(SolarGrid.Instance.GetPanelNumber(gameObject));
    }

    [UsedImplicitly]
    public void PanelSelected()
    {
        isSelected = true;
        SolarPanelUIManager.Instance.SelectedPanel(panelPropertiesData);
    }

    public void PanelOverlayAvoid()
    {
        if (SolarGrid.Instance.CheckForPanelAtPosition(transform.position, gameObject))
        {
            gameObject.SetActive(false);
            SolarGrid.Instance.MoveToInactivePanel(gameObject);
        }
    }
}
