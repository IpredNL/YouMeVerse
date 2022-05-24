using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HexaWorld : MonoBehaviour {
    // Start is called before the first frame update
    private Vector3 spawnPosition;
    public HexManager _hexManager;
    public GameObject HexaPrefab;



    string url = "http://localhost/opencv/data/hexas.json";

  
    HexagonJson hexjson;

    bool noServer = true;

 


    // Start is called before the first frame update
    void Start() {

        hexjson = new HexagonJson();

        if (noServer) {

            string json = Resources.Load<TextAsset>("hexas").text;
            hexjson.Set(HexaPrefab, json);


        } else {
            url = "http://localhost/~marcopieck/opencv/data/hexas.json";
            url = "http://192.168.1.62/~marcopieck/opencv/data/hexas.json";

            //hexjson = new HexagonJson();
            //hexjson.Set();
            StartCoroutine(MakeRequest());

            float sca = 10;

          

            /*
            MakeHexa(0*sca, 0*sca, 0, 7);
            MakeHexa(1*sca, 0*sca,10, 1);
            MakeHexa(1*sca, 1*sca, 30, 2);
            MakeHexa(-1 * sca, 1 * sca, 50, 3);
            MakeHexa(2 * sca, 0 * sca, 60, 4);
            MakeHexa(2 * sca, 0 * sca, 70, 5);
            MakeHexa(2 * sca, 1 * sca, 80, 6);
            MakeHexa(-2 * sca, 1 * sca, 90, 7);
            */

        }
    }

    IEnumerator MakeRequest() {


        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError) {
            Debug.Log(request.error);
        } else {
            string json = request.downloadHandler.text;
            try {
                hexjson.Set(HexaPrefab, json);
            } catch (System.Exception exc) {
                Debug.Log("err> json:" + json);
            }

            // Debug.Log("Received" + request.downloadHandler.text);

        }
        yield return new WaitForSeconds(0.1f);

        // uit zetten als je maar 1 keer wilt lezen. aanzetten als je elke 0.1 seconde wil lezen.
        //StartCoroutine(MakeRequest());
    }


    
}
