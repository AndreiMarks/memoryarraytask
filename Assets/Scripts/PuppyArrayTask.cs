using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PuppyArrayTask : MonoBehaviour 
{
    public PuppyArray puppyArrayPrefab; 
    public PuppyArray left;
    public PuppyArray right;

    public Text phaseText;
    public int phaseNumber;
    
    public string focusSide;
    public Arrow arrow;

	void Start () 
    {
        CreatePuppyArrays();
        focusSide = GetRandomFocusSide();
	}

    void Update()
    {
        if ( ChangePhase() )
        {
            GoToNextPhase();
        }

        if ( phaseNumber == 1 )
        {
            DoPhase1();
        } else if ( phaseNumber == 2 ) {
            DoPhase2();
        } else if ( phaseNumber == 3 ) {
            DoPhase3();
        } else if ( phaseNumber == 4 ) {
            DoPhase4();
        }
        

        CheckInput();      
    }

    public void CreatePuppyArrays()
    {
        left = Instantiate( puppyArrayPrefab, Vector3.left * 10f, Quaternion.identity ) as PuppyArray; 
        right = Instantiate( puppyArrayPrefab, Vector3.right * 10f, Quaternion.identity ) as PuppyArray; 
    }

    private void GoToNextPhase()
    {
        Color randomColor = new Color( Random.value, Random.value, Random.value );
        Camera.main.backgroundColor = randomColor;

        phaseNumber++;
        if ( phaseNumber > 4 )
        {
            phaseNumber = 1;
        }


        phaseText.text = phaseNumber.ToString();
    }

    private void DoPhase1()
    {
        //Debug.Log( "I'm doing phase one." );
    }

    private void DoPhase2()
    {
        Debug.Log( "I'm doing phase two." );
    }

    private void DoPhase3()
    {
        Debug.Log( "I'm doing phase three." );
    }

    private void DoPhase4()
    {
        Debug.Log( "I'm doing phase four." );
    }

    private void CheckInput()
    {
        if ( GetLeftInput() )
        {
            left.gameObject.SetActive( true );
            Debug.Log( !left.gameObject.activeSelf );
        } else {
            
            left.gameObject.SetActive(  false  );
        }

        if ( GetRightInput() )
        {
            right.gameObject.SetActive( true );
            Debug.Log( !right.gameObject.activeSelf );
        } else {
            right.gameObject.SetActive( false );
        }
    }

    private string GetRandomFocusSide()
    {
        float randomNumber = Random.value;

        if ( randomNumber < .5f )
        {
            arrow.ShowLeftArrow();
            return "left";        
        } else {
            arrow.ShowRightArrow();
            return "right";
        }
    }

    private bool GetLeftInput()
    {
        return Input.GetKey( KeyCode.LeftArrow );
    }

    private bool GetRightInput()
    {
        return Input.GetKey( KeyCode.RightArrow );
    }

    private bool ChangePhase()
    {
        return Input.GetKeyDown( KeyCode.Space );
    }
}
