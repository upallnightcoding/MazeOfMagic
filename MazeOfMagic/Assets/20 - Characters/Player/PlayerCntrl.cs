using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    private CharacterController controller = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position)
    {
        //controller.Move(position);

        controller.enabled = false;
        transform.position = position;
        controller.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Debug.Log("Character hit: " + hit.gameObject.name);

        //if (hit.gameObject.CompareTag("Player"))
        //{
            // Run collision logic here
        //}
    }
}
