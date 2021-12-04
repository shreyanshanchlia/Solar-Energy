using UnityEngine;

[System.Serializable]
public class PanelPropertiesData
{
     string _id;
    public string id
    {
        get
        {
            if (string.IsNullOrEmpty(_id)) Debug.LogError("No Panel Found!");
            return _id;
        }
    }
    public float orientationX;
    public float efficiency;
    public Vector2 size;

    public PanelPropertiesData(int panelNumber)
    {
        NewID(panelNumber);
        orientationX = 0f;
        efficiency = 0.2f;
        size = Vector2.one;
    }

    void NewID(int panelNumber)
    {
        _id = System.Guid.NewGuid().ToString().Substring(4,10) + panelNumber.ToString("D4");
    }

    public float GetIncidentEnergy()
    {
        return Mathf.Clamp(SolarManager.Instance.TotalSunEnergy * size.x * size.y * 
                           Mathf.Sin(Mathf.Deg2Rad * (SolarManager.Instance.angleOfSun + orientationX)),
            0, SolarManager.Instance.TotalSunEnergy);
    }

    public float GetOutputEnergy()
    {
        return GetIncidentEnergy() * efficiency;
    }
}
