using UnityEngine;

public class PanelCreator : MonoBehaviour
{
    [Header("Settings")]
    public KeyCode createKey;

    [Header("References")] 
    [SerializeField] private Transform instantiationParent;
    [SerializeField] private GameObject spawnPrefab;
    
    private void Update()
    {
        if (Input.GetKeyUp(createKey))
        {
            AddPanel();
        }
    }

    private void AddPanel()
    {
        Instantiate(spawnPrefab, instantiationParent);
    }
}
