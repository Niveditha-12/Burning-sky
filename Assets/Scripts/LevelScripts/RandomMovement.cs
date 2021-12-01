using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

public class RandomMovement : MonoBehaviour
{
	public float moveSpeed = 5.0f;

	private float maxX, minX, maxY, minY;
	private float tChange = 0.0f; // force new direction in the first Update
	private float randomX;
	private float randomY;
	private float powerUP_Speed = -3f;
	private Rigidbody2D rigidBody;

	void Start()
	{
		maxX = 7f;
		minX = -7f;
		maxY = 3f;
		minY = -3f;
		/*if (Game_Control.SharedInstance.Level < 2)
		{
			SpawnObsatcle();
		}*/
	}

	void Update()
	{
		if(MenuManager.Instance.LevelNum == 0)  //if(Game_Control.SharedInstance.Level==0)
		{
			SpawnObsatcle();
        }

		if(MenuManager.Instance.LevelNum > 0) //if player has reached more than two levels then spawn obstacles at random positions with movement.
        {
			// change to a new random direction at random intervals
			if (Time.time >= tChange)
			{
				randomX = Random.Range(-2.0f, 2.0f);
				randomY = Random.Range(-2.0f, 2.0f); //  between -2.0 and 2.0 is returned
													 // set a random interval between 0.5 and 1.5
				tChange = Time.time + Random.Range(0.5f, 1.5f);
			}
			Vector3 newPosition = new Vector3(randomX, randomY, 0);
			transform.Translate(newPosition * moveSpeed * Time.deltaTime); //move to random positions.
																		   // if any boundary is hit, change direction.
			if (transform.position.x >= maxX || transform.position.x <= minX)
			{
				randomX = -randomX;
			}
			if (transform.position.y >= maxY || transform.position.y <= minY)
			{
				randomY = -randomY;
			}
			Vector3 clampedPosition = transform.position;
			clampedPosition.x = Mathf.Clamp(transform.position.x, minX, maxX);
			clampedPosition.y = Mathf.Clamp(transform.position.y, minY, maxY);
			transform.position = clampedPosition;
		}
		
	}

	public void SpawnObsatcle()
    {
		rigidBody = GetComponent<Rigidbody2D>();
		rigidBody.velocity = new Vector2(0, powerUP_Speed);
	}
	void OnTriggerEnter2D(Collider2D other)
	{


		if (other.gameObject.tag == "PlayerBullet")
		{	
			gameObject.SetActive(false);
			Game_Control.SharedInstance.playerScore += 1;

		}
		if (other.gameObject.tag == "Player")
		{
			if(Player_Control.SharedInstance.powerShield==false)
            {
				Game_Control.SharedInstance.playerScore -= 1;
			}
			
			
			gameObject.SetActive(false);

		}

	}
}
