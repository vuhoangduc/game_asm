using UnityEngine;

public class BossScript : MonoBehaviour
{
    public float speed;
    public bool checkHeal;

    void Update()
    {
        Vector2 diChuyen = transform.position;
        if(checkHeal){
            diChuyen.x -= speed * Time.deltaTime;
        }else{
            diChuyen.x += speed * Time.deltaTime;
        }
        transform.position = diChuyen;
    }
    //detech thay đổi trạng thái
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "Head"){
            checkHeal = true;
            quayLai();
        }
        if(collision.gameObject.tag == "Tail"){
            checkHeal = false;
            quayLai();
        }
    }
    
    void quayLai(){
        //đổi hướng mặt của vật khi đổi hướng
        Vector2 huongQuay = transform.localScale;
        huongQuay.y *= -1;
        transform.localScale = huongQuay;
    }
}
