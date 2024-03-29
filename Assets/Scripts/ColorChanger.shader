﻿
Shader "Custom/ColorChanger" {

	Properties
	{

		 _MainColor("Main Color", Color) = (1,1,1,1)

		 _MainTex("Texture", 2D) = "white" {}

		_BumpMap("Bumpmap", 2D) = "bump" {}

		_RimColor("Rim Color", Color) = (1,1,1,1)

		_RimPower("Rim Power", Range(0.5,8.0)) = 3.0
	}

		
	SubShader{

		//Tags { "RenderType" = "Opaque" }

		CGPROGRAM

		#pragma surface surf Lambert

		struct Input {

			float2 uv_MainTex;

			float2 uv_BumpMap;

			float3 viewDir;
		};

		float4 _MainColor;
		sampler2D _MainTex;
		sampler2D _BumpMap;
		float4 _RimColor;
		float _RimPower;

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);

			o.Albedo = tex.rgb * _MainColor.rgb;

			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal));

			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
	}

	ENDCG
	}
		Fallback "Diffuse"
}
