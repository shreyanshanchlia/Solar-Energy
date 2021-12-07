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
    [SerializeField] private TMP_InputField orientationAngleInputField;
    [SerializeField] private TMP_InputField efficiencyInputField;
    [SerializeField] private TMP_InputField sizeTextXInputField;
    [SerializeField] private TMP_InputField sizeTextYInputField;
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

    public void SelectedPanel(GameObject panelProperties)
    {
        PanelPropertiesData data = panelProperties.GetComponent<PanelProperties>().panelPropertiesData;
        
        panelInformationPanel.SetActive(true);
        panelGlobalSunInformation.SetActive(false);
         
        rayImageTransform.eulerAngles = (SolarManager.Instance.angleOfSun - 90) * Vector3.forward;
        solarPanel3dGameObject.transform.eulerAngles = new Vector3(0, 0, -data.orientationX);
        
        orientationAngleInputField.onValueChanged = new TMP_InputField.OnChangeEvent();
        efficiencyInputField.onValueChanged = new TMP_InputField.OnChangeEvent();
        sizeTextXInputField.onValueChanged = new TMP_InputField.OnChangeEvent();
        sizeTextYInputField.onValueChanged = new TMP_InputField.OnChangeEvent();

        RefreshInputFields();
        
        //set details on canvas
        productIDText.text = $"Product ID - {data.id}";
        energyInputText.text = $"Incident Energy <pos=50%>{data.GetIncidentEnergy():f3}W";
        energyOutputText.text = $"Output Energy <pos=50%>{data.GetOutputEnergy():f3}W";
        
        orientationAngleInputField.text = $"{data.orientationX}";
        efficiencyInputField.text = $"{data.efficiency}";
        sizeTextXInputField.text = $"{data.size.x}";
        sizeTextYInputField.text = $"{data.size.y}";
        
        OnOrientationChangeSubscribe(panelProperties);
        OnEfficiencyChangeSubscribe(panelProperties);
        OnSizeXChangeSubscribe(panelProperties);
        OnSizeYChangeSubscribe(panelProperties);
    }

    void RefreshInputFields()
    {
        TMP_InputField tmpInputField = Instantiate(orientationAngleInputField, orientationAngleInputField.transform.parent);
        tmpInputField.gameObject.name = "InputField (TMP)";
        Destroy(orientationAngleInputField.gameObject);
        orientationAngleInputField = tmpInputField;
        
        tmpInputField = Instantiate(efficiencyInputField, efficiencyInputField.transform.parent);
        tmpInputField.gameObject.name = "InputField (TMP)";
        Destroy(efficiencyInputField.gameObject);
        efficiencyInputField = tmpInputField;
        
        tmpInputField = Instantiate(sizeTextXInputField, sizeTextXInputField.transform.parent);
        tmpInputField.gameObject.name = "InputField (TMP)";
        Destroy(sizeTextXInputField.gameObject);
        sizeTextXInputField = tmpInputField;
        
        tmpInputField = Instantiate(sizeTextYInputField, sizeTextYInputField.transform.parent);
        tmpInputField.gameObject.name = "InputField (TMP)";
        Destroy(sizeTextYInputField.gameObject);
        sizeTextYInputField = tmpInputField;
    }
    
    void OnOrientationChangeSubscribe(GameObject panelProperties)
    {
        orientationAngleInputField.onEndEdit.AddListener((val) =>
        {
            if (float.TryParse(val, out panelProperties.GetComponent<PanelProperties>().panelPropertiesData.orientationX))
                SelectedPanel(panelProperties);
        });
    }
    void OnEfficiencyChangeSubscribe(GameObject panelProperties)
    {
        efficiencyInputField.onEndEdit.AddListener((val) =>
        {
            if (float.TryParse(val, out panelProperties.GetComponent<PanelProperties>().panelPropertiesData.efficiency))
                SelectedPanel(panelProperties);
        });
    }
    void OnSizeXChangeSubscribe(GameObject panelProperties)
    {
        sizeTextXInputField.onEndEdit.AddListener((val) =>
        {
            if (float.TryParse(val, out panelProperties.GetComponent<PanelProperties>().panelPropertiesData.size.x))
                SelectedPanel(panelProperties);
        });
    }
    void OnSizeYChangeSubscribe(GameObject panelProperties)
    {
        sizeTextYInputField.onEndEdit.AddListener((val) =>
        {
            if (float.TryParse(val, out panelProperties.GetComponent<PanelProperties>().panelPropertiesData.size.y))
                SelectedPanel(panelProperties);
        });
    }
}
