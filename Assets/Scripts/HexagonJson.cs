using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

/*

*/




public class HexagonJson {
    // Start is called before the first frame update
    public HexaWorld _hexaWorld;

    float scale = 1;
    float posx = 0;
    float posy = 0;

    struct Key {
        public int id;
    }

    class Hexa {
        public int frameCount = 0;
        public float x;
        public float y;
        public float rot;
        public GameObject go;
    }

    Dictionary<Key, List<Hexa>> hexas = new Dictionary<Key, List<Hexa>>();

    public void Set(GameObject HexaPrefab, string json = null) {
        if (json == null) {
            json = Resources.Load<TextAsset>("example").text;
        }
        var o = JObject.Parse(json);




        JToken token;
        //JObject item = default;



        if (o.TryGetValue("scale", out token)) {
            scale = 0.019f * (float)token;
        }
        if (o.TryGetValue("x", out token)) {
            posx = (float)token;
        }
        if (o.TryGetValue("y", out token)) {
            posy = (float)token;
        }

        int fc = Time.frameCount;

        if (o.TryGetValue("hexas", out token)) {
            var lst = token.Children();
            foreach (var it in lst) {
                float x = -it.Value<float>("x");
                float y = it.Value<float>("y");
                float rot = 30 + it.Value<float>("rot");

                int id = it.Value<int>("id");
                //string obj = it.Value<string>("obj");

                var key = new Key { id = id };

                Vector2 p0 = new Vector2(x, y);

                Hexa hexa = default;


                if (hexas.TryGetValue(key, out var hs)) {
                    float mdist = float.MaxValue;
                    bool add = true;
                    foreach (var h in hs) {
                        if (h.frameCount != fc) {
                            Vector2 p = new Vector2(h.x, h.y);
                            float d = Vector2.Distance(p, p0);
                            if (d < mdist) {
                                mdist = d;
                                hexa = h;
                                add = false;
                            }
                        }
                    }
                    if (add) {
                        hexa = new Hexa();
                        hs.Add(hexa);
                        hexa.go = MakeHexa(HexaPrefab, x, y, rot, id);// hexObj(hex, obj);
                    }
                } else {
                    hexa = new Hexa();
                    hexas[key] = new List<Hexa> { hexa };
                    hexa.go = MakeHexa(HexaPrefab, x, y, rot, id);
                }
                hexa.frameCount = fc;
                hexa.x = x;
                hexa.y = y;
                hexa.rot = rot;
                //Transform t = hexa.go.transform;
                //t.position = new Vector3(x * scale, 0, y * scale);
                //t.rotation = Quaternion.Euler(0, rot, 0);
            }
            //

            foreach (var kv in hexas) {
                var hlst = kv.Value;
                int cnt = hlst.Count;
                int i = 0;
                while (i < cnt) {
                    var hexa = hlst[i];
                    if (hexa.frameCount != fc) {
                        GameObject.Destroy(hexa.go);
                        hlst.RemoveAt(i);
                        cnt--;
                    } else {
                        i++;
                    }
                }
            }

        }

    }




    GameObject MakeHexa(GameObject HexaPrefab, float xPos, float yPos, float Rotation, int hexaId) {

        string word = "unknown";
        int _material = 0;
       // int _material2 = 0;

        if (Database.data.TryGetValue(hexaId, out Database.Item item)) {
            word = item.text;
            _material = item.matId;
           // _material2 = item.innerMatId;
        }

        GameObject SpawnLocation = GameObject.FindGameObjectWithTag("Test");
        Vector3 spawnPosition = SpawnLocation.transform.position;
        spawnPosition.x = spawnPosition.x + 0.01f* xPos;
        spawnPosition.y = spawnPosition.y + 0.1f;
        spawnPosition.z = spawnPosition.z + 0.01f *yPos; // is nu Z ivm vector 3 anders is Y omhoog.
                                //hexaId--;
        Debug.Log("hexaid "+hexaId);

        GameObject instance = GameObject.Instantiate(HexaPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, Rotation,0)));
        instance.GetComponent<spawnInfo>().hexIndex = hexaId;
        
        // instance.GetComponent<SpawnHex>().SetText(word);
        //instance.GetComponent<SpawnHex>().SetMaterial(_material);

        return instance;
    }


    /*
    private GameObject hexObj(string hex, string obj) {
        GameObject go = new GameObject("h_" + hex + "." + obj);
        GameObject hexo = GameObject.Instantiate(Resources.Load<GameObject>("Hexagons/" + hex));
        GameObject objo = GameObject.Instantiate(Resources.Load<GameObject>("Objects/" + obj));
        hexo.transform.parent = go.transform;
        hexo.transform.localPosition = Vector3.zero;
        hexo.transform.localScale = Vector3.one;
        hexo.transform.localRotation = Quaternion.identity;
        objo.transform.parent = go.transform;
        objo.transform.localPosition = Vector3.zero;
        objo.transform.localScale = Vector3.one;
        objo.transform.localRotation = Quaternion.identity;
        return go;
    }

    */
}
