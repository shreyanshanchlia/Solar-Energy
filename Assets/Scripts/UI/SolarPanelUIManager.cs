using TMPro;
using UnityEngine;

public class SolarPanelUIManager : MonoBehaviour
{
    public static SolarPanelUIManager Instance;

    [SerializeField] private GameObject panelInformationPanel;
    [SerializeField] private TextMeshProUGUI productIDText;
    [SerializeField] private TextMeshProUGUI orientationAngleText;
    [SerializeField] private TextMeshProUGUI efficiencyText;
    [SerializeField] private TextMeshProUGUI sizeText;
    private void Awake()
    {
        Instance = this;
    }

    public void SelectedPanel(PanelPropertiesData data)
    {
        panelInformationPanel.SetActive(true);
        
        //set details on canvas
        productIDText.text = $"Product ID - {data.id}";
        orientationAngleText.text = $"Angle <pos=50%>{data.orientationX}°";
        efficiencyText.text = $"Efficiency <pos=50%>{data.efficiency:P}";
        sizeText.text = $"Size <pos=50%>{data.size.x}m × {data.size.y}m";
    }
}
