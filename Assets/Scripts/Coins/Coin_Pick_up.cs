using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin_Pick_up : MonoBehaviour
{
    // Creates a variable for storing the coin count
    public Coin_Storage coin;
    public GameObject player;
    public Rigidbody2D rb;
    public int coinsCollected;
    public Audio_manager audio_Manager;
    public Coin_List_Maker coin_List;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the coin amount to 0
        coin.coinAmount = 0;
        rb = GetComponent<Rigidbody2D>();
        coin.coinAmount = PlayerPrefs.GetInt("displayTextCoin");
    }

    // Update is called once per frame
    void Update()
    { 
     
    }

    public void FixedUpdate()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player colliders with the coin it destroys the coin and increases the coin storage by 1.
        if (collision.CompareTag("Coin"))
        {
            coin.coinAmount += 1;
            PlayerPrefs.SetInt("displayTextCoin", coin.coinAmount);
            collision.gameObject.SetActive(false);
            audio_Manager.sources.ToArray();
            AudioSource source = audio_Manager.sources[0];
            Debug.Log(source.outputAudioMixerGroup);
            source.Play();
            coin_List.UpdateCoin();
        }
    }
    
}
