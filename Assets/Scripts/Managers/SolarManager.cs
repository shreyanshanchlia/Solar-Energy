using System;
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
}
