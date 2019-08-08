﻿Shader "Custom/SwapTwo" {

	Properties

	{

		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}

		_MainTex2("_MainTex2", 2D) = "white" {}

		_Color("Tint", Color) = (1,1,1,1)

		[MaterialToggle] PixelSnap("Pixel snap", Float) = 0

	}



		SubShader

		{

			Tags

			{

				"Queue" = "Transparent"

				"IgnoreProjector" = "True"

				"RenderType" = "Transparent"

				"PreviewType" = "Plane"

				"CanUseSpriteAtlas" = "True"

			}



			Cull Off

			Lighting Off

			ZWrite Off

			Blend One OneMinusSrcAlpha



			CGPROGRAM

			#pragma surface surf Lambert vertex:vert nofog keepalpha

			#pragma multi_compile _ PIXELSNAP_ON

			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA



			sampler2D _MainTex;

			fixed4 _Color;

			sampler2D _MainTex2;



			struct Input

			{

				float2 uv_MainTex;

				fixed4 color;

			};



			void vert(inout appdata_full v, out Input o)

			{

				#if defined(PIXELSNAP_ON)

				v.vertex = UnityPixelSnap(v.vertex);

				#endif



				UNITY_INITIALIZE_OUTPUT(Input, o);

				o.color = v.color * _Color;

			}



			void surf(Input IN, inout SurfaceOutput o)

			{

			   half4 c = tex2D(_MainTex2, IN.uv_MainTex) * IN.color;



				o.Albedo = c.rgb * c.a;

				o.Alpha = c.a;

			}

			ENDCG

		}



			Fallback "Transparent/VertexLit"

}