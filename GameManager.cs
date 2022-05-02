using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Player
    public GameObject[] players_1;
    public GameObject[] players_2;
    public GameObject[] players_3;
    public GameObject[] playersR;
    public GameObject[] playersL;
    //Panels
    public GameObject gameOverPanelGG;
    public GameObject gameOverPanelRG;
    public GameObject gameOverPanelUnentschieden;
    public GameObject credits;
    public GameObject gamepanel;
    public GameObject startpanel;
    public GameObject scene1;
    public GameObject scene2;
    //non plot twist
    bool isgameoverR = false; 
    bool isgameoverG = false;
    public bool gamekeys = false;
    //plot twist
    bool non_plot_twist = false;
    int player_counter_1 = 0;
    int player_counter_2 = 0;
    int player_counter_3 = 0;
    int player_counterG = 0;
    int player_counterR = 0;
   
    //Start is called before the first frame update
    void Start()
        {
            startpanel.SetActive(true);
            gamepanel.SetActive(false);
            gameOverPanelGG.SetActive(false);
            gameOverPanelRG.SetActive(false);
            gameOverPanelUnentschieden.SetActive(false);
            credits.SetActive(false);
        }
    
    void Update()
        {      
//non plot twist checker
            if(credits.activeInHierarchy) return;
            if(startpanel.activeInHierarchy) return;

            isgameoverR=true;
            isgameoverG=true;

            for(int i = 0; i < playersR.Length; i++)
            {
                if(playersR[i].activeInHierarchy)
                {
                    isgameoverG= false;
                    break;
                }
            }

            for(int i = 0; i < playersL.Length; i++)
            {
                if(playersL[i].activeInHierarchy)
                {
                    isgameoverR= false;
                    break;
                }
            }

            if (isgameoverG==true)
            {
                gameOverPanelRG.SetActive(true);
                gamepanel.SetActive(false);
                gameOverPanelUnentschieden.SetActive(false);
                gamekeys=false;
                non_plot_twist=true;
            }

            if (isgameoverR==true)
            {
                gameOverPanelGG.SetActive(true);
                gamepanel.SetActive(false);
                gameOverPanelUnentschieden.SetActive(false);
                gamekeys=false;
                non_plot_twist=true;
            }

 //plot twist checker
            for(int i = 0; i < players_1.Length; i++)
            {
                if(players_1[i].activeInHierarchy)
                {
                    player_counter_1++;
                }
            }

            for(int i = 0; i < players_2.Length; i++)
            {
                if(players_2[i].activeInHierarchy)
                {
                    player_counter_2++;
                }
            }

            for(int i = 0; i < players_3.Length; i++)
            {
                if(players_3[i].activeInHierarchy)
                {
                    player_counter_3++;
                }
            }

            if(player_counter_1<2&&player_counter_2<2&&player_counter_3<2&&non_plot_twist==false)
                {
                    for(int i = 0; i < playersR.Length; i++)
                    {
                        if(playersR[i].activeInHierarchy)
                        {
                            player_counterG++;
                        }
                    }

                    for(int i = 0; i < playersL.Length; i++)
                    {
                        if(playersL[i].activeInHierarchy)
                        {
                            player_counterR++;
                        }       
                    }

                    if(player_counterG<player_counterR)
                        {
                            gameOverPanelRG.SetActive(true);
                            gamepanel.SetActive(false);
                            gameOverPanelUnentschieden.SetActive(false);
                            gamekeys=false;
                        }

                    if(player_counterG>player_counterR)
                        {
                            gameOverPanelGG.SetActive(true);
                            gamepanel.SetActive(false);
                            gameOverPanelUnentschieden.SetActive(false);
                            gamekeys=false;
                        }

                    if(player_counterG==player_counterR)
                        {
                            gameOverPanelUnentschieden.SetActive(true);
                            gamepanel.SetActive(false);
                            gameOverPanelRG.SetActive(false);
                            gameOverPanelGG.SetActive(false);
                            gamekeys=false;
                        }
                }

            player_counter_1=0;
            player_counter_2=0;
            player_counter_3=0;
            player_counterG=0;
            player_counterR=0;
        }

public void Quit()
    {
        Application.Quit();
        Debug.Log("quit!");
    }

public void Credits()
    {
        gameOverPanelGG.SetActive(false);
        gameOverPanelRG.SetActive(false);
        gamepanel.SetActive(false);
        gameOverPanelUnentschieden.SetActive(false);
        startpanel.SetActive(false);
        credits.SetActive(true);
        gamekeys=false;
    }

public void MainMenu()
    {
        gameOverPanelGG.SetActive(false);
        gameOverPanelRG.SetActive(false);
        gameOverPanelUnentschieden.SetActive(false);
        gamepanel.SetActive(false);
        startpanel.SetActive(true);
        credits.SetActive(false);
        gamekeys=false;
    }

public void Restart()
    {
        isgameoverR= true;
        isgameoverG= true;
        gamekeys = true;
        non_plot_twist=false;
        player_counter_1=0;
        player_counter_2=0;
        player_counter_3=0;
        startpanel.SetActive(false);
        gamepanel.SetActive(true);
        gameOverPanelGG.SetActive(false);
        gameOverPanelRG.SetActive(false);
        gameOverPanelUnentschieden.SetActive(false);
        credits.SetActive(false);

        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag("tagwurfding");
        foreach(GameObject go in objectsToDestroy) 
            {
                Destroy(go);
            }
        
        for(int i = 0; i < playersR.Length; i++)
            {
                playersR[i].SetActive(true);
                playersR[i].GetComponent<Player>().leben=10;
                playersR[i].GetComponent<Player>().lebensleiste.fillAmount= 1F;
                playersR[i].GetComponent<Player>().ui.SetActive(true);
                playersR[i].GetComponent<Player>().wurftext.text =0.ToString();
                
            }

        for(int i = 0; i < playersL.Length; i++)
            {
                playersL[i].SetActive(true);
                playersL[i].GetComponent<Player>().leben=10;
                playersL[i].GetComponent<Player>().lebensleiste.fillAmount= 1F;
                playersL[i].GetComponent<Player>().ui.SetActive(true);
                playersL[i].GetComponent<Player>().wurftext.text =0.ToString();
            }
    }

public void SceneOne()
    {
        scene1.SetActive(true);
        scene2.SetActive(false);
    }


public void SceneTwo()
    {
        scene2.SetActive(true);
        scene1.SetActive(false);
    }
}
