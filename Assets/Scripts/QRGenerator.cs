using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;

public class QRGenerator : MonoBehaviour
{
    // Texture for encoding test
   
    // Start is called before the first frame update
  

    public static void EncodeString(string s, ref Texture2D target)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = target.height,
                Width = target.width
            },
        };
        Color32[] colors = writer.Write(s);

        target.SetPixels32(colors);
        target.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
