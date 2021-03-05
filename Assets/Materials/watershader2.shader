Shader "Unlit/watershader2"
{
	 Properties{
        _Color("Main Tint",Color) = (1,1,1,1)
        _MainTex("Main Tex", 2D) = "white"{}
		_SubTex("Sub Tex",2D)= "white"{}
        _AlphaScale("Alpha Scale", Range(0,1)) = 1
		_ScrollXSpeed ("X Scroll Speed", Range(0, 10)) = 2
		_ScrollYSpeed ("Y Scroll Speed", Range(0, 10)) = 2
		_Ambient("Ambient",COLOR)=(1,1,1,1)
    }
        SubShader{
            Tags{"Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent"}
            Pass{
                Tags{"LightMode" = "ForwardBase"}
                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha
				Cull Off
				
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "Lighting.cginc"

                fixed4 _Color;
                sampler2D _MainTex;
				sampler2D _SubTex;
                fixed4 _MainTex_ST;
                fixed _AlphaScale;
				fixed _ScrollXSpeed;
				fixed _ScrollYSpeed;

                struct a2v {
                    float4 vertex : POSITION;
                    float4 texcoord : TEXCOORD0;
                };

                struct v2f {
                    float4 pos : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                v2f vert(a2v v) {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) :SV_Target{
					fixed2 uv1 = fixed2(i.uv.x - _ScrollXSpeed*_Time.x, i.uv.y - _ScrollYSpeed*_Time.x);
					fixed2 uv2 = fixed2(i.uv.x, i.uv.y - _ScrollYSpeed*_Time.x);
                    fixed4 col = tex2D(_MainTex, uv1);
					fixed4 col2 = tex2D(_SubTex, uv2);
                    fixed3 albedo = (col.rgb+col2.rgb) * _Color.rgb;
                    return fixed4(albedo, col.a*_AlphaScale);
                }
                ENDCG
            }
        }
}
