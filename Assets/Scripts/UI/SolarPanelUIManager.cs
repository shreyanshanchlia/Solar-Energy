using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SolarPanelUIManager : MonoBehaviour
{
    public static SolarPanelUIManager Instance;
    
    [Header("Global Sun Settings")]
    [SerializeField] private GameObject panelGlobalSunInformation;

    [Header("Solar Energy Panel")]
    [SerializeField] private GameObject panelInformationPanel;
    [SerializeField] private TextMeshProUGUI productIDText;
    [SerializeField] private TextMeshProUGUI orientationAngleText;
    [SerializeField] private TextMeshProUGUI efficiencyText;
    [SerializeField] private TextMeshProUGUI sizeText;
    [SerializeField] private TextMeshProUGUI energyInputText;
    [SerializeField] private TextMeshProUGUI energyOutputText;
    [SerializeField] private Transform rayImageTransform;

    [Header("Render")] 
    [SerializeField] private GameObject solarPanel3dGameObject;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                DeselectedPanel();
            }
        }
    }

    private void DeselectedPanel()
    {
        panelInformationPanel.SetActive(false);
        panelGlobalSunInformation.SetActive(true);
    }

    public void SelectedPanel(PanelPropertiesData data)
    {
        panelInformationPanel.SetActive(true);
        panelGlobalSunInformation.SetActive(false);
        
        //set details on canvas
        productIDText.text = $"Product ID - {data.id}";
        orientationAngleText.text = $"Angle <pos=50%>{data.orientationX}°";
        efficiencyText.text = $"Efficiency <pos=50%>{data.efficiency:P}";
        sizeText.text = $"Size <pos=50%>{data.size.x}m × {data.size.y}m";

        energyInputText.text = $"Incident Energy <pos=50%>{data.GetIncidentEnergy():f3}W";
        energyOutputText.text = $"Output Energy <pos=50%>{data.GetOutputEnergy():f3}W";
        
        rayImageTransform.eulerAngles = (SolarManager.Instance.angleOfSun - 90) * Vector3.forward;
        solarPanel3dGameObject.transform.eulerAngles = new Vector3(0, 0, -data.orientationX);
    }
}
