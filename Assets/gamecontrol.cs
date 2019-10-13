using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamecontrol : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randompos;
    public float startwait;
    public float loopwait;
    public float creatwait;
    public Text text;
    bool oyunbittikontrol = false;
    bool oyunbaskontrol = false;
    int score;
    public Text oyunbittitext;
    public GameObject yenidenBaslaButonu;
    void Start()
    {
        score =0;
        text.text = "score=" + score;


        StartCoroutine(olustur()); 

    }
 


    public void YenidenBasla()
    {
        if (oyunbaskontrol)
        {
            SceneManager.LoadScene("levelson");
        }
        
    }
    IEnumerator olustur()
    {
        
        yield return new WaitForSeconds(startwait);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randompos.x, randompos.x), 0, randompos.z); //random olusturma
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(loopwait);

            }
            if (oyunbittikontrol)
            {
                yenidenBaslaButonu.SetActive(true);
               
                oyunbaskontrol = true;
                break;
            }
            yield return new WaitForSeconds(creatwait);




        }

        
        
    }
    public void scorearttir(int gelenscore)
    {
        score += gelenscore;
        text.text = "score=" + score;
        Debug.Log(score);
    }
    public void gameover()
    {
        oyunbittitext.text = "GAME OVER";
        oyunbittikontrol = true;
    }

}
