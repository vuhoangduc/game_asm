using UnityEngine;

public class WorkScript : MonoBehaviour
{
    public float ColoseDistanceFromPlayer;
    public GameObject[] GroundTile; //chứa cac địa hình
    public Transform Player; //nhan vat
    public float TileWidth; //độ dài của địa hình
    
    void Update()
    {
        if(Vector3.Distance(Player.position, transform.position) <= ColoseDistanceFromPlayer){
            SpawnTile(2);
        }
    }
    
    void SpawnTile(int n){
        int i=0;
        while (i<n)
        {
            int ran = Random.Range(0,n);//lay ngay nhien 1 chỉ số địa hình
            Instantiate(GroundTile[ran], transform.position, Quaternion.identity);//tạo địa hình
            i++;
            transform.position += TileWidth*Vector3.right; //cap nhat vi tri mới
        }
    }
}
