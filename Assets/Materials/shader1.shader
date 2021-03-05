// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/shader1"
{
	Properties {
        _MainTex ("Tex1 (RGB)", 2D) = "white" {}
        _MainTex2 ("Tex2 (RGB)", 2D) = "white" {}
        _Color("Main color",Color) = (1,1,1,1)
    }
    SubShader {
        Pass
        {
            Material
            {
                Diffuse[_Color]
            }
            Lighting on
            SetTexture[_MainTex]
            {
                //      第一张材质 * 顶点颜色
                Combine texture + primary
            }
            SetTexture[_MainTex2]
            {
                Combine texture * previous
            }
        }
    }
}
