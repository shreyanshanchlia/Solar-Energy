using System;
using TMPro;
using UnityEngine;

public class SolarManager : MonoBehaviour
{
    public static SolarManager Instance;
    private void Awake() => Instance = this;

    //STC Conditions
    private float SolarIrradiance = 1000f;
    public float angleOfSun = 90;
    public float atmosphereDensity = 1f;

    public float TotalSunEnergy => SolarIrradiance / atmosphereDensity;
    public float TotalSunEnergyOnGround => SolarIrradiance / atmosphereDensity * Mathf.Sin(Mathf.Deg2Rad * angleOfSun);

    //[Header("References")] [SerializeField] private TextMeshProUGUI timeOfDayText;
    
    public void UpdateAngleOfSun(float value)
    {
        angleOfSun = value;
        //timeOfDayText.text = //TODO
    }

    public void UpdateAtmosphereDensity(float value)
    {
        atmosphereDensity = value;
    }
}
