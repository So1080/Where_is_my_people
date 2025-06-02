using UnityEngine;

public class FollowThePath : MonoBehaviour {

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

	// Use this for initialization
	private void Start () {

        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {

        // Move Enemy
        Move();
	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector3.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;

                // Reset to the first waypoint if the last waypoint is reached
                if (waypointIndex == waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }

            // Rotate Enemy to face the next waypoint
            Vector3 targetInVec3 = new Vector3(waypoints[waypointIndex].transform.position.x, transform.position.y, waypoints[waypointIndex].transform.position.z);
            Vector3 direction2 = targetInVec3 - transform.position;
            float angle = Mathf.Atan2(direction2.x, direction2.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);

            // Ensure the capsule's local "up" aligns with the waypoint direction
            transform.rotation = rotation;
        }
    }
}
