Shader "TextureBlender"
{
    Properties
    {
	    _Color ("Main Color", Color) = (1,1,1,1)
	    _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
	    _BlendTex ("Blend (RGB)", 2D) = "white"
    }
    
    SubShader
    {
	    Tags { "Queue"="Geometry-9" "IgnoreProjector"="True" "RenderType"="Transparent" }
	    Lighting Off
	    LOD 200
	    Blend SrcAlpha OneMinusSrcAlpha
	    
	    CGPROGRAM
		    #pragma surface surf Lambert
		    uniform fixed4 _Color;
		    uniform sampler2D _MainTex;
		    uniform sampler2D _BlendTex;

		    struct Input 
		    {
		    	float2 uv_MainTex;
		    };
		    
		    void surf (Input IN, inout SurfaceOutput o) 
		    {
		   		fixed4 c1 = tex2D( _MainTex, IN.uv_MainTex );
		   		fixed4 c2 = tex2D( _BlendTex, IN.uv_MainTex );
		   		
		   		fixed4 main = c1.rgba * (1.0 - c2.a);
		   		fixed4 blendedoutput = c2.rgba * c2.a;
		   		
		   		o.Albedo = (main.rgb + blendedoutput.rgb) * _Color;
		   		o.Alpha = main.a + blendedoutput.a;
		    }
	    ENDCG
    }
    Fallback "Transparent/VertexLit"
 }