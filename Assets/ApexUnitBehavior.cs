using System;
using System.Collections.Generic;
using UnityEngine;

using Apex.Common;
using Apex.PathFinding;
using Apex.Services;
using Apex.Units;
using Apex.Steering;

namespace Behaviours
{
    public class ApexUnitBehavior : MonoBehaviour, INeedPath, IUnitProperties,
                                    IMovable, IMovingObject, IDefineSpeed,
                                    IPathFinderOptions, IPathNavigationOptions
    {

        protected float prefferedSpeed;
        protected bool acceptMovementOrders = true;
        protected Vector3 nextPosition;
        protected Nullable<Vector3> _finalDestination;
        protected List<Vector3> _currentWaypoints;
        protected Path _currentPath;


        //INeedPath
        public virtual void ConsumePathResult(PathResult result)
        {
            Debug.LogWarning("Received path " + result);
            //throw new NotImplementedException();
        }

        //IUnitProperties
        public float radius { get { return 0.1f; } }

        //Gets the unit's field of view in degrees. 
        public float fieldOfView
        {
            get { return 360; }
        }

        //Gets the offset between the unit's lower most point where it will touch the ground (touchdownPosition) 
        //and its position, typically the bottom of its collider to its position (y delta). 
        public float baseToPositionOffset
        {
            get { return 0; }
        }

        public float height
        {
            get { return 1; }
        }

        //Gets the position where the unit touches the ground (if it is grounded). 
        //This is its position offset by baseToPositionOffset
        public UnityEngine.Vector3 basePosition
        {
            get { return default(UnityEngine.Vector3); }
        }

        public HeightNavigationCapabilities heightNavigationCapability
        {
            get { return default(HeightNavigationCapabilities);  }
        }

        //Gets a value indicating whether this instance is selectable. 
        public bool isSelectable
        {
            get { return true;  }
        }

        public bool isSelected { get; set; }

        //Gets or sets the determination factor used to evaluate whether this unit separates or avoids other units. 
        //The higher the determination, the less avoidance/separation. 
        public int determination { get; set; }

        public void RecalculateBasePosition()
        {
            //TODO: Implement
            //throw new NotImplementedException();
        }

        public void MarkSelectPending(bool pending)
        {
            throw new NotImplementedException();
        }

        public UnityEngine.Vector3 position
        {
            get { return gameObject.transform.position; }
        }

        public AttributeMask attributes { get { return new AttributeMask(); } }

        //IMovable

        public Path currentPath
        {
            get { return _currentPath; }
        }

        public Apex.DataStructures.IIterable<Vector3> currentWaypoints
        {
            get { return (Apex.DataStructures.IIterable<Vector3>) _currentWaypoints; }
        }

        public UnityEngine.Vector3? finalDestination
        {
            get { return _finalDestination; }
        }

        public UnityEngine.Vector3? nextNodePosition
        {
            get { throw new NotImplementedException(); }
        }

        //Asks the object to move along the specified path. Replanning is done by the path finder. 
        public void MoveTo(UnityEngine.Vector3 position, bool append)
        {
            nextPosition = position;
        }

        public void MoveAlong(Path path)
        {
            _currentPath = path;
        }

        public void MoveAlong(Path path, ReplanCallback onReplan)
        {
            _currentPath = path;
        }

        //Enables the movement orders following a call to DisableMovementOrders(). 
        public void EnableMovementOrders()
        {
            acceptMovementOrders = true;
        }

        //Disables movement orders, i.e. calls to MoveTo(Vector3, Boolean) will be ignored until 
        //EnableMovementOrders() is called. 
        public void DisableMovementOrders()
        {
            acceptMovementOrders = false;
        }

        //IMovingObject

        public UnityEngine.Vector3 velocity { get; set; }
        public UnityEngine.Vector3 actualVelocity { get; set; }

        public bool isGrounded
        {
            get { return true; }
        }

        public virtual void Stop()
        {
            //TargetPoint = Vector3.zero;
            //CurrentRequest = null;
            //Path.Clear();
        }

        public void Wait(float? seconds)
        {
            //TODO: Implement
            //throw new NotImplementedException();
        }

        public void Resume()
        {
            //TODO: Implement
           //throw new NotImplementedException();
        }

        //IPathFinderOptions

        public int pathingPriority { get; set; }

        public int maxEscapeCellDistanceIfOriginBlocked { get; set; }

        public bool usePathSmoothing { get; set; }

        public bool allowCornerCutting { get; set; }

        public bool preventDiagonalMoves { get; set; }

        public bool navigateToNearestIfBlocked { get; set; }

        //IPathNavigationOptions

        public float nextNodeDistance { get; set; }

        public float requestNextWaypointDistance { get; set; }

        public bool announceAllNodes { get; set; }
        public ReplanMode replanMode { get; set; }

        public float replanInterval { get; set; }

        //IDefineSpeed

        public float maxAcceleration
        {
            get { return 1; }
        }

        public float maxDeceleration
        {
            get { return 1; }
        }

        public float maxAngularAcceleration
        {
            get { return 1; }
        }

        public float minimumSpeed
        {
            get { return 1; }
        }

        public float maximumSpeed
        {
            get { return 1; }
        }

        public float maximumAngularSpeed
        {
            get { return 1; }
        }

        public void SignalStop()
        {
            throw new NotImplementedException();
        }

        public void SetPreferredSpeed(float speed)
        {
            prefferedSpeed = speed;
        }

        public float GetPreferredSpeed(UnityEngine.Vector3 currentMovementDirection)
        {
            return prefferedSpeed;
        }

        public void CloneFrom(IDefineSpeed speedComponent)
        {
            throw new NotImplementedException();
        }
    }
}
