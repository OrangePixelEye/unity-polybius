using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PolybiusManager : MonoBehaviour
{
    private static PolybiusManager instance;
    public static PolybiusManager Instance
	{
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<PolybiusManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject old_room;

	bool first_time = true;
	bool can_play = false;
	public bool CanPlay { get => can_play; set => can_play = value; }
	public bool First { get => first_time; }

    //MouseController mouse = new MouseController();

    [SerializeField]
    private TextMesh level;

    [SerializeField]
    private SpriteRenderer[] lifes;
    int lifesActive;

    [SerializeField]
    private Spawn spawn;

    public GameObject sanity;
    // Start is called before the first frame update
    void Start()
    {
        /*Fazer a conta levando em relação do tamanho do monitor(Map)*/
        //mouse.move(120);
        lifesActive = lifes.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setLive()
    {
        lifes[lifesActive].enabled = false;
        lifesActive--;
        if(lifesActive < 0)
        {
            lose();
			reset();
        }
    }

	void reset()
	{
		lifesActive = lifes.Length - 1;;
		for(int i = 0; i <= lifesActive; i++)
			lifes[i].enabled = true;
	}
    private void lose()
    {
		first_time = false;
        GameManager.Instance.Sanity -= spawn.Difficult + 10000;
        if(sanity != null) sanity.SetActive(true); 
        MapController.Instance.changeMap(old_room);
    }
}
