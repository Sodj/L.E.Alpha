using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
namespace LEAlpha
{
    public class Lib : MonoBehaviour {

        public static int HP = 3;
        public static GameObject damageSound;
        public static GameObject player;

        public static void TakeDamage(int damage){
            // Play sound
            player = GameObject.Find("pecman");
            Player playerScript = player.GetComponent<Player>();
            
            damageSound = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/DamageSound.prefab",typeof(GameObject));
            Instantiate(damageSound, player.transform.position, Quaternion.identity);

            // Trigger damage animation

            // Decrease player HP
            HP -= damage;

            // Update HP UI
            Debug.Log("HP: "+HP);

            // Reset if HP == 0
            if(HP <= 0) {
                HP = 3;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
