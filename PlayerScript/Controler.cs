// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;

// public class SnakeHeadController : MonoBehaviour
// {
// 	public float MoveSpeed = 15f;
// 	public float SteerSpeed = 180;
// 	public int Gap = 1;
// 	public float BodySpeed = 5;
// 	public GameObject BodyPrefab;

// 	private List<GameObject> BodyParts = new List<GameObject>();
// 	private List<Vector3> PositionsHistory = new List<Vector3>();

// 	private bool createNodeTail = false;

// 	void Start()

// 	{
// 		GrowSnake();
	
// 	}
// 	void Update()
// 	{
// 		//move forward
// 		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
// 		//steer
// 		float steerDirection = Input.GetAxis("Horizontal");
// 		transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
// 		//store position history
// 		PositionsHistory.Insert(0, transform.position);
// 		//move body parts
// 		int index = 0;
// 		foreach (var body in BodyParts)
// 		{
// 			Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
// 			Vector3 moveDirection = point - body.transform.position;
// 			body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
// 			body.transform.LookAt(point);
// 			index++;
// 		}
// 	}

// 	private void GrowSnake()
// 	{
// 		GameObject body = Instantiate(BodyPrefab);
// 		BodyParts.Add(body);
// 	}
	
// 	//if(create_new_node_at_tail)
// 	//{

// 	//}
// 	//transform.position += transform.forward * MoveSpeed * Time.deltaTime;
// 	//transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
// 	//transform.Translate(forward);

// 	// private void OnCollisionEnter(Collision collision)
// 	// {
// 	// 	if (collision.gameObject.CompareTag("Wall"))
// 	// 	{
// 	// 		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart current scene
// 	// 	}
// 	// }

// 	// Example: Create a wall at runtime
// 	// GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
// 	// wall.transform.position = new Vector3(0, 0, 5);
// 	// wall.tag = "Wall";
// }
// 	//Grow snake if triggered
//         if (createNodeTail)
//         {
//             GrowSnake();
//             createNodeTail = false;
//         }
//     }

//     private void GrowSnake()
//     {
//         GameObject body = Instantiate(BodyPrefab);
//         BodyParts.Add(body);
//     }

//     private void OnTriggerEnter(Collider target)
//     {
//     //     if (target.CompareTag("Food"))
//     //     {
//     //         target.gameObject.SetActive(false);
//     //         createNodeTail = true;
//     //     }
//     //     if (target.CompareTag("Wall") || target.CompareTag("Boomb"))
//     //     {
//     //         Debug.Log("Touched BOOMB or Wall");
//     //         SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
//     //     }
//     // }
// }


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHeadController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float MoveSpeed = 15f;
    public float SteerSpeed = 180f;

    [Header("Body Settings")]
    public int Gap = 1;
    public float BodySpeed = 5f;
    public GameObject BodyPrefab;

    private List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> PositionsHistory = new List<Vector3>();

    private bool createNodeTail = false; // Trigger to grow snake

    void Start()
    {
        GrowSnake(); 
    }

    void Update()
    {
        // Move the snake head forward
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        // Steer the snake
        float steerDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        // Record current position for body movement
        PositionsHistory.Insert(0, transform.position);

        // Move each body segment
        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
            Vector3 moveDirection = point - body.transform.position;
            body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }

        // Grow snake if triggered
        if (createNodeTail)
        {
            GrowSnake();
            createNodeTail = false;
        }
    }

    private void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Food"))
        {
            target.gameObject.SetActive(false);
            createNodeTail = true; // Trigger body growth
        }
        else if (target.CompareTag("Wall") || target.CompareTag("Boomb"))
        {
            Debug.Log("Touched Wall or Boomb");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
        }
    }
}