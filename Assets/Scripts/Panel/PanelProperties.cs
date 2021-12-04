using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class PanelProperties : MonoBehaviour
{
    [ReadOnly] public PanelPropertiesData panelPropertiesData;

    private void Start()
    {
        panelPropertiesData = new PanelPropertiesData(SolarGrid.Instance.GetPanelNumber(gameObject));
    }

    [UsedImplicitly]
    public void PanelSelected()
    {
        SolarPanelUIManager.Instance.SelectedPanel(gameObject);
    }

    public void PanelOverlayAvoid()
    {
        if (SolarGrid.Instance.CheckForPanelAtPosition(transform.position, gameObject) ||
            SolarGrid.Instance.CheckForOccupiedSpaceAtPosition(transform.position, null))
        {
            gameObject.SetActive(false);
            SolarGrid.Instance.MoveToInactivePanel(gameObject);
        }
    }
}
