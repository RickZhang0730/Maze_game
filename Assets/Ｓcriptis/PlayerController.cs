using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   
    [Header("水平方向")]
    public float moveX;

    [Header("垂直方向")]
    public float moveY;

    [Header("推力")]
    public float push;

    Rigidbody2D rb2D;//剛體 用以被施力

    [Header("分數文字UI")]
    public Text countText;//不是字串

    [Header("過關文字UI")]
    public Text winText;//不是字串

    int score;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D> ();

        winText.text = "";//清空文字
        setScoreText();//目前分數0
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveX = Input.GetAxis ("Horizontal");
        //水平移動//

        moveY = Input.GetAxis ("Vertical");
        //垂直移動//

        Vector2 movement = new Vector2 (moveX, moveY);
        //2維方向 

        rb2D.AddForce (push * movement);
        //rb2D.施加力量
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log (name+ "觸發了" +other.name);

        if (other.CompareTag("PickUp"))
        //其他.比較標籤
            {
              other.gameObject.SetActive(false);
              //其他.遊戲物件.設定狀態（否）

              score = score + 1;
              setScoreText();

            }
    }

    void setScoreText(){
        countText.text = "Current Score: " + score.ToString( );

        if (score>=12)
        {
            winText.text = "You Win !!";

        }
    }
}
