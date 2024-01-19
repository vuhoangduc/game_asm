using UnityEngine;
using UnityEngine.UI;

public class Lep_KidScript : MonoBehaviour
{
    public GameObject[] die;
    //xử lý ăn điểm
    int score = 0;
    private Text txtScore;
    //--
    public static bool isGameOver = false;
    public float speedX, speedY;//toc do theo truc X,Y
    private Animator player;//nhan vat
    private Rigidbody2D mBody;
    
    void Start()
    {
        txtScore = GameObject.Find("Score").GetComponent<Text>();//anh xa
        player = GetComponent<Animator>();//giong findViewByID
        mBody = GameObject.Find("Lep_Kid").GetComponent<Rigidbody2D>();
        //thiet lap cho player dung yen
        player.SetBool("isRun", false);
        player.SetBool("isStop", true);
        player.SetBool("isUp", false);
    }
    //ham xu ly va cham
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Coin"){ //neu va cham voi coin
            score++;//tang diem
            Destroy(collision.gameObject); //huy coin
            //xu ly hieu ung
            GameObject coin = Instantiate(die[0], gameObject.transform.position, Quaternion.identity);
            Destroy(coin, 1); //huy doi tuong
            txtScore.text = "Score: " + score.ToString();
        }
        if(collision.gameObject.tag == "Boss"){ //neu va cham voi coin
            score--;//tru diem
            Destroy(collision.gameObject); //huy mushroom
            txtScore.text = "Score: " + score.ToString();
            //xu ly hieu ung
            GameObject boss = Instantiate(die[1], gameObject.transform.position, Quaternion.identity);
            Destroy(boss, 3); //huy doi tuong sau 3s
            if(score<=0){
                Application.LoadLevel("Menu");
            }
        }
    }
    
    void Update()
    {
        if(!isGameOver)
        {
            if(Input.GetKey(KeyCode.LeftArrow))//nhan mui ten trai
            {
                //player hoat dong dung yen
                player.SetBool("isRun", true);
                player.SetBool("isStop", false);
                player.SetBool("isUp", false);
                //di chuyen
                gameObject.transform.Translate(Vector2.left * speedX * Time.deltaTime);
                //quay dau neu nguoc chieu
                if(gameObject.transform.localScale.x >0)
                {
                    gameObject.transform.localScale
                        = new Vector2(gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow))//nhan mui ten phai
            {
                //player hoat dong dung yen
                player.SetBool("isRun", true);
                player.SetBool("isStop", false);
                player.SetBool("isUp", false);
                //di chuyen
                gameObject.transform.Translate(Vector2.right * speedX * Time.deltaTime);
                //quay dau neu nguoc chieu
                if (gameObject.transform.localScale.x < 0)
                {
                    gameObject.transform.localScale
                        = new Vector2(gameObject.transform.localScale.x * -1,
                        gameObject.transform.localScale.y);
                }
            }
            else if(Input.GetKey(KeyCode.Space))//nhan dau cach
            {
                //player hoat dong dung yen
                player.SetBool("isRun", false);
                player.SetBool("isStop", false);
                player.SetBool("isUp", true);
                //nhan vat bay
                //neu muon nhay-> can dieu kien kiem tra mat san
                //if(gameObject.tag=="matsan")
                gameObject.GetComponent<Rigidbody2D>().velocity
                    = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,
                    speedY);
            }
            else
            {
                //player khong hoat dong
                player.SetBool("isRun", false);
                player.SetBool("isStop", true);
                player.SetBool("isUp", false);
            }
        }
    }
    
    public void moveRight()
    {
        //player hoat dong dung yen
        player.SetBool("isRun", true);
        player.SetBool("isStop", false);
        player.SetBool("isUp", false);
        //khai bao cac gia tri
        float foceX = 0f, foceY = 0f;
        //di chuyen theo truc x
        foceX = 150f;
        //xoay mat
        Vector2 scale = transform.localScale;
        scale.x = 1;
        transform.localScale = scale;
        //cap nhat vi tri moi
        mBody.AddForce(new Vector2(foceX, foceY));
    }
    
    public void moveLeft()
    {
        //player hoat dong dung yen
        player.SetBool("isRun", true);
        player.SetBool("isStop", false);
        player.SetBool("isUp", false);
        //khai bao cac gia tri
        float foceX = 0f, foceY = 0f;
        //di chuyen theo truc x
        foceX = -150f;
        //xoay mat
        Vector2 scale = transform.localScale;
        scale.x = -1;
        transform.localScale = scale;
        //cap nhat vi tri moi
        mBody.AddForce(new Vector2(foceX, foceY));
    }
    
    public void moveUp()
    {
        //player hoat dong dung yen
        player.SetBool("isRun", false);
        player.SetBool("isStop", false);
        player.SetBool("isUp", true);
        //khai bao cac gia tri
        gameObject.GetComponent<Rigidbody2D>().velocity
            = new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x,
                speedY);
    }
}
