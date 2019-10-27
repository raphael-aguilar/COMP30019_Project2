// Based on Vertical Fog Shader by Harry Alisavakis
//http://halisavakis.com/my-take-on-shaders-vertical-fog/

Shader "Unlit/VerticalFogIntersection"
{
    Properties
    {
       _Color("Main Color", Color) = (1, 1, 1, .5)
       _IntersectionThresholdMax("Intersection Threshold Max", float) = 0.3
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType"="Transparent"  }
  
        Pass
        {
           Blend SrcAlpha OneMinusSrcAlpha
           ZWrite Off
           CGPROGRAM
           #pragma vertex vert
           #pragma fragment frag
           #pragma multi_compile_fog
           #include "UnityCG.cginc"
  
			uniform sampler2D _MainTex;	
           struct appdata
           {
               float4 vertex : POSITION;
           };
  
           struct v2f
           {
               float4 scrPos : TEXCOORD0;
               UNITY_FOG_COORDS(1)
               float4 vertex : SV_POSITION;
           };
 

  
           sampler2D _CameraDepthTexture;
           float4 _Color;
           float4 _IntersectionColor;
           float _IntersectionThresholdMax;
  
           v2f vert(appdata v)
           {
               float4 displacement = float4(0.0f, 0.0f, 0.0f, 0.0f);
				v.vertex += displacement;
				v.vertex.y = 0.07*sin(v.vertex.x + 0.9*_Time.y) + 0.05*sin(v.vertex.z+1* _Time.y);
               v2f o;
               o.vertex = UnityObjectToClipPos(v.vertex);
               o.scrPos = ComputeScreenPos(o.vertex);
               UNITY_TRANSFER_FOG(o,o.vertex);
               return o;  
           }
  
  
            half4 frag(v2f i) : SV_TARGET
            {
               float depth = 1* LinearEyeDepth (tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.scrPos)));
               float diff = saturate(_IntersectionThresholdMax * (depth - i.scrPos.w));
               fixed4 col = lerp(fixed4(_Color.rgb, 0.0), _Color, diff * diff * diff * (diff * (6 * diff - 15) + 10));//lerp(fixed4(_Color.rgb, 0.0), _Color, diff);
  
               UNITY_APPLY_FOG(i.fogCoord, col);
               return col;
            }
  
            ENDCG
        }
    }
}