using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	public GameObject doski;
	public GameObject lamps;
    public GameObject NewGameA;
    public GameObject ContinueA;
    public GameObject EndLessA;
    public GameObject OptionsA;
    public GameObject ExitA;
    public GameObject mem;
    public GameObject Buttons;
    public GameObject Warning;
    public GameObject Bugs;
    public GameObject Scene;
    public GameObject Intro;
    public GameObject Skip;
    private short incr = 0;

    public string nameScene;

    public void AudioChange(){
        if(Infos.AudioOn) Infos.AudioOn = false;
        else Infos.AudioOn = true;
    }

    public void NewGame()
    {
        Buttons.SetActive(false);
        if (Infos.viewLvl() != 0)
        {
            Warning.SetActive(true);
        }
        else NewGameYes();

  //      Infos.newLvl();
  //      Infos.Save();
  //      NewGameA.SetActive(true);
  //      mem = NewGameA;
  //      nameScene = "Map 1";
		//lamps.gameObject.SetActive (true);
		//doski.gameObject.SetActive (false);
  //      StartCoroutine(Animat());
    }

    public void Skiple()
    {
        incr++;
        if (incr == 2)
            SceneManager.LoadScene(nameScene);
    }

    public void NewGameNo()
    {
        Buttons.SetActive(true);
        Warning.SetActive(false);
    }
    public void NewGameYes()
    {
        Warning.SetActive(false);
        Infos.newLvl();
        Infos.Save();
        NewGameA.SetActive(true);
        mem = NewGameA;
        nameScene = "Map 1";
        lamps.gameObject.SetActive(true);
        doski.gameObject.SetActive(false);
        StartCoroutine(Animat(true));
    }
    public void Continue()
    {
        ContinueA.SetActive(true);
        mem = ContinueA;
        nameScene = "Map 1";
		lamps.gameObject.SetActive (true);
		doski.gameObject.SetActive (false);
        StartCoroutine(Animat());
    }
    public void EndLess()
    {
        EndLessA.SetActive(true);
        mem = EndLessA;
        nameScene = "Map 1";
		lamps.gameObject.SetActive (true);
		doski.gameObject.SetActive (false);
        StartCoroutine(Animat());
    }
    public void Options()
    {
        OptionsA.SetActive(true);
        mem = OptionsA;
        nameScene = "Map 1";
		lamps.gameObject.SetActive (true);
		doski.gameObject.SetActive (false);
        StartCoroutine(Animat());
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ToTricksterHouse()
    {
        SceneManager.LoadScene("TricksterHouse");
    }

    public void ToMap()
    {
        SceneManager.LoadScene("Map 1", LoadSceneMode.Single);
    }

    IEnumerator Animat(bool NwGm = false)
    {
        yield return new WaitForSeconds(0.9f);
        mem.SetActive(false);
        if(NwGm)
            StartCoroutine(IntroIE());
        else
            SceneManager.LoadScene(nameScene);
    }

    IEnumerator IntroIE()
    {
        Intro.SetActive(true);
        Skip.SetActive(true);
        Scene.SetActive(false);
        Bugs.SetActive(false);
        Buttons.SetActive(false);
        doski.SetActive(false);
        yield return new WaitForSeconds(49f);
        //mem.SetActive(false);
        SceneManager.LoadScene(nameScene);
    }
}
