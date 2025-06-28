using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;

using EmbedIO;
using EmbedIO.WebSockets;
public class SiteServer : MonoBehaviour
{

    [SerializeField] int port;
    // Start is called before the first frame update


    void Start()
    {

        var url = $"http://{GetLocalIPAddr()}:{port}/";

        CreateServer(url).RunAsync();

        Texture2D texture = new Texture2D(256, 256);

        QRGenerator.EncodeString(url, ref texture);

        GetComponent<MeshRenderer>().material.mainTexture = texture;



    }

    public static string GetLocalIPAddr()
    {
        string localIP = "127.0.0.1";
        foreach (var ip in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
        {
            if(ip.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(ip))
            {
                localIP = ip.ToString();
                print(localIP);
            }
        }
        return localIP;
    }

    WebServer CreateServer(string url)
    {
        var server = new WebServer(o => o
            .WithUrlPrefix(url)
            .WithMode(HttpListenerMode.EmbedIO))
            .WithLocalSessionManager()
            .WithStaticFolder("/", Path.Combine(Application.streamingAssetsPath, "Site"), true);

        return server;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
