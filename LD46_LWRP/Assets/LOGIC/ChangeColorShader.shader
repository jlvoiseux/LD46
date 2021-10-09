Shader "Custom/ChangeColorShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Radius("Radius", Range(0,10)) = 5
		_SourcePos("Source Position", Vector) = (0, 0, 0, 0)
		_IsDown("Is Down", int) = 0
    }
    SubShader
    {
		Tags { "QUEUE" = "Transparent"  "RenderType" = "Transparent" }
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float4 _MainTex_TexelSize;
			float4 _SourcePos;
			float _Radius;
			int _IsDown;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				fixed2 uv = round(i.uv * _MainTex_TexelSize.zw) * _MainTex_TexelSize.xy;
				fixed4 col = tex2D(_MainTex, i.uv);

				float dist = distance(_SourcePos, uv);
				if (dist <= _Radius && _IsDown == 1)
				{
					return float4(0, 0, 0, 0);					
				}
				else
				{
					return col;
				}
            }
            ENDCG
        }
    }
}
