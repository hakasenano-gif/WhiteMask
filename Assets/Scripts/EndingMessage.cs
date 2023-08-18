using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndingMessage : MonoBehaviour
{
    private float speed = 0.8f;
    private float transparent = 1;
    private bool Finished_stuffedRoll = false;
    public TextMeshProUGUI printStaff;
    RectTransform rect;

    void Start()
    {
        rect = GetComponent < RectTransform > ();

        printStaff.text =
          "<align=center>"  
        + "<SIZE=50>"
        + "素材提供者様"                                            +"\n\n" 
        + "<SIZE=30>"
        + "DOT ILLUST様\n https://dot-illust.net/terms/"           + "\n\n" 
        + "DOVA - SYNDROME様\n https://dova-s.jp/se/play674.html"  + "\n\n"
        + "ぴぽや様\n https://pipoya.net/"                          + "\n\n"
        + "Ayu ビットマップフォント様\n http://x-tt.osdn.jp/ayu.html"+"\n\n"
        + "自家製フォント工房様\n http://jikasei.me/font/jf-dotfont/"+ "\n\n"
        + "スプリンギン様\n https://www.springin.org/"             + "\n\n" 
        + "\n"
        + "<SIZE=50>"
        + "開発者"                                                  + "\n\n"
        + "<SIZE=30>"
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
        if (Input.GetKey (KeyCode.Escape)) speed += 4f;
    }
    void FixedUpdate()
    {
        if(Finished_stuffedRoll ==false)
        {
        transform.Translate (0,speed, 0);
        }
        if(transform.position.y >= 1600)
            {
                Finished_stuffedRoll = true;
                printStaff.text =
                "<align=center><SIZE=60> THANK YOU FOR PLAYING!!".ToString();
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
