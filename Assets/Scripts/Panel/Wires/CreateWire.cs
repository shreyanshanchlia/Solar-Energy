using System;
using UnityEngine;

public class CreateWire : MonoBehaviour
{
    [SerializeField] private GameObject wireLinePrefab;

    [SerializeField] private float snappingDistance;
    
    private LineRenderer _lineRenderer;
    private Vector2 startPosition;
    
    private void Start()
    {
        GameObject wire = Instantiate(wireLinePrefab, this.transform.position, Quaternion.identity, transform.parent);
        _lineRenderer = wire.GetComponent<LineRenderer>();
        wire.transform.Snap(snappingDistance);
        if (!SolarGrid.Instance.CheckForPanelAtPosition(wire.transform.position, null))
        {
            Destroy(wire);
            Destroy(gameObject);
        }
        _lineRenderer.SetPosition(0, wire.transform.position);
        _lineRenderer.SetPosition(1, wire.transform.position);
    }

    private void Update()
    {
        _lineRenderer.SetPosition(1, transform.position);
    }

    public void SetWire()
    {
        transform.Snap(snappingDistance);
        _lineRenderer.SetPosition(1, transform.position);
        if (SolarGrid.Instance.CheckForPanelAtPosition(transform.position, null))
        {
            //make a connection between panels
            SolarGrid.Instance.AddWiredLink(SolarGrid.Instance.GetPanelAtPosition(_lineRenderer.GetPosition(0)),
                SolarGrid.Instance.GetPanelAtPosition(transform.position));
            
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            Destroy(_lineRenderer.gameObject);
            //create an extension wire cord.
            // SolarGrid.Instance.AddWiredLink(SolarGrid.Instance.GetPanelAtPosition(_lineRenderer.GetPosition(0)),
            //     gameObject);
            // SolarGrid.Instance.AddLinkNode(gameObject);
        }
        enabled = false;
    }
}
