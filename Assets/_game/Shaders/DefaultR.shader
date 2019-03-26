// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:Standard,cmtg:SF,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,acwp:False,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:3138,x:34553,y:31837,varname:node_3138,prsc:2|normal-94-OUT,emission-5001-OUT,custl-1578-OUT;n:type:ShaderForge.SFN_LightVector,id:1501,x:32319,y:31459,varname:node_1501,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:2465,x:32319,y:31315,prsc:2,pt:True;n:type:ShaderForge.SFN_Set,id:8678,x:32854,y:31613,varname:lightData,prsc:2|IN-8244-OUT;n:type:ShaderForge.SFN_LightColor,id:2706,x:32506,y:31665,varname:node_2706,prsc:2;n:type:ShaderForge.SFN_Multiply,id:123,x:32506,y:31540,varname:node_123,prsc:2|A-7497-OUT,B-7929-OUT;n:type:ShaderForge.SFN_Multiply,id:8244,x:32698,y:31613,varname:node_8244,prsc:2|A-123-OUT,B-2706-RGB;n:type:ShaderForge.SFN_LightAttenuation,id:7929,x:32319,y:31583,varname:node_7929,prsc:2;n:type:ShaderForge.SFN_Color,id:6001,x:32320,y:32230,ptovrint:False,ptlb:Main Color,ptin:_MainColor,varname:_MainColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.490566,c2:0.4365141,c3:0.4234603,c4:1;n:type:ShaderForge.SFN_Set,id:7467,x:32666,y:32312,varname:Diffuse,prsc:2|IN-8746-OUT;n:type:ShaderForge.SFN_Tex2d,id:7791,x:32322,y:32399,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:51b835cd704dabe45ba424e140c77466,ntxv:0,isnm:False|UVIN-4125-OUT;n:type:ShaderForge.SFN_Dot,id:7497,x:32506,y:31386,varname:node_7497,prsc:2,dt:1|A-1501-OUT,B-2465-OUT;n:type:ShaderForge.SFN_HalfVector,id:3782,x:32319,y:31191,varname:node_3782,prsc:2;n:type:ShaderForge.SFN_Dot,id:7728,x:32506,y:31242,varname:node_7728,prsc:2,dt:1|A-3782-OUT,B-2465-OUT;n:type:ShaderForge.SFN_Set,id:3922,x:32661,y:31540,varname:Shadow,prsc:2|IN-123-OUT;n:type:ShaderForge.SFN_Set,id:1493,x:33408,y:31242,varname:Specular,prsc:2|IN-8182-OUT;n:type:ShaderForge.SFN_Power,id:5125,x:32703,y:31242,varname:node_5125,prsc:2|VAL-7728-OUT,EXP-2568-OUT;n:type:ShaderForge.SFN_Slider,id:589,x:32624,y:31018,ptovrint:False,ptlb:SpecularPower,ptin:_SpecularPower,varname:_SpecularPower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.5,max:10;n:type:ShaderForge.SFN_Exp,id:2568,x:32703,y:31098,varname:node_2568,prsc:2,et:0|IN-589-OUT;n:type:ShaderForge.SFN_Slider,id:6040,x:32929,y:31019,ptovrint:False,ptlb:SpecularIntensity,ptin:_SpecularIntensity,varname:_SpecularIntensity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:10;n:type:ShaderForge.SFN_Exp,id:6503,x:33008,y:31098,varname:node_6503,prsc:2,et:0|IN-6040-OUT;n:type:ShaderForge.SFN_Multiply,id:5055,x:33008,y:31242,varname:node_5055,prsc:2|A-5125-OUT,B-6503-OUT;n:type:ShaderForge.SFN_Multiply,id:8182,x:33251,y:31242,varname:node_8182,prsc:2|A-5055-OUT,B-2912-RGB,C-6427-OUT;n:type:ShaderForge.SFN_Get,id:6427,x:33251,y:31379,varname:node_6427,prsc:2|IN-3922-OUT;n:type:ShaderForge.SFN_HalfVector,id:632,x:32506,y:31820,varname:node_632,prsc:2;n:type:ShaderForge.SFN_Tangent,id:243,x:32320,y:31976,varname:node_243,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5830,x:33244,y:31886,varname:node_5830,prsc:2|A-6727-OUT,B-7947-OUT,C-2632-RGB;n:type:ShaderForge.SFN_Get,id:593,x:33409,y:32017,varname:node_593,prsc:2|IN-3922-OUT;n:type:ShaderForge.SFN_Bitangent,id:9222,x:32320,y:31848,varname:node_9222,prsc:2;n:type:ShaderForge.SFN_Multiply,id:4707,x:33430,y:31886,varname:node_4707,prsc:2|A-5830-OUT,B-593-OUT;n:type:ShaderForge.SFN_Power,id:6727,x:33038,y:31886,varname:node_6727,prsc:2|VAL-7879-OUT,EXP-4050-OUT;n:type:ShaderForge.SFN_Slider,id:8551,x:32881,y:32184,ptovrint:False,ptlb:AnisotropicPower,ptin:_AnisotropicPower,varname:_AnisotropicPower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.5,max:10;n:type:ShaderForge.SFN_Exp,id:4050,x:33038,y:32013,varname:node_4050,prsc:2,et:0|IN-8551-OUT;n:type:ShaderForge.SFN_Color,id:2632,x:33244,y:32032,ptovrint:False,ptlb:AnisotropicColor,ptin:_AnisotropicColor,varname:_AnisotropicColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Slider,id:7947,x:33165,y:31802,ptovrint:False,ptlb:AnisotropicIntensity,ptin:_AnisotropicIntensity,varname:_AnisotropicIntensitynode_7947,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:2;n:type:ShaderForge.SFN_OneMinus,id:7879,x:32870,y:31886,varname:node_7879,prsc:2|IN-8897-OUT;n:type:ShaderForge.SFN_Set,id:9153,x:33588,y:31886,varname:Anisotropic,prsc:2|IN-4707-OUT;n:type:ShaderForge.SFN_Dot,id:8897,x:32703,y:31886,varname:node_8897,prsc:2,dt:3|A-632-OUT,B-959-OUT;n:type:ShaderForge.SFN_Lerp,id:959,x:32506,y:31956,varname:node_959,prsc:2|A-9222-OUT,B-243-OUT,T-8679-OUT;n:type:ShaderForge.SFN_Slider,id:8679,x:32163,y:32120,ptovrint:False,ptlb:AnisotropicDirection,ptin:_AnisotropicDirection,varname:_AnisotropicDirection,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.45,max:1;n:type:ShaderForge.SFN_SwitchProperty,id:8345,x:33322,y:31571,ptovrint:False,ptlb:HighLights,ptin:_HighLights,varname:_HighLights,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-7856-OUT,B-6834-OUT;n:type:ShaderForge.SFN_Get,id:7856,x:33106,y:31531,varname:node_7856,prsc:2|IN-1493-OUT;n:type:ShaderForge.SFN_Get,id:6834,x:33106,y:31631,varname:node_6834,prsc:2|IN-9153-OUT;n:type:ShaderForge.SFN_Set,id:325,x:33495,y:31571,varname:highlights,prsc:2|IN-8345-OUT;n:type:ShaderForge.SFN_NormalVector,id:3380,x:32322,y:32754,prsc:2,pt:True;n:type:ShaderForge.SFN_Dot,id:214,x:32518,y:32824,varname:node_214,prsc:2,dt:0|A-3380-OUT,B-2749-OUT;n:type:ShaderForge.SFN_Set,id:1672,x:33411,y:32760,varname:FresnelCustom,prsc:2|IN-8196-OUT;n:type:ShaderForge.SFN_ViewVector,id:2749,x:32322,y:32897,varname:node_2749,prsc:2;n:type:ShaderForge.SFN_OneMinus,id:7332,x:32680,y:32824,varname:node_7332,prsc:2|IN-214-OUT;n:type:ShaderForge.SFN_Power,id:1670,x:32887,y:32824,varname:node_1670,prsc:2|VAL-7332-OUT,EXP-6170-OUT;n:type:ShaderForge.SFN_Slider,id:8454,x:32165,y:33046,ptovrint:False,ptlb:FresnelPower,ptin:_FresnelPower,varname:_fresnelPower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Fresnel,id:3863,x:32892,y:33111,varname:node_3863,prsc:2|NRM-6216-OUT,EXP-6170-OUT;n:type:ShaderForge.SFN_NormalVector,id:6216,x:32680,y:33111,prsc:2,pt:True;n:type:ShaderForge.SFN_Set,id:368,x:33221,y:33111,varname:Fresnel,prsc:2|IN-2266-OUT;n:type:ShaderForge.SFN_Color,id:2330,x:32680,y:32556,ptovrint:False,ptlb:FresnelColor,ptin:_FresnelColor,varname:_FresnelColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6078432,c2:0.9734884,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:3400,x:33092,y:32760,varname:node_3400,prsc:2|A-4908-OUT,B-1670-OUT;n:type:ShaderForge.SFN_Tex2d,id:9925,x:32849,y:32419,ptovrint:False,ptlb:NormalTex,ptin:_NormalTex,varname:_NormalTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:85d1b7936851d4a4d8e2b82e7448ea5d,ntxv:3,isnm:True|UVIN-9060-OUT;n:type:ShaderForge.SFN_Lerp,id:2052,x:33034,y:32399,varname:node_2052,prsc:2|A-4936-OUT,B-9925-RGB,T-7903-OUT;n:type:ShaderForge.SFN_Vector3,id:4936,x:32849,y:32308,varname:node_4936,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Slider,id:7903,x:33034,y:32562,ptovrint:False,ptlb:NormalPower,ptin:_NormalPower,varname:_NormalPower,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.527589,max:1;n:type:ShaderForge.SFN_Set,id:2699,x:33197,y:32399,varname:normalData,prsc:2|IN-2052-OUT;n:type:ShaderForge.SFN_TexCoord,id:238,x:32478,y:33291,varname:node_238,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Panner,id:4425,x:32680,y:33291,varname:node_4425,prsc:2,spu:1,spv:0|UVIN-238-UVOUT,DIST-7500-OUT;n:type:ShaderForge.SFN_Time,id:5071,x:32478,y:33456,varname:node_5071,prsc:2;n:type:ShaderForge.SFN_Slider,id:5014,x:32523,y:33634,ptovrint:False,ptlb:PannSpeed,ptin:_PannSpeed,varname:_spinSpeed_A,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:5;n:type:ShaderForge.SFN_Multiply,id:7500,x:32680,y:33456,varname:node_7500,prsc:2|A-5071-T,B-5014-OUT;n:type:ShaderForge.SFN_Get,id:9060,x:32666,y:32419,varname:node_9060,prsc:2|IN-6124-OUT;n:type:ShaderForge.SFN_Color,id:2912,x:33251,y:31081,ptovrint:False,ptlb:SpecularColor,ptin:_SpecularColor,varname:node_2912,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Multiply,id:8746,x:32503,y:32312,varname:node_8746,prsc:2|A-6001-RGB,B-7791-RGB;n:type:ShaderForge.SFN_Get,id:4125,x:32130,y:32399,varname:node_4125,prsc:2|IN-6124-OUT;n:type:ShaderForge.SFN_Set,id:6124,x:32840,y:33291,varname:PannUV,prsc:2|IN-4425-UVOUT;n:type:ShaderForge.SFN_Clamp01,id:8196,x:33257,y:32760,varname:node_8196,prsc:2|IN-3400-OUT;n:type:ShaderForge.SFN_Get,id:8224,x:33805,y:31961,varname:node_8224,prsc:2|IN-7467-OUT;n:type:ShaderForge.SFN_Get,id:5673,x:33805,y:32053,varname:node_5673,prsc:2|IN-8678-OUT;n:type:ShaderForge.SFN_Get,id:94,x:34316,y:31913,varname:node_94,prsc:2|IN-2699-OUT;n:type:ShaderForge.SFN_Multiply,id:4930,x:34022,y:32145,varname:node_4930,prsc:2|A-5673-OUT,B-5592-OUT;n:type:ShaderForge.SFN_Get,id:5592,x:33805,y:32145,varname:node_5592,prsc:2|IN-325-OUT;n:type:ShaderForge.SFN_Multiply,id:5001,x:34022,y:31961,varname:node_5001,prsc:2|A-8224-OUT,B-5673-OUT;n:type:ShaderForge.SFN_Get,id:4919,x:33805,y:32283,varname:node_4919,prsc:2|IN-1672-OUT;n:type:ShaderForge.SFN_Blend,id:8280,x:34242,y:32283,varname:node_8280,prsc:2,blmd:6,clmp:True|SRC-4930-OUT,DST-8717-OUT;n:type:ShaderForge.SFN_RemapRange,id:6170,x:32680,y:32944,varname:node_6170,prsc:2,frmn:0,frmx:1,tomn:15,tomx:0|IN-8454-OUT;n:type:ShaderForge.SFN_Clamp01,id:2266,x:33062,y:33111,varname:node_2266,prsc:2|IN-3863-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:1578,x:34242,y:32145,ptovrint:False,ptlb:useFresnel,ptin:_useFresnel,varname:node_1578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4930-OUT,B-8280-OUT;n:type:ShaderForge.SFN_Multiply,id:8717,x:34022,y:32283,varname:node_8717,prsc:2|A-4919-OUT,B-6122-OUT;n:type:ShaderForge.SFN_Get,id:6122,x:33805,y:32331,varname:node_6122,prsc:2|IN-3922-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:4908,x:32887,y:32702,ptovrint:False,ptlb:lightColorFresnel,ptin:_lightColorFresnel,varname:node_4908,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-2330-RGB,B-8367-RGB;n:type:ShaderForge.SFN_LightColor,id:8367,x:32680,y:32702,varname:node_8367,prsc:2;proporder:6001-7791-9925-7903-8345-2632-8551-7947-2912-589-6040-8679-2330-8454-5014-1578-4908;pass:END;sub:END;*/

Shader "Retus001/DefaultR" {
    Properties {
        _MainColor ("Main Color", Color) = (0.490566,0.4365141,0.4234603,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _NormalTex ("NormalTex", 2D) = "bump" {}
        _NormalPower ("NormalPower", Range(0, 1)) = 0.527589
        [MaterialToggle] _HighLights ("HighLights", Float ) = 0
        _AnisotropicColor ("AnisotropicColor", Color) = (1,1,1,1)
        _AnisotropicPower ("AnisotropicPower", Range(0, 10)) = 3.5
        _AnisotropicIntensity ("AnisotropicIntensity", Range(0, 2)) = 1
        _SpecularColor ("SpecularColor", Color) = (1,1,1,1)
        _SpecularPower ("SpecularPower", Range(0, 10)) = 3.5
        _SpecularIntensity ("SpecularIntensity", Range(0, 10)) = 0
        _AnisotropicDirection ("AnisotropicDirection", Range(0, 1)) = 0.45
        _FresnelColor ("FresnelColor", Color) = (0.6078432,0.9734884,1,1)
        _FresnelPower ("FresnelPower", Range(0, 1)) = 0
        _PannSpeed ("PannSpeed", Range(0, 5)) = 0
        [MaterialToggle] _useFresnel ("useFresnel", Float ) = 0
        [MaterialToggle] _lightColorFresnel ("lightColorFresnel", Float ) = 0.6078432
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "CustomTag"="SF"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #if !UNITY_PASS_FORWARDBASE
            #define UNITY_PASS_FORWARDBASE
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _MainColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _SpecularPower;
            uniform float _SpecularIntensity;
            uniform float _AnisotropicPower;
            uniform float4 _AnisotropicColor;
            uniform float _AnisotropicIntensity;
            uniform float _AnisotropicDirection;
            uniform fixed _HighLights;
            uniform float _FresnelPower;
            uniform float4 _FresnelColor;
            uniform sampler2D _NormalTex; uniform float4 _NormalTex_ST;
            uniform float _NormalPower;
            uniform float _PannSpeed;
            uniform float4 _SpecularColor;
            uniform fixed _useFresnel;
            uniform fixed _lightColorFresnel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_5071 = _Time;
                float2 PannUV = (i.uv0+(node_5071.g*_PannSpeed)*float2(1,0));
                float2 node_9060 = PannUV;
                float3 _NormalTex_var = UnpackNormal(tex2D(_NormalTex,TRANSFORM_TEX(node_9060, _NormalTex)));
                float3 normalData = lerp(float3(0,0,1),_NormalTex_var.rgb,_NormalPower);
                float3 normalLocal = normalData;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
////// Emissive:
                float2 node_4125 = PannUV;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(node_4125, _MainTex));
                float3 Diffuse = (_MainColor.rgb*_MainTex_var.rgb);
                float node_123 = (max(0,dot(lightDirection,normalDirection))*attenuation);
                float3 lightData = (node_123*_LightColor0.rgb);
                float3 node_5673 = lightData;
                float3 emissive = (Diffuse*node_5673);
                float Shadow = node_123;
                float3 Specular = ((pow(max(0,dot(halfDirection,normalDirection)),exp(_SpecularPower))*exp(_SpecularIntensity))*_SpecularColor.rgb*Shadow);
                float3 Anisotropic = ((pow((1.0 - abs(dot(halfDirection,lerp(i.bitangentDir,i.tangentDir,_AnisotropicDirection)))),exp(_AnisotropicPower))*_AnisotropicIntensity*_AnisotropicColor.rgb)*Shadow);
                float3 highlights = lerp( Specular, Anisotropic, _HighLights );
                float3 node_4930 = (node_5673*highlights);
                float node_6170 = (_FresnelPower*-15.0+15.0);
                float3 FresnelCustom = saturate((lerp( _FresnelColor.rgb, _LightColor0.rgb, _lightColorFresnel )*pow((1.0 - dot(normalDirection,viewDirection)),node_6170)));
                float3 finalColor = emissive + lerp( node_4930, saturate((1.0-(1.0-node_4930)*(1.0-(FresnelCustom*Shadow)))), _useFresnel );
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #if !UNITY_PASS_FORWARDADD
            #define UNITY_PASS_FORWARDADD
            #endif
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _MainColor;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _SpecularPower;
            uniform float _SpecularIntensity;
            uniform float _AnisotropicPower;
            uniform float4 _AnisotropicColor;
            uniform float _AnisotropicIntensity;
            uniform float _AnisotropicDirection;
            uniform fixed _HighLights;
            uniform float _FresnelPower;
            uniform float4 _FresnelColor;
            uniform sampler2D _NormalTex; uniform float4 _NormalTex_ST;
            uniform float _NormalPower;
            uniform float _PannSpeed;
            uniform float4 _SpecularColor;
            uniform fixed _useFresnel;
            uniform fixed _lightColorFresnel;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 bitangentDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.bitangentDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.bitangentDir, i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float4 node_5071 = _Time;
                float2 PannUV = (i.uv0+(node_5071.g*_PannSpeed)*float2(1,0));
                float2 node_9060 = PannUV;
                float3 _NormalTex_var = UnpackNormal(tex2D(_NormalTex,TRANSFORM_TEX(node_9060, _NormalTex)));
                float3 normalData = lerp(float3(0,0,1),_NormalTex_var.rgb,_NormalPower);
                float3 normalLocal = normalData;
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                UNITY_LIGHT_ATTENUATION(attenuation, i, i.posWorld.xyz);
                float node_123 = (max(0,dot(lightDirection,normalDirection))*attenuation);
                float3 lightData = (node_123*_LightColor0.rgb);
                float3 node_5673 = lightData;
                float Shadow = node_123;
                float3 Specular = ((pow(max(0,dot(halfDirection,normalDirection)),exp(_SpecularPower))*exp(_SpecularIntensity))*_SpecularColor.rgb*Shadow);
                float3 Anisotropic = ((pow((1.0 - abs(dot(halfDirection,lerp(i.bitangentDir,i.tangentDir,_AnisotropicDirection)))),exp(_AnisotropicPower))*_AnisotropicIntensity*_AnisotropicColor.rgb)*Shadow);
                float3 highlights = lerp( Specular, Anisotropic, _HighLights );
                float3 node_4930 = (node_5673*highlights);
                float node_6170 = (_FresnelPower*-15.0+15.0);
                float3 FresnelCustom = saturate((lerp( _FresnelColor.rgb, _LightColor0.rgb, _lightColorFresnel )*pow((1.0 - dot(normalDirection,viewDirection)),node_6170)));
                float3 finalColor = lerp( node_4930, saturate((1.0-(1.0-node_4930)*(1.0-(FresnelCustom*Shadow)))), _useFresnel );
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
    }
    FallBack "Standard"
    CustomEditor "ShaderForgeMaterialInspector"
}
