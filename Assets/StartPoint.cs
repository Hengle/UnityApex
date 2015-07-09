using UnityEngine;
using System.Collections;
using Behaviours;

public class StartPoint : MonoBehaviour 
{

	// Use this for initialization
	void Start () {

        var go = new GameObject();
        var unit = go.AddComponent<ApexUnitBehavior>();
        Vector3 targetPoint = Vector3.zero;

        var unitFascade = new Apex.Units.UnitFacade();
        unitFascade.Initialize(go);
        
        Apex.Units.IUnitProperties unitProps = unitFascade;

        var CurrentRequest = new Apex.PathFinding.BasicPathRequest
        {
            from = unit.transform.position,
            to = targetPoint,
            type = Apex.PathFinding.RequestType.Normal,
            requester = unit,
            requesterProperties = unitProps,
            pathFinderOptions = unit
        };

        Apex.Services.GameServices.pathService.QueueRequest(CurrentRequest);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
