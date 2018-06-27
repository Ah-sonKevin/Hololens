//Attach this script to a GameObject.
//Create a Text GameObject (Create>UI>Text) and attach it to the My Text field in the Inspector of your GameObject
//Press the space bar in Play Mode to see the Text change.

using UnityEngine;
using UnityEngine.UI;

public class textScript : MonoBehaviour
{
    public Text m_MyText;
   

    void Start()
    {
        //Text sets your text to say this message
        m_MyText.text = "Flag is off";
    }

    void Update()
    {
        //Press the space key to change the Text message
        if (FlagScript.flag)
            
         
            {
            m_MyText.text = "Flag has changed.";
        }
        Debug.LogError(m_MyText);
    }
}