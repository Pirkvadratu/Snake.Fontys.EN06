using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeHeadController : MonoBehaviour
{
	public float MoveSpeed = 15f;
	public float SteerSpeed = 180;
	public int Gap = 1;
	public float BodySpeed = 5;
	public GameObject BodyPrefab;

	private List<GameObject> BodyParts = new List<GameObject>();
	private List<Vector3> PositionsHistory = new List<Vector3>();


	void Start()
	{
		GrowSnake();
		
	}
	void Update()
	{
		//move forward
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		//steer
		float steerDirection = Input.GetAxis("Horizontal");
		transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);
		//store position history
		PositionsHistory.Insert(0, transform.position);
		//move body parts
		int index = 0;
		foreach (var body in BodyParts)
		{
			Vector3 point = PositionsHistory[Mathf.Min(index * Gap, PositionsHistory.Count - 1)];
			Vector3 moveDirection = point - body.transform.position;
			body.transform.position += moveDirection * BodySpeed * Time.deltaTime;
			body.transform.LookAt(point);
			index++;
		}
	}

	private void GrowSnake()
	{
		GameObject body = Instantiate(BodyPrefab);
		BodyParts.Add(body);
	}
	
	//if(create_new_node_at_tail)
	//{

	//}
	//transform.position += transform.forward * MoveSpeed * Time.deltaTime;
	//transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
	//transform.Translate(forward);

	// private void OnCollisionEnter(Collision collision)
	// {
	// 	if (collision.gameObject.CompareTag("Wall"))
	// 	{
	// 		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart current scene
	// 	}
	// }

	// Example: Create a wall at runtime
	// GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
	// wall.transform.position = new Vector3(0, 0, 5);
	// wall.tag = "Wall";
}
void OnTriggerEnter(Collider target)
{
	if (target.tag == Tags.FOOD)
	{
		target.gameObject.SetActive(false);
		create_Node_Tail = true;
	}
	if (target.tag == Tags.Wall || target.tag == Tags.BOOMB)
	{
		print("Touched BOOMB");
	}
}