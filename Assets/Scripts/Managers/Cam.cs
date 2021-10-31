using UnityEngine;

public class Cam : MonoBehaviour
{
    public static Camera main;

    private void Awake()
    {
        main = GetComponent<Camera>();
    }
}
