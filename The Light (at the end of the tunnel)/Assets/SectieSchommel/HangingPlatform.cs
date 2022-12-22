using UnityEngine;

public class HangingPlatform : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float rotationIntensity;
    [SerializeField] private float returnTime;
    private bool hasCollission;
    private TriggerArea triggerArea;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        triggerArea = GetComponentInChildren<TriggerArea>();
    }

    private void OnCollisionExit(Collision collision)
    {
        hasCollission = false;
    }
    private void FixedUpdate()
    {
        if (triggerArea.rigidbodiesInTriggerArea.Count == 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0f, transform.rotation.y, 0f)), Time.fixedDeltaTime * returnTime);
            return;
        }
        for (int i = 0; i < triggerArea.rigidbodiesInTriggerArea.Count; i++)
        {
            Rigidbody collision = triggerArea.rigidbodiesInTriggerArea[i];
            //Transform oldParent = collision.transform.parent;
            float distance = Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(collision.transform.position.x, collision.transform.position.z));

            Vector2 direction = new Vector2(transform.position.x, transform.position.z) - new Vector2(collision.transform.position.x, collision.transform.position.z);
            direction = direction.normalized;

            float relativeMass = collision.mass / rb.mass;

            Vector3 newRotation = new(-(direction.y * relativeMass) * rotationIntensity, transform.rotation.y, (direction.x * relativeMass) * rotationIntensity);

            //collision.transform.SetParent(transform);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), Time.fixedDeltaTime * returnTime);
            //collision.transform.SetParent(oldParent);
        }
    }

}

