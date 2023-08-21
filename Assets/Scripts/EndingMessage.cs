using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingMessage : MonoBehaviour
{
    private float speed = 3f;
    private float transparent = 1;
    [SerializeField]private float time_to_finish = 60;
    private bool Is_skipped = false;
    private bool Finished_stuffedRoll = false;
    public TextMeshProUGUI printStaff;
    RectTransform rect;

    void Start()
    {
        rect = GetComponent < RectTransform > ();

        printStaff.text =
          "<align=center>"  
        + "<SIZE=30>"
        + "素材提供者様"                                            +"\n\n" 
        + "<SIZE=15>"

        
        + "イラスト：DOT ILLUST様\n https://dot-illust.net/terms/"           + "\n\n" 
        + "イラスト：ぴぽや様\n https://pipoya.net/"                          + "\n\n"
        + "イラスト：ac-illust.com様\n https://www.ac-illust.com/"           + "\n\n"
        + "フォント：Ayu ビットマップフォント様\n http://x-tt.osdn.jp/ayu.html"+"\n\n"
        + "フォント：自家製フォント工房様\n http://jikasei.me/font/jf-dotfont/"+ "\n\n"
        + "効果音：DOVA - SYNDROME様\n https://dova-s.jp/se/play674.html"  + "\n\n"
        + "効果音：Springin’ Sound Stock様\n https://www.springin.org/"      + "\n\n" 
        + "音楽：Music-Note.jp様\n http://www.music-note.jp/"            + "\n\n"
        + "\n"
        + "<SIZE=30>"
        + "開発者"                                                  + "\n\n"
        + "<SIZE=15>"
        + "桜庭 侑星"                                               + "\n\n"
        + "大橋 聖司"                                               + "\n\n"
        + "竹内 陸翔"                                               + "\n\n"
        + "松本 天佑"                                               + "\n\n"
        + "関岡 空己"                                               + "\n\n"
        .ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey (KeyCode.Escape)) 
        {
            speed = 60f;
            Is_skipped = true;
        }
    }
    void FixedUpdate()
    {
        if(Finished_stuffedRoll ==false)
        {
        transform.Translate (0,speed, 0);
        }
        if(time_to_finish >=0) 
        {
            if(Is_skipped == false) time_to_finish -=Time.deltaTime;
            else time_to_finish -= 20*Time.deltaTime; /*50/speed*/
        }
        else if(Finished_stuffedRoll == false)
            {
                Finished_stuffedRoll = true;
                printStaff.text =
                "<align=center><SIZE=30> THANK YOU FOR PLAYING!!".ToString();
                rect.localPosition = new Vector3(0,0,0);
                StartCoroutine("FadeOut");
            }
    }

    IEnumerator FadeOut()
    {
        while(true)
        {
            printStaff.alpha = transparent;
	        transparent -= Time.deltaTime * 0.3f;
            if(transparent < 0) Destroy(gameObject);
            yield return null;
        }
    }
}
