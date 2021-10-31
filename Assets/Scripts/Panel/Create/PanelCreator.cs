using UnityEngine;

public class PanelCreator : MonoBehaviour
{
    [Header("Settings")]
    public KeyCode createPanelKey;

    [Header("References")] 
    [SerializeField] private Transform solarGrid;
    [SerializeField] private GameObject solarPanelPrefab;
    
    private void Update()
    {
        if (Input.GetKeyUp(createPanelKey))
        {
            AddPanel();
        }
    }

    private void AddPanel()
    {
        Instantiate(solarPanelPrefab, solarGrid);
    }
}
