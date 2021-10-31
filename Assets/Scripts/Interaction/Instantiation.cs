using UnityEngine;

public class Instantiation : MonoBehaviour
{
    [SerializeField] private GameObject defaultGameObject;
    [SerializeField] private Transform instantiationParent;
    public void InstantiateGameObject(GameObject toInstantiate)
    {
        Instantiate(toInstantiate, transform.position, Quaternion.identity, instantiationParent);
    }

    public void InstantiateDefault()
    {
        InstantiateGameObject(defaultGameObject);
    }
    
}
