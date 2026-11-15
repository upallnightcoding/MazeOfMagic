using UnityEngine;

public class PlayerCntrl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPosition(Vector3 position)
    {
        gameObject.transform.position = position;
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
